using System;
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
                    foreach (var file in files.OfType<string>())
                        switch (Program.OperatingSystem)
                        {
                            case OperatingSystem.Windows:
                                Process.Start("notepad.exe", file);
                                break;
                            case OperatingSystem.Linux:
                                Process.Start("nano", file);//TODO add extension of Vim
                                break;
                            case OperatingSystem.Osx:
                                Process.Start("TextEdit", file);//TODO add extension of TextEdit
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    Electron.IpcMain.Send(mainWindow, "select-directory-reply", files);
                });
            return View();
        }
    }
}