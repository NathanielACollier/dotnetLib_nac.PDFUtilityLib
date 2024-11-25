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
            nac.Logging.Logger.CreateLogEntry(new LogEntryCreationInfo
            {
                CallingMemberName = _args.CallingMemberName,
                Source = new LoggerSourceInfo(_args.CallerType),
                Level = Ecark.Logging.Logger.getLogLevelFromText(_args.Level),
                MessageText = _args.Message
            });
        };
        
        log.Info("Tests Starting");
        
    }

    [AssemblyCleanup]
    public static void TearDown()
    {

    }
}
