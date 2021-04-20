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


            ATeamName.Text = Display.Instance.ATeamName;
            BTeamName.Text = Display.Instance.BTeamName;

            if (Display.Instance.AMember != null)
            {
                APosition1.Text = Display.Instance.AMember[0].ToString();
                APosition2.Text = Display.Instance.AMember[1].ToString();
                APosition3.Text = Display.Instance.AMember[2].ToString();
                APosition4.Text = Display.Instance.AMember[3].ToString();
                APosition5.Text = Display.Instance.AMember[4].ToString();
                APosition6.Text = Display.Instance.AMember[5].ToString();
            }
            if (Display.Instance.BMember != null)
            {
                BPosition1.Text = Display.Instance.BMember[0].ToString();
                BPosition2.Text = Display.Instance.BMember[1].ToString();
                BPosition3.Text = Display.Instance.BMember[2].ToString();
                BPosition4.Text = Display.Instance.BMember[3].ToString();
                BPosition5.Text = Display.Instance.BMember[4].ToString();
                BPosition6.Text = Display.Instance.BMember[5].ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
                    Display.Instance.AServeContext = "SERVE";
                    Display.Instance.BServeContext = "SERVE";
                    Display.Instance.AButtonEnable = false;
                    Display.Instance.BButtonEnable = true;
                }

                Display.Instance.ATeamName = ATeamName.Text;
                Display.Instance.BTeamName = BTeamName.Text;

                var Amember = new int[6];
                var Bmember = new int[6];
                try
                {
                    Amember[0] = int.Parse(APosition1.Text);
                    Amember[1] = int.Parse(APosition2.Text);
                    Amember[2] = int.Parse(APosition3.Text);
                    Amember[3] = int.Parse(APosition4.Text);
                    Amember[4] = int.Parse(APosition5.Text);
                    Amember[5] = int.Parse(APosition6.Text);
                    Bmember[0] = int.Parse(BPosition1.Text);
                    Bmember[1] = int.Parse(BPosition2.Text);
                    Bmember[2] = int.Parse(BPosition3.Text);
                    Bmember[3] = int.Parse(BPosition4.Text);
                    Bmember[4] = int.Parse(BPosition5.Text);
                    Bmember[5] = int.Parse(BPosition6.Text);

                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = i + 1; j < 6; j++)
                        {
                            if (Amember[i] == Amember[j])
                            {
                                MessageBox.Show("There are duplicate numbers.", " ");
                                return;
                            }
                            if (Bmember[i] == Bmember[j])
                            {
                                MessageBox.Show("There are duplicate numbers.", " ");
                                return;
                            }
                        }
                    }


                    Display.Instance.AMember = Amember;
                    Display.Instance.BMember = Bmember;
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please enter in numbers.", " ");
                }
            }
        }
    }
}
