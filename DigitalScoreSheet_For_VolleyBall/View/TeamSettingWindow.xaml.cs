using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DigitalScoreSheet_For_VolleyBall.View
{
    /// <summary>
    /// TeamSettingWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class TeamSettingWindow : Window
    {
        public TeamSettingWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(ATeamName.Text) && !string.IsNullOrEmpty(BTeamName.Text))
            {
                if (AServe.IsChecked != BServe.IsChecked)
                {
                    if (AServe.IsChecked == true)
                    {
                        Display.Instance.AServeContext = "SERVE";
                        Display.Instance.BServeContext = "";
                        Display.Instance.AButtonEnable = true;
                        Display.Instance.BButtonEnable = false;
                    }
                    else
                    {
                        Display.Instance.AServeContext = "";
                        Display.Instance.BServeContext = "SERVE";
                        Display.Instance.AButtonEnable = false;
                        Display.Instance.BButtonEnable = true;
                    }
                }
                Display.Instance.ATeamName = ATeamName.Text;
                Display.Instance.BTeamName = BTeamName.Text;
                this.Close();
            }
        }
    }
}
