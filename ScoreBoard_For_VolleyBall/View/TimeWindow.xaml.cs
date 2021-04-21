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
using System.Windows.Threading;

namespace DigitalScoreSheet_For_VolleyBall.View
{
    /// <summary>
    /// TimeWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class TimeWindow : Window
    {
        private readonly DispatcherTimer _timer;
        private TimeSpan _time;
        public TimeWindow()
        {
            InitializeComponent();

            _time = TimeSpan.FromSeconds(30);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                Time.Text = _time.ToString("ss");
                if (_time == TimeSpan.Zero)
                {
                    _timer.Stop();
                    Close();
                }

                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();
        }
    }
}
