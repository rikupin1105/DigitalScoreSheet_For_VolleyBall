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

namespace ScoreBoard_For_VolleyBall.View
{
    /// <summary>
    /// TeamSettingWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class TeamSettingWindow : Window
    {
        public TeamSettingWindow()
        {
            InitializeComponent();

            ATeamName.Text = Display.Instance.ATeamName;
            BTeamName.Text = Display.Instance.BTeamName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (AServe.IsChecked != BServe.IsChecked)
            {
                if (AServe.IsChecked == true)
                {
                    Display.Instance.isAServe = true;
                }
                else
                {
                    Display.Instance.isAServe = false;
                }

                Display.Instance.ATeamName = ATeamName.Text;
                Display.Instance.BTeamName = BTeamName.Text;

                Close();
            }
        }
    }
}
