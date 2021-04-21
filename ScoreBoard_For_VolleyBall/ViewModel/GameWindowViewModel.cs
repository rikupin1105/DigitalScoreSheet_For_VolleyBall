using DigitalScoreSheet_For_VolleyBall.View;
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
using System.Windows.Media;

namespace DigitalScoreSheet_For_VolleyBall.ViewModel
{
    public class GameWindowViewModel : INotifyPropertyChanged
    {
        public ReadOnlyReactiveProperty<int> APoint { get; }
        public ReadOnlyReactiveProperty<int> BPoint { get; }
        public ReadOnlyReactiveProperty<string> ATeamName { get; }
        public ReadOnlyReactiveProperty<string> BTeamName { get; }
        public ReadOnlyReactiveProperty<int> ATeamSet { get; }
        public ReadOnlyReactiveProperty<int> BTeamSet { get; }
        public ReadOnlyReactiveProperty<bool> SettingEnable { get; }
        public GameWindowViewModel()
        {
            APoint = Display.Instance.ObserveProperty(x => x.APoint).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            BPoint = Display.Instance.ObserveProperty(x => x.BPoint).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));

            ATeamName = Display.Instance.ObserveProperty(x => x.ATeamName).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            BTeamName = Display.Instance.ObserveProperty(x => x.BTeamName).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));

            ATeamSet = Display.Instance.ObserveProperty(x => x.ATeamSet).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            BTeamSet = Display.Instance.ObserveProperty(x => x.BTeamSet).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));

            SettingEnable = Display.Instance.ObserveProperty(x => x.SettingEnable).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));

            //Command
            APointCommand.Subscribe(_ => APointAdd());
            BPointCommand.Subscribe(_ => BPointAdd());
            SettingButtonCommand.Subscribe(_ => SettingWindow());
            UndoCommand.Subscribe(_ => Undo());
        }
        public ReactiveCommand APointCommand { get; } = new ReactiveCommand();
        public ReactiveCommand BPointCommand { get; } = new ReactiveCommand();
        public ReactiveCommand SettingButtonCommand { get; } = new ReactiveCommand();
        public ReactiveCommand UndoCommand { get; } = new ReactiveCommand();


        private void SettingWindow()
        {
            var window = new TeamSettingWindow();
            window.Show();
        }

        private readonly List<HisDate> History = new List<HisDate>()
        {
            new HisDate()
            {
                APoint = 0,
                BPoint = 0,
                ASet = 0,
                BSet = 0,
                AServe = "",
                BServe = ""
            }
        };
        private void Undo()
        {
            var i = Math.Max(0, History.Count() - 2);

            if (History.Count > 1 )
            {
                History.RemoveAt(Math.Max(0, History.Count() - 1));

                Display.Instance.APoint = History[i].APoint;
                Display.Instance.BPoint = History[i].BPoint;

                Display.Instance.AServe = History[i].AServe;
                Display.Instance.BServe = History[i].BServe;

                Display.Instance.ATeamSet = History[i].ASet;
                Display.Instance.BTeamSet = History[i].BSet;
            }
        }

        private class HisDate
        {
            public int APoint { get; set; }
            public int BPoint { get; set; }
            public int ASet { get; set; }
            public int BSet { get; set; }
            public string AServe { get; set; }
            public string BServe { get; set; }
        }



        private void APointAdd()
        {
            //GetPoint
            Display.Instance.APoint++;
            Display.Instance.SettingEnable = true;
            Display.Instance.AServe = "●";
            Display.Instance.BServe = "";

            History.Add(new HisDate()
            {
                APoint = Display.Instance.APoint,
                BPoint = Display.Instance.BPoint,
                AServe = Display.Instance.AServe,
                BServe = Display.Instance.BServe,
                ASet = Display.Instance.ATeamSet,
                BSet = Display.Instance.BTeamSet
            });
        }
        private void BPointAdd()
        {
            //GetPoint
            Display.Instance.BPoint++;
            Display.Instance.SettingEnable = true;
            Display.Instance.AServe = "";
            Display.Instance.BServe = "●";

            History.Add(new HisDate()
            {
                APoint = Display.Instance.APoint,
                BPoint = Display.Instance.BPoint,
                AServe = Display.Instance.AServe,
                BServe = Display.Instance.BServe,
                ASet = Display.Instance.ATeamSet,
                BSet = Display.Instance.BTeamSet
            });
        }




        public event PropertyChangedEventHandler PropertyChanged = null;
        protected void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
