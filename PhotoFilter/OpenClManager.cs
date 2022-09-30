using OpenCL.Net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using Environment = System.Environment;
using ImageFormat = OpenCL.Net.ImageFormat;


namespace PhotoFilter
{
    class OpenClManager
    {
        private Context _context;
        private Device _device;

        private float[] CreateMask(float[,] matrix, float div)
        {
            var maskSize = matrix.Length;
            float[] mask = new float[maskSize];
            var i = 0;
            foreach (var VARIABLE in matrix)
            {
                mask[i] = VARIABLE * div;
                i++;
            }

            return mask;
        }


        // static void Main(string[] args)
        //     {
        //        Setup();
        //         string workingDirectory = Environment.CurrentDirectory;
        //         string kernelPath = Directory.GetParent(workingDirectory).Parent.Parent.FullName + "/kernel.txt";
        //         ImagingTest("D:/volkov.jpg", "D:/2.png", kernelPath);
        //
        //     }

        private void CheckErr(ErrorCode err, string name)
        {
            if (err != ErrorCode.Success)
            {
                Console.WriteLine("ERROR: " + name + " (" + err.ToString() + ")");

            }
        }

        private void ContextNotify(string errInfo, byte[] data, IntPtr cb, IntPtr userData)
        {
            Console.WriteLine("OpenCL Notification: " + errInfo);
        }

        public OpenClManager()
        {
            ErrorCode error;
            Platform[] platforms = Cl.GetPlatformIDs(out error);
            List<Device> devicesList = new List<Device>();

            CheckErr(error, "Cl.GetPlatformIDs");

            foreach (Platform platform in platforms)
            {
                string platformName = Cl.GetPlatformInfo(platform, PlatformInfo.Name, out error).ToString();
                Console.WriteLine("Platform: " + platformName);
                CheckErr(error, "Cl.GetPlatformInfo");
                //We will be looking only for GPU devices
                foreach (Device device in Cl.GetDeviceIDs(platform, DeviceType.Gpu, out error))
                {
                    CheckErr(error, "Cl.GetDeviceIDs");
                    Console.WriteLine("Device: " + device.ToString());
                    devicesList.Add(device);
                }
            }

            if (devicesList.Count <= 0)
            {
                Console.WriteLine("No devices found.");
                return;
            }

            _device = devicesList[0];

            if (Cl.GetDeviceInfo(_device, DeviceInfo.ImageSupport,
                    out error).CastTo<Bool>() == Bool.False)
            {
                Console.WriteLine("No image support.");
                return;
            }

            _context
                = Cl.CreateContext(null, 1, new[] { _device }, ContextNotify,
                    IntPtr.Zero, out error); //Second parameter is amount of devices
            CheckErr(error, "Cl.CreateContext");
        }

        public Bitmap GPUConvolution(Bitmap inputImage, float[,] matrix, float div, int kernelDim)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string kernelPath = Directory.GetParent(workingDirectory).Parent.Parent.FullName + "/kernel.txt";
            ErrorCode errorCode;

            //Load and compile kernel source code.
            var mask = CreateMask(matrix, div);
            if (!System.IO.File.Exists(kernelPath))
            {
                Console.WriteLine("Program doesn't exist at path " + kernelPath);
                return null;
            }

            string programSource = System.IO.File.ReadAllText(kernelPath);

            using (OpenCL.Net.Program program =
                   Cl.CreateProgramWithSource(_context, 1, new[] { programSource }, null, out errorCode))
            {
                CheckErr(errorCode, "Cl.CreateProgramWithSource");

                //Compile kernel source
                errorCode = Cl.BuildProgram(program, 1, new[] { _device }, string.Empty, null, IntPtr.Zero);
                CheckErr(errorCode, "Cl.BuildProgram");

                //Create the required kernel (entry function)
                Kernel kernel = Cl.CreateKernel(program, "convolution", out errorCode);
                CheckErr(errorCode, "Cl.CreateKernel");

                int intPtrSize = 0;
                intPtrSize = Marshal.SizeOf(typeof(IntPtr));

                //Image's RGBA data converted to an unmanaged[] array
                byte[] inputByteArray;
                //OpenCL memory buffer that will keep our image's byte[] data.
                Mem inputImage2DBuffer;

                ImageFormat clImageFormat = new ImageFormat(ChannelOrder.RGBA, ChannelType.Unsigned_Int8);

                int inputImgWidth, inputImgHeight;

                int inputImgBytesSize;

                int inputImgStride;




                inputImgWidth = inputImage.Width;
                inputImgHeight = inputImage.Height;

                var bmpImage = inputImage;

                //Get raw pixel data of the bitmap
                //The format should match the format of clImageFormat
                BitmapData bitmapData = bmpImage.LockBits(new Rectangle(0, 0, bmpImage.Width, bmpImage.Height),
                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb); //inputImage.PixelFormat);

                inputImgStride = bitmapData.Stride;
                inputImgBytesSize = bitmapData.Stride * bitmapData.Height;

                //Copy the raw bitmap data to an unmanaged byte[] array
                inputByteArray = new byte[inputImgBytesSize];
                Marshal.Copy(bitmapData.Scan0, inputByteArray, 0, inputImgBytesSize);

                //Allocate OpenCL image memory buffer
                inputImage2DBuffer = (Mem)Cl.CreateImage2D(_context, MemFlags.CopyHostPtr | MemFlags.ReadOnly,
                    clImageFormat,
                    (IntPtr)bitmapData.Width, (IntPtr)bitmapData.Height,
                    (IntPtr)0, inputByteArray, out errorCode);
                CheckErr(errorCode, "Cl.CreateImage2D input");


                //Unmanaged output image's raw RGBA byte[] array
                byte[] outputByteArray = new byte[inputImgBytesSize];

                //Allocate OpenCL image memory buffer
                IMem outputImage2DBuffer = Cl.CreateImage2D(_context, MemFlags.CopyHostPtr | MemFlags.WriteOnly,
                    clImageFormat,
                    (IntPtr)inputImgWidth, (IntPtr)inputImgHeight, (IntPtr)0, outputByteArray, out errorCode);
                //  Cl.CreateBuffer(_context,  )
                CheckErr(errorCode, "Cl.CreateImage2D output");
                // ComputeContext cont = new ComputeContext();
                // ComputeBuffer<float> bufV1 = new ComputeBuffer<float>(_context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, mask);
                


                var maskBuf = Cl.CreateBuffer(_context, MemFlags.ReadWrite | MemFlags.UseHostPtr, mask, out errorCode);
                var maBuf = Cl.CreateBuffer(_context, MemFlags.ReadWrite, 5, out errorCode);

                CheckErr(errorCode, "setFloatBuffer");
                //Pass the memory buffers to our kernel function
                errorCode = Cl.SetKernelArg(kernel, 0, (IntPtr)intPtrSize, inputImage2DBuffer);
                errorCode |= Cl.SetKernelArg(kernel, 1, (IntPtr)intPtrSize, outputImage2DBuffer);
                errorCode |= Cl.SetKernelArg(kernel, 2, maskBuf);
                errorCode |= Cl.SetKernelArg(kernel, 3, kernelDim);


                CheckErr(errorCode, "Cl.SetKernelArg");

                //Create a command queue, where all of the commands for execution will be added
                CommandQueue cmdQueue =
                    Cl.CreateCommandQueue(_context, _device, (CommandQueueProperties)0, out errorCode);
                CheckErr(errorCode, "Cl.CreateCommandQueue");

                Event clevent;

                //Copy input image from the host to the GPU.
                IntPtr[] originPtr = new IntPtr[] { (IntPtr)0, (IntPtr)0, (IntPtr)0 }; //x, y, z
                IntPtr[] regionPtr = new IntPtr[]
                    { (IntPtr)inputImgWidth, (IntPtr)inputImgHeight, (IntPtr)1 }; //x, y, z
                IntPtr[] workGroupSizePtr = new IntPtr[]
                    { (IntPtr)inputImgWidth, (IntPtr)inputImgHeight, (IntPtr)1 };
                errorCode = Cl.EnqueueWriteImage(cmdQueue, inputImage2DBuffer, Bool.True, originPtr, regionPtr,
                    (IntPtr)0, (IntPtr)0, inputByteArray, 0, null, out clevent);
                CheckErr(errorCode, "Cl.EnqueueWriteImage");

                //Execute our kernel (OpenCL code)
                errorCode = Cl.EnqueueNDRangeKernel(cmdQueue, kernel, 2, null, workGroupSizePtr, null, 0, null,
                    out clevent);
                CheckErr(errorCode, "Cl.EnqueueNDRangeKernel");

                //Wait for completion of all calculations on the GPU.
                errorCode = Cl.Finish(cmdQueue);
                CheckErr(errorCode, "Cl.Finish");

                //Read the processed image from GPU to raw RGBA data byte[] array
                errorCode = Cl.EnqueueReadImage(cmdQueue, outputImage2DBuffer, Bool.True, originPtr, regionPtr,
                    (IntPtr)0, (IntPtr)0, outputByteArray, 0, null, out clevent);
                CheckErr(errorCode, "Cl.clEnqueueReadImage");

                //Clean up memory
                Cl.ReleaseKernel(kernel);
                Cl.ReleaseCommandQueue(cmdQueue);

                Cl.ReleaseMemObject(inputImage2DBuffer);
                Cl.ReleaseMemObject(outputImage2DBuffer);

                //Get a pointer to our unmanaged output byte[] array
                GCHandle pinnedOutputArray = GCHandle.Alloc(outputByteArray, GCHandleType.Pinned);
                IntPtr outputBmpPointer = pinnedOutputArray.AddrOfPinnedObject();

                //Create a new bitmap with processed data and save it to a file.
                Bitmap outputBitmap = new Bitmap(inputImgWidth, inputImgHeight, inputImgStride,
                    PixelFormat.Format32bppArgb, outputBmpPointer);
                // var a = outputBitmap.Size;
                // outputBitmap.Save(outputImagePath, System.Drawing.Imaging.ImageFormat.Png);

                pinnedOutputArray.Free();
                //    outputBitmap.UnlockBits(bitmapData);

                return outputBitmap;
            }
        }
    }
}