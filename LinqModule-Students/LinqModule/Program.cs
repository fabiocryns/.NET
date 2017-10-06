using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LinqModule.ServiceLocation;
using LinqModule.Model;

namespace LinqModule {
    public class Program {
        [STAThreadAttribute()]
        public static void Main() {
            var app = new LinqModule.App();
            app.Startup += App_Startup;
            var mainWindow = ServiceLocator.Resolve<Window>(ViewNames.MainWindow);
            mainWindow.DataContext = ServiceLocator.Resolve<IMainWindowViewModel>();
            app.Run(mainWindow);
        }

        private static void App_Startup(object sender, StartupEventArgs e) {
            var splashScreen = new SplashScreen("Resources/logo.jpg");
            splashScreen.Show(true);
        }
    }
}
