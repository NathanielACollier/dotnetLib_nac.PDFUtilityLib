using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public class __MSTest_Setup
{
    private static nac.Logging.Logger log = new();
        
    [AssemblyInitialize()]
    public static async Task MyTestInitialize(TestContext testContext)
    {
        nac.Logging.Appenders.Debug.Setup();

        nac.OCR.Tesseract.repositories.Logger.OnNewMessage += (_s, _args) =>
        {
            
        };
        
        log.Info("Tests Starting");
        
    }

    [AssemblyCleanup]
    public static void TearDown()
    {

    }
}
