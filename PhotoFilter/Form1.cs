using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace PhotoFilter
{
    public partial class Filter : Form
    {
        private Bitmap _currentPhoto;
        private Bitmap _philteredPhoto;
        private OpenClManager _clManager;
        private float[,] _currentMatrixFilter;
        private float _currentFilterDivider;
        private int _kernelDim;

        public Filter()
        {
            InitializeComponent();
            _clManager = new OpenClManager();
        }


        private void choosePhotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (choose_photo_dialog.ShowDialog() == DialogResult.OK)
            {
                _currentPhoto = new Bitmap(choose_photo_dialog.FileName);
                start_photo.Image = _currentPhoto;
                end_photo.Image = null;
                choosePhilterToolStripMenuItem.Visible = true;
                repeatFilterButon.Visible = false;
                saveButton.Visible = false;
                sizeLabel.Text = _currentPhoto.Size.ToString();
                long size = 0;
                float fSize=0.0f;
                    using (Stream s = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(s, _currentPhoto);
                    size = s.Length;
                    fSize = (float)size / 1024;
                    Math.Round(fSize, 2);
                }
                weightLabel.Text = fSize+" kb";

            }
        }

        private void gaussianBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            choosePhilterToolStripMenuItem.Text = "GaussBlur";
            _currentMatrixFilter = KernelMatrix.GaussianBlur5;
            _currentFilterDivider = KernelMatrix.GaussianBlurDiv5;
            _kernelDim = 5;
            FilterButton.Visible = true;
            saveButton.Visible = true;
            filerAllImageInFolderToolStripMenuItem.Visible = true;
        }

        private void sharpenedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            choosePhilterToolStripMenuItem.Text = "Sharpened";
            _currentMatrixFilter = KernelMatrix.Sharpened5;
            _currentFilterDivider = KernelMatrix.Sharpened5Div;
            _kernelDim = 5;
            FilterButton.Visible = true;
            saveButton.Visible = true;
            filerAllImageInFolderToolStripMenuItem.Visible = true;
        }

        private void boxBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            choosePhilterToolStripMenuItem.Text = "BoxBlur";
            _currentMatrixFilter = KernelMatrix.BoxBlur;
            _currentFilterDivider = KernelMatrix.BoxBlurDiv;
            _kernelDim = 3;
            FilterButton.Visible = true;
            saveButton.Visible = true;
            filerAllImageInFolderToolStripMenuItem.Visible = true;
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            var inputClone = (Bitmap)_currentPhoto.Clone();
            _philteredPhoto =
                _clManager.GPUConvolution(inputClone, _currentMatrixFilter, _currentFilterDivider, _kernelDim);
            //Variant for CPU
            //_philteredPhoto = CPUConvolution.Apply(_currentPhoto, KernelMatrix.Sharpened, KernelMatrix.SharpenedDiv);
            end_photo.Image = _philteredPhoto;
            repeatFilterButon.Visible = true;
            saveButton.Visible = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*.jpg";
            ImageFormat format = ImageFormat.Png;
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
                _philteredPhoto.Save(sfd.FileName, format);
            }
        }

        private void extensionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            choosePhilterToolStripMenuItem.Text = "Extension";
            _currentMatrixFilter = KernelMatrix.Extension;
            _currentFilterDivider = KernelMatrix.ExtensionDiv;
            _kernelDim = 5;
            FilterButton.Visible = true;
            saveButton.Visible = true;
            filerAllImageInFolderToolStripMenuItem.Visible = true;
        }

        private void motionBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            choosePhilterToolStripMenuItem.Text = "MotionBlur";
            _currentMatrixFilter = KernelMatrix.MotionBlur;
            _currentFilterDivider = KernelMatrix.MotionBlurDiv;
            _kernelDim = 9;
            FilterButton.Visible = true;
            saveButton.Visible = true;
            filerAllImageInFolderToolStripMenuItem.Visible = true;
        }

        private void repeatFilterButon_Click(object sender, EventArgs e)
        {
            _currentPhoto = _philteredPhoto;
            start_photo.Image = _philteredPhoto;
            var inputClone = (Bitmap)_currentPhoto.Clone();
            _philteredPhoto =
                _clManager.GPUConvolution(inputClone, _currentMatrixFilter, _currentFilterDivider, _kernelDim);
            end_photo.Image = _philteredPhoto;

            sizeLabel.Text = _currentPhoto.Size.ToString();
            long size = 0;
            float fSize = 0.0f;
            using (Stream s = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(s, (Bitmap)_currentPhoto.Clone());
                size = s.Length;
                fSize = (float)size / 1024;
                Math.Round(fSize, 2);
            }
            weightLabel.Text = fSize + " kb";
        }

        private void filerAllImageInFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
                {
                    var startFolder = folderBrowserDialog1.SelectedPath;
                    var destFolder = folderBrowserDialog2.SelectedPath;

                    var files = Directory.EnumerateFiles(startFolder, "*.*", SearchOption.TopDirectoryOnly)
                        .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".bmp"));
                    Bitmap startImg = null;
                    foreach (var file in files)
                    {
                        startImg = new Bitmap(file);

                        var destImg =
                            _clManager.GPUConvolution(startImg, _currentMatrixFilter, _currentFilterDivider, _kernelDim);
                        var s = file.Split("\\");

                        var fileName = s[s.Length - 1];

                        ImageFormat format = ImageFormat.Png;

                        string ext = System.IO.Path.GetExtension(file);
                        switch (ext)
                        {
                            case ".jpg":
                                format = ImageFormat.Jpeg;
                                break;
                            case ".bmp":
                                format = ImageFormat.Bmp;
                                break;
                        }
                        destImg.Save(destFolder + "\\" +fileName);
                    }
                }
            }
        }
    }
}