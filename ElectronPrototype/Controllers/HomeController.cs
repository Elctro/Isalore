using System.Diagnostics;
using System.Linq;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ElectronPrototype.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (HybridSupport.IsElectronActive)
                Electron.IpcMain.On("select-directory", async args =>
                {
                    var mainWindow = Electron.WindowManager.BrowserWindows.First();
                    var options = new OpenDialogOptions
                    {
                        Properties = new[]
                        {
                            OpenDialogProperty.openFile
                        }
                    };

                    object[] files = await Electron.Dialog.ShowOpenDialogAsync(mainWindow, options);
                    foreach (var file in files)
                        if (file is string path)
                            Process.Start("notepad.exe", path);
                    Electron.IpcMain.Send(mainWindow, "select-directory-reply", files);
                });
            return View();
        }
    }
}