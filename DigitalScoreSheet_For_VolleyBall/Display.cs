using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalScoreSheet_For_VolleyBall
{
    class Display : INotifyPropertyChanged
    {
        public static Display Instance { get; } = new Display();

        #region OnCourtMember
        private int[] _AMember { get; set; }
        public int[] AMember
        {
            get => _AMember;
            set
            {
                _AMember = value;
                OnPropertyChanged(nameof(AMember));
            }
        }
        private int[] _BMember { get; set; }
        public int[] BMember
        {
            get => _BMember;
            set
            {
                _BMember = value;
                OnPropertyChanged(nameof(BMember));
            }
        }
        #endregion

        #region ButtonEnable
        private bool _AButtonEnable { get; set; }
        public bool AButtonEnable
        {
            get => _AButtonEnable;
            set
            {
                _AButtonEnable = value;
                OnPropertyChanged(nameof(AButtonEnable));
            }
        }
        private bool _BButtonEnable { get; set; }
        public bool BButtonEnable
        {
            get => _BButtonEnable;
            set
            {
                _BButtonEnable = value;
                OnPropertyChanged(nameof(BButtonEnable));
            }
        }
        #endregion

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

        #region TimeOut
        private bool _ATimeOutEnable { get; set; } = true;
        public bool ATimeOutEnable
        {
            get => _ATimeOutEnable;
            set
            {
                _ATimeOutEnable = value;
                OnPropertyChanged(nameof(ATimeOutEnable));
            }
        }

        private bool _BTimeOutEnable { get; set; } = true;
        public bool BTimeOutEnable
        {
            get => _BTimeOutEnable;
            set
            {
                _BTimeOutEnable = value;
                OnPropertyChanged(nameof(BTimeOutEnable));
            }
        }

        private string _ATimeOutIndicator { get; set; } = "TIMEOUT: 〇 〇";
        public string ATimeOutIndicator { get => _ATimeOutIndicator; set { _ATimeOutIndicator = value; OnPropertyChanged(nameof(ATimeOutIndicator)); } }
        private string _BTimeOutIndicator { get; set; } = "〇 〇 :TIMEOUT";
        public string BTimeOutIndicator { get => _BTimeOutIndicator; set { _BTimeOutIndicator = value; OnPropertyChanged(nameof(BTimeOutIndicator)); } }

        #endregion

        #region ServeContext
        private string _AServeContext { get; set; }
        public string AServeContext
        {
            get => _AServeContext;
            set
            {
                _AServeContext = value;
                OnPropertyChanged(nameof(AServeContext));
            }
        }
        private string _BServeContext { get; set; }
        public string BServeContext
        {
            get => _BServeContext;
            set
            {
                _BServeContext = value;
                OnPropertyChanged(nameof(BServeContext));
            }
        }
        #endregion

        #region TeamName
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


        public event PropertyChangedEventHandler PropertyChanged = null;
        protected void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
