using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ScoreBoard_For_VolleyBall
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
        private string _ATeamName { get; set; } = "ATeam";
        public string ATeamName
        {
            get => _ATeamName;
            set
            {
                _ATeamName = value;
                OnPropertyChanged(nameof(ATeamName));
            }
        }
        private string _BTeamName { get; set; } = "BTeam";
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
        private int _CurrentSet { get; set; } = 1;
        public int CurrentSet
        {
            get => _CurrentSet;
            set
            {
                _CurrentSet = value;
                OnPropertyChanged(nameof(CurrentSet));
            }
        }
        #endregion

        #region Setting

        private bool _PointEnable { get; set; } = true;
        public bool PointEnable
        {
            get => _PointEnable;
            set
            {
                _PointEnable = value;
                OnPropertyChanged(nameof(PointEnable));
            }
        }
        #endregion

        #region Serve
        private bool _isAServe { get; set; }
        public bool isAServe
        { 
            get => _isAServe; 
            set 
            { 
                _isAServe = value; 
                OnPropertyChanged(nameof(isAServe));

                if (_isAServe)
                {
                    AServe = "●";
                    BServe = "";
                }
                else
                {
                    AServe = "";
                    BServe = "●";
                }
            } 
        }


        private string _AServe { get; set; }
        public string AServe { get=>_AServe; set { _AServe = value; OnPropertyChanged(nameof(AServe)); } }

        private string _BServe { get; set; }
        public string BServe { get => _BServe; set { _BServe = value; OnPropertyChanged(nameof(BServe)); } }
        #endregion

        #region SubButton
        private bool _SubButtonEnable { get; set; } = false;
        public bool SubButtonEnable
        {
            get => _SubButtonEnable;
            set
            {
                _SubButtonEnable = value;
                if (value == true)
                {
                    SubButtonOpacity = 100;
                }
                else
                {
                    SubButtonOpacity = 0;
                }
                OnPropertyChanged(nameof(SubButtonEnable));
                OnPropertyChanged(nameof(SubButtonOpacity));
            }
        }
        private int _SubButtonOpacity { get; set; } = 0;
        public int SubButtonOpacity
        {
            get => _SubButtonOpacity;
            set
            {
                _SubButtonOpacity = value;
                OnPropertyChanged(nameof(SubButtonOpacity));
            }
        }

        private bool _SubButton2Enable { get; set; } = false;
        public bool SubButton2Enable
        {
            get => _SubButton2Enable;
            set
            {
                _SubButton2Enable = value;
                if (value == true)
                {
                    SubButton2Opacity = 100;
                }
                else
                {
                    SubButton2Opacity = 0;
                }
                OnPropertyChanged(nameof(SubButton2Enable));
                OnPropertyChanged(nameof(SubButton2Opacity));
            }
        }
        private int _SubButton2Opacity { get; set; } = 0;
        public int SubButton2Opacity
        {
            get => _SubButton2Opacity;
            set
            {
                _SubButton2Opacity = value;
                OnPropertyChanged(nameof(SubButton2Opacity));
            }
        }
        #endregion

        private bool _LastSetCourtChange { get; set; } = false;
        public bool LastSetCourtChange
        {
            get => _LastSetCourtChange;
            set
            {
                _LastSetCourtChange = value;
                OnPropertyChanged(nameof(LastSetCourtChange));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = null;
        protected void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
