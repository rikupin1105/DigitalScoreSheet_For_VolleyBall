using ScoreBoard_For_VolleyBall.ViewModel;
using System;
using System.Windows;

namespace ScoreBoard_For_VolleyBall.View
{
    public partial class GameSettingWindow : Window
    {
        public GameSettingWindow()
        {
            InitializeComponent();

            WinPoint.Text = GameWindowViewModel.Rule.WinPoint.ToString();
            WinPointFinal.Text = GameWindowViewModel.Rule.FinalSetWinPoint.ToString();
            ChangePoint.Text = GameWindowViewModel.Rule.FinalSetCourtChangePoint.ToString();
            Set.Text = GameWindowViewModel.Rule.Match.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Set.Text))
            {
                if (!string.IsNullOrEmpty(WinPoint.Text))
                {
                    if (!string.IsNullOrEmpty(WinPointFinal.Text))
                    {
                        if (!string.IsNullOrEmpty(ChangePoint.Text))
                        {
                            try
                            {
                                GameWindowViewModel.Rule.WinPoint = int.Parse(WinPoint.Text);
                                GameWindowViewModel.Rule.FinalSetWinPoint = int.Parse(WinPointFinal.Text);
                                GameWindowViewModel.Rule.FinalSetCourtChangePoint = int.Parse(ChangePoint.Text);
                                GameWindowViewModel.Rule.Match = int.Parse(Set.Text);
                                Close();
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                    }
                }
            }
        }
    }
}
