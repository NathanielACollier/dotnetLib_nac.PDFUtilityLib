using System;
using ImageMagick;

namespace nac.PDFUtilityLib.repositories;

public class MultiPageTIFFWriter : IDisposable
{
    private ImageMagick.MagickImageCollection tifImage;
    public int PageCount => this.tifImage.Count;
    
    public MultiPageTIFFWriter()
    {
        this.tifImage = new ImageMagick.MagickImageCollection();
    }

    public void AddPage(byte[] imageBytes)
    {
        var image = new ImageMagick.MagickImage(imageBytes);
        
        this.tifImage.Add(image);
    }

    public byte[] SaveToByteArray()
    {
        using (var ms = new System.IO.MemoryStream())
        {
            this.tifImage.Write(ms);
            return ms.ToArray();
        }
    }

    public void SaveToFile(string filePath)
    {
        this.tifImage.Write(filePath);
    }

    public void Dispose()
    {
        tifImage.Dispose();
    }
}