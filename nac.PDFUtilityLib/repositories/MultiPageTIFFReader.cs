using System;
using ImageMagick;

namespace nac.PDFUtilityLib.repositories;

public class MultiPageTIFFReader : IDisposable
{
    private ImageMagick.MagickImageCollection tifImage;   
    public int PageCount { get; set; }
    
    public MultiPageTIFFReader(string filePath)
    {
        this.tifImage = new ImageMagick.MagickImageCollection();
        tifImage.Read(filePath);
        this.PageCount = this.tifImage.Count;
    }

    public byte[] GetPageBitMap(int pageNumber)
    {
        var frameImage = this.tifImage[pageNumber];

        using (var ms = new System.IO.MemoryStream())
        {
            frameImage.Write(ms, MagickFormat.Bmp);
            return ms.ToArray();
        }
    }

    public void Dispose()
    {
        tifImage.Dispose();
    }
}

