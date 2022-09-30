namespace PhotoFilter
{
    public class KernelMatrix
    {

        public static readonly float[,] Sharpened =
        {
            { 0, -0.5f, 0 },
            { -0.5f, 3, -0.5f },
            { 0, -0.5f, 0 }
        };

        public static readonly float SharpenedDiv = 1f;

        public static readonly float[,] BoxBlur =
        {
            { 1, 1, 1 },
            { 1, 1, 1 },
            { 1, 1, 1 }
        };

        public static readonly float BoxBlurDiv = 1 / 9f;

        public static readonly float[,] GaussianBlur5 =
        {
            { 1, 4, 6, 4, 1 },
            { 4, 16, 24, 16, 4 },
            { 6, 24, 36, 24, 6 },
            { 4, 16, 24, 16, 4 },
            { 1, 4, 6, 4, 1 }
        };

        public static readonly float GaussianBlurDiv5 = 1 / 256f;

        public static readonly float[,] Sharpened5 =
        {
            { -1, -1, -1, -1, -1 },
            { -1, 2, 2, 2, -1 },
            { -1, 2, 8, 2, -1 },
            { -1, 2, 2, 2, -1 },
            { -1, -1, -1, -1, -1 }
        };

        public static readonly float Sharpened5Div = 1 / 8f;

        public static readonly float[,] Extension =
        {
            { 0, 0, 1, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 1, 0, 0 }
        };

        public static readonly float ExtensionDiv = 1 / 13f;

        public static readonly float[,] MotionBlur =
        {
            { 1, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 1, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 1, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 1, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 1, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 1, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 1, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 1, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 1}
        };
        public static readonly float MotionBlurDiv = 1 / 9f;

    }
}