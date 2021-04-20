using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DigitalScoreSheet_For_VolleyBall.View;

namespace DigitalScoreSheet_For_VolleyBall
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        private static MainWindow objMainWindow;
        private static StreamingWindow objMainWindow2;
        private static ScoreBoardWindow objMainWindow3;
        protected override void OnStartup(StartupEventArgs e)
        {
            objMainWindow = new MainWindow();
            //objMainWindow2 = new StreamingWindow();
            // = new ScoreBoardWindow();
            objMainWindow.Show();
            //objMainWindow2.Show();
            //objMainWindow3.Show();
        }
    }
}
