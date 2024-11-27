using System.IO;

namespace nac.PDFUtilityLib.repositories;

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



    public static void ConvertMultipageTifToPDF(string tifFilePath,
        string pdfOutputFilePath)
    {
        log.Debug($"Start converting Multipage Tif to PDF\nMultipage Tif input: {tifFilePath}\nPDF Output: {pdfOutputFilePath}");
        
        using( var tifReader = new repositories.MultiPageTIFFReader(tifFilePath))
        using (var pdfWriter = new repositories.MultiPageTIFFWriter())
        {
            log.Debug($"Tif read in with {tifReader.PageCount} pages");
            for (int page = 0; page < tifReader.PageCount; ++page)
            {
                log.Debug($"Processing page {page}");
                byte[] pageImage = tifReader.GetPageBitMap(page);
                log.Debug($"Page {page} image is {pageImage.Length} bytes");
                pdfWriter.AddPage(pageImage);
            }
            
            log.Info($"Saving tif file to {pdfOutputFilePath}");
            pdfWriter.SaveToFile(pdfOutputFilePath);
        }
    }
    
    
    
}