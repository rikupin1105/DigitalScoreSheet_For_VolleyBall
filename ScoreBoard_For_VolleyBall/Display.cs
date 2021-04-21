using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DigitalScoreSheet_For_VolleyBall
{
    class Display : INotifyPropertyChanged
    {
        public static Display Instance { get; } = new Display();



        #region Point
        private int _APoint { get; set; }
        public int APoint
        {
            get => _APoint; set
            {
                _APoint = value;
                OnPropertyChanged(nameof(APoint));
            }
        }
        private int _BPoint { get; set; }
        public int BPoint
        {
            get => _BPoint; set
            {
                _BPoint = value;
                OnPropertyChanged(nameof(BPoint));
            }
        }
        #endregion

        #region Team
        private string _ATeamName { get; set; }
        public string ATeamName
        {
            get => _ATeamName;
            set
            {
                _ATeamName = value;
                OnPropertyChanged(nameof(ATeamName));
            }
        }
        private string _BTeamName { get; set; }
        public string BTeamName
        {
            get => _BTeamName;
            set
            {
                _BTeamName = value;
                OnPropertyChanged(nameof(BTeamName));
            }
        }
        #endregion

        #region Set
        private int _ATeamSet { get; set; } = 0;
        public int ATeamSet
        {
            get => _ATeamSet;
            set
            {
                _ATeamSet = value;
                OnPropertyChanged(nameof(ATeamSet));
            }
        }
        private int _BTeamSet { get; set; } = 0;
        public int BTeamSet
        {
            get => _BTeamSet;
            set
            {
                _BTeamSet = value;
                OnPropertyChanged(nameof(BTeamSet));
            }
        }
        #endregion

        #region Setting
        private bool _SettingEnable { get; set; } = true;
        public bool SettingEnable
        {
            get => _SettingEnable;
            set
            {
                _SettingEnable = value;
                OnPropertyChanged(nameof(SettingEnable));
            }
        }
        #endregion

        #region Serve
        private string _AServe { get; set; }
        public string AServe { get=>_AServe; set { _AServe = value; OnPropertyChanged(nameof(AServe)); } }

        private string _BServe { get; set; }
        public string BServe { get => _BServe; set { _BServe = value; OnPropertyChanged(nameof(BServe)); } }
        #endregion



        public event PropertyChangedEventHandler PropertyChanged = null;
        protected void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
