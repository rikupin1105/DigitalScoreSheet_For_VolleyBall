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
    /// BTeamRotationWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class BTeamRotationWindow : Window
    {
        public BTeamRotationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var member = new int[6];
            member[0] = int.Parse(Position1.Text);
            member[1] = int.Parse(Position2.Text);
            member[2] = int.Parse(Position3.Text);
            member[3] = int.Parse(Position4.Text);
            member[4] = int.Parse(Position5.Text);
            member[5] = int.Parse(Position6.Text);
            Display.Instance.BMember = member;
            Close();
        }
    }
}
