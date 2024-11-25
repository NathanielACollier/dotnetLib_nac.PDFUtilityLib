using System.IO;

namespace nac.OCR.Tesseract.repositories;

public static class pdfToTifRepo
{
    private static repositories.Logger log = new();

    public static void ConvertPdfToMultipageTif(string pdfFilePath,
        string outputFilePath)
    {
        log.Debug($"Start convert PDF to Multipage Tif\nPDF Input: {pdfFilePath}\nTif Output: {outputFilePath}");
        using( var tifWriter = new repositories.MultiPageTIFFWriter())
        using (var pdfReader = new repositories.PDFDocImageReader(pdfFilePath))
        {
            log.Debug($"PDF Read in with {pdfReader.PageCount} pages");
            // add each pdf page to the Tif
            for (int page = 0; page < pdfReader.PageCount; ++page)
            {
                log.Debug($"Processing page {page}");
                byte[] pageImage = pdfReader.getPageAsImage(page);
                log.Debug($"Page {page} image is {pageImage.Length} bytes");
                tifWriter.AddPage(pageImage);
            }
            
            log.Info($"Saving tif file to {outputFilePath}");
            // save it
            tifWriter.SaveToFile(outputFilePath);
        }
    }
    
    
    
}