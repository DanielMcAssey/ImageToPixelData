using System;
using System.IO;
using System.Drawing;

namespace ImageToPixelData
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                Environment.Exit(0);

            if (!File.Exists(args[0]))
                Environment.Exit(0);

            Bitmap _IMG = (Bitmap)Image.FromFile(@args[0], false);
            bool _OpressConsole = false;
            StreamWriter _sw = null;

            if (args[1] == "1")
                _OpressConsole = true;

            if (args.Length == 3)
                _sw = File.AppendText(args[2]);

            for (int y = 0; y < _IMG.Height; y++)
            {
                for (int x = 0; x < _IMG.Width; x++)
                {
                    Color _PIXELCOLOUR = _IMG.GetPixel(x, y);

                    if (!_OpressConsole)
                        Console.Write("X:{0} Y:{1} / RGB:{2}, {3}, {4}\n", x + 1, y + 1, _PIXELCOLOUR.R, _PIXELCOLOUR.G, _PIXELCOLOUR.B);

                    if (_sw != null)
                        _sw.WriteLine("X:{0} Y:{1} / RGB:{2}, {3}, {4}\n", x + 1, y + 1, _PIXELCOLOUR.R, _PIXELCOLOUR.G, _PIXELCOLOUR.B);
                }
            }

            if (_sw != null)
                _sw.Close();
        }
    }
}
