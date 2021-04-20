using Prism.Commands;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DigitalScoreSheet_For_VolleyBall.View;

namespace DigitalScoreSheet_For_VolleyBall.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ReadOnlyReactiveProperty<bool> ATimeOutEnable { get; }
        public ReadOnlyReactiveProperty<bool> BTimeOutEnable { get; }
        public ReadOnlyReactiveProperty<string> AServeContext { get; }
        public ReadOnlyReactiveProperty<string> BServeContext { get; }
        public ReadOnlyReactiveProperty<int> APoint { get; }
        public ReadOnlyReactiveProperty<int> BPoint { get; }
        public ReadOnlyReactiveProperty<bool> AButtonEnable { get; }
        public ReadOnlyReactiveProperty<bool> BButtonEnable { get; }
        public ReadOnlyReactiveProperty<int[]> AMember { get; }
        public ReadOnlyReactiveProperty<int[]> BMember { get; }
        public ReadOnlyReactiveProperty<string> ATimeOutIndicator { get; }
        public ReadOnlyReactiveProperty<string> BTimeOutIndicator { get; }
        public ReadOnlyReactiveProperty<string> ATeamName { get; }
        public ReadOnlyReactiveProperty<string> BTeamName { get; }
        public ReadOnlyReactiveProperty<int> ATeamSet { get; }
        public ReadOnlyReactiveProperty<int> BTeamSet { get; }
        public ReadOnlyReactiveProperty<bool> SettingEnable { get; }

        public MainWindowViewModel()
        {
            ATimeOutEnable = Display.Instance.ObserveProperty(x => x.ATimeOutEnable).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            BTimeOutEnable = Display.Instance.ObserveProperty(x => x.BTimeOutEnable).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));

            AServeContext = Display.Instance.ObserveProperty(x => x.AServeContext).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            BServeContext = Display.Instance.ObserveProperty(x => x.BServeContext).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));

            APoint = Display.Instance.ObserveProperty(x => x.APoint).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            BPoint = Display.Instance.ObserveProperty(x => x.BPoint).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));

            AButtonEnable = Display.Instance.ObserveProperty(x => x.AButtonEnable).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            BButtonEnable = Display.Instance.ObserveProperty(x => x.BButtonEnable).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));

            AMember = Display.Instance.ObserveProperty(x => x.AMember).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            BMember = Display.Instance.ObserveProperty(x => x.BMember).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));

            ATimeOutIndicator = Display.Instance.ObserveProperty(x => x.ATimeOutIndicator).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            BTimeOutIndicator = Display.Instance.ObserveProperty(x => x.BTimeOutIndicator).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));

            ATeamName = Display.Instance.ObserveProperty(x => x.ATeamName).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            BTeamName = Display.Instance.ObserveProperty(x => x.BTeamName).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));

            ATeamSet = Display.Instance.ObserveProperty(x => x.ATeamSet).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            BTeamSet = Display.Instance.ObserveProperty(x => x.BTeamSet).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));

            SettingEnable = Display.Instance.ObserveProperty(x => x.SettingEnable).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));


            //Command
            AServeCommand.Subscribe(_ => AServe());
            BServeCommand.Subscribe(_ => BServe());
            ATimeOutCommand.Subscribe(_ => ATimeOut());
            BTimeOutCommand.Subscribe(_ => BTimeOut());
            SettingButtonCommand.Subscribe(_ => SettingWindow());
            ATeamLineUpCommand.Subscribe(_ => ALineUp());
            BTeamLineUpCommand.Subscribe(_ => BLineUp());
        }
        public ReactiveCommand AServeCommand { get; } = new ReactiveCommand();
        public ReactiveCommand BServeCommand { get; } = new ReactiveCommand();
        public ReactiveCommand ATimeOutCommand { get; } = new ReactiveCommand();
        public ReactiveCommand BTimeOutCommand { get; } = new ReactiveCommand();
        public ReactiveCommand SettingButtonCommand { get; } = new ReactiveCommand();
        public ReactiveCommand ATeamLineUpCommand { get; } = new ReactiveCommand();
        public ReactiveCommand BTeamLineUpCommand { get; } = new ReactiveCommand();


        private void SettingWindow()
        {
            var window = new TeamSettingWindow();
            window.Show();
        }
        private void ALineUp()
        {
            var window = new ATeamRotationWindow();
            window.Show();
        }
        private void BLineUp()
        {
            var window = new BTeamRotationWindow();
            window.Show();
        }


        private bool CurrentGame { get; set; } = true;


        


        private bool Aserve = true;
        private void AServe()
        {
            if (CurrentGame)
            {
                //InGame
                CurrentGame = false;
                Display.Instance.AServeContext = "POINT";
                Display.Instance.BServeContext = "POINT";
                Display.Instance.AButtonEnable = true;
                Display.Instance.BButtonEnable = true;
                Display.Instance.ATimeOutEnable = false;
                Display.Instance.BTimeOutEnable = false;
                Display.Instance.SettingEnable = false;
            }
            else
            {
                //GetPoint
                Display.Instance.APoint++;

                CurrentGame = true;
                Display.Instance.AServeContext = "SERVE";
                Display.Instance.BServeContext = "";
                Display.Instance.BButtonEnable = false;
                Display.Instance.SettingEnable = true;
                if (!Aserve)
                {
                    ARotation();
                }
                Aserve = true;
                if (ATimeOutCount < 2)
                {
                    Display.Instance.ATimeOutEnable = true;
                }
                if (BTimeOutCount < 2)
                {
                    Display.Instance.BTimeOutEnable = true;
                }
            }
        }
        private void BServe()
        {
            if (CurrentGame)
            {
                //InGame
                CurrentGame = false;
                Display.Instance.BServeContext = "POINT";
                Display.Instance.AServeContext = "POINT";
                Display.Instance.AButtonEnable = true;
                Display.Instance.BButtonEnable = true;
                Display.Instance.ATimeOutEnable = false;
                Display.Instance.BTimeOutEnable = false;
                Display.Instance.SettingEnable = false;
            }
            else
            {
                //GetPoint
                Display.Instance.BPoint++;
                CurrentGame = true;
                Display.Instance.AServeContext = "";
                Display.Instance.BServeContext = "SERVE";
                Display.Instance.AButtonEnable = false;
                Display.Instance.SettingEnable = true;
                if (Aserve)
                {
                    BRotation();
                }
                Aserve = false;
                if (ATimeOutCount < 2)
                {
                    Display.Instance.ATimeOutEnable = true;
                }
                if (BTimeOutCount < 2)
                {
                    Display.Instance.BTimeOutEnable = true;
                }
            }
        }


       
        private void ARotation()
        {
            var member = new int[6];
            member[0] = Display.Instance.AMember[1];
            member[1] = Display.Instance.AMember[2];
            member[2] = Display.Instance.AMember[3];
            member[3] = Display.Instance.AMember[4];
            member[4] = Display.Instance.AMember[5];
            member[5] = Display.Instance.AMember[0];
            Display.Instance.AMember = member;
        }
        private void BRotation()
        {
            var member = new int[6];
            member[0] = Display.Instance.BMember[1];
            member[1] = Display.Instance.BMember[2];
            member[2] = Display.Instance.BMember[3];
            member[3] = Display.Instance.BMember[4];
            member[4] = Display.Instance.BMember[5];
            member[5] = Display.Instance.BMember[0];
            Display.Instance.BMember = member;
        }



        private int ATimeOutCount { get; set; } = 0;
        private int BTimeOutCount { get; set; } = 0;

        private void ATimeOut()
        {
            BTimeOutCount++;

            TimeWindow t = new TimeWindow();
            t.Show();

            ATimeOutCount++;
            if (ATimeOutCount >= 2)
            {
                Display.Instance.ATimeOutEnable = false;
            }

            if (ATimeOutCount == 1)
            {
                Display.Instance.ATimeOutIndicator = "TIMEOUT: ● 〇";
            }
            if (ATimeOutCount == 2)
            {
                Display.Instance.ATimeOutIndicator = "TIMEOUT: ● ●";
            }
        }
        private void BTimeOut()
        {
            BTimeOutCount++;
            TimeWindow t = new TimeWindow();
            t.Show();

            if (BTimeOutCount >= 2)
            {
                Display.Instance.BTimeOutEnable = false;
            }
            if (BTimeOutCount == 1)
            {
                Display.Instance.BTimeOutIndicator = "● 〇 :TIMEOUT";
            }
            if (BTimeOutCount == 2)
            {
                Display.Instance.BTimeOutIndicator = "● ● :TIMEOUT";
            }
        }







        public event PropertyChangedEventHandler PropertyChanged = null;
        protected void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
