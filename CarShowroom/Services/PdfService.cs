using System.Diagnostics;
using CarShowroom.Services.Interfaces;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace CarShowroom.Services
{
    public class PdfService : IPdfService
    {
        public bool GeneratePDF(string filename, string imageLoc)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            page.Orientation = PageOrientation.Landscape;

            XGraphics gfx = XGraphics.FromPdfPage(page);
            DrawImage(gfx, imageLoc, 20, 50, 800, 450);

            document.Save(filename);
            Process.Start(filename);

            return true;
        }

        private void DrawImage(XGraphics gfx, string jpegSamplePath, int x, int y, int width, int height)
        {
            XImage image = XImage.FromFile(jpegSamplePath);
            gfx.DrawImage(image, x, y, width, height);
        }
    }
}