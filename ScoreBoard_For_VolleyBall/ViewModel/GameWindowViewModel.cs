using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using ScoreBoard_For_VolleyBall.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Threading;

namespace ScoreBoard_For_VolleyBall.ViewModel
{
    public class GameWindowViewModel
    {
        public ReadOnlyReactiveProperty<int> APoint { get; }
        public ReadOnlyReactiveProperty<int> BPoint { get; }
        public ReadOnlyReactiveProperty<string> ATeamName { get; }
        public ReadOnlyReactiveProperty<string> BTeamName { get; }
        public ReadOnlyReactiveProperty<int> ATeamSet { get; }
        public ReadOnlyReactiveProperty<int> BTeamSet { get; }
        public ReadOnlyReactiveProperty<bool> PointEnable { get; }
        public ReadOnlyReactiveProperty<bool> SubButtonEnable { get; }
        public ReadOnlyReactiveProperty<int> SubButtonOpacity { get; }
        public ReadOnlyReactiveProperty<bool> SubButton2Enable { get; }
        public ReadOnlyReactiveProperty<int> SubButton2Opacity { get; }
        public ReadOnlyReactiveProperty<int> CurrentSet { get; }
        public ReadOnlyReactiveProperty<bool> isAServe { get; }
        public ReadOnlyReactiveProperty<bool> LastSetCourtChange { get; }
        public ReadOnlyReactiveProperty<string> AServe { get; }
        public ReadOnlyReactiveProperty<string> BServe { get; }
        public GameWindowViewModel()
        {
            APoint = Display.Instance.ObserveProperty(x => x.APoint).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            BPoint = Display.Instance.ObserveProperty(x => x.BPoint).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));

            ATeamName = Display.Instance.ObserveProperty(x => x.ATeamName).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            BTeamName = Display.Instance.ObserveProperty(x => x.BTeamName).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));

            ATeamSet = Display.Instance.ObserveProperty(x => x.ATeamSet).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            BTeamSet = Display.Instance.ObserveProperty(x => x.BTeamSet).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));

            isAServe = Display.Instance.ObserveProperty(x => x.isAServe).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            CurrentSet = Display.Instance.ObserveProperty(x => x.CurrentSet).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            PointEnable = Display.Instance.ObserveProperty(x => x.PointEnable).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            SubButtonEnable = Display.Instance.ObserveProperty(x => x.SubButtonEnable).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            SubButtonOpacity = Display.Instance.ObserveProperty(x => x.SubButtonOpacity).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            SubButton2Enable = Display.Instance.ObserveProperty(x => x.SubButton2Enable).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            SubButton2Opacity = Display.Instance.ObserveProperty(x => x.SubButton2Opacity).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            LastSetCourtChange = Display.Instance.ObserveProperty(x => x.LastSetCourtChange).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));

            AServe = Display.Instance.ObserveProperty(x => x.AServe).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            BServe = Display.Instance.ObserveProperty(x => x.BServe).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));

            //Command
            APointCommand.Subscribe(_ => APointAdd());
            BPointCommand.Subscribe(_ => BPointAdd());
            SettingButtonCommand.Subscribe(_ => SettingWindow());
            UndoCommand.Subscribe(_ => Undo());
            NextSetCommand.Subscribe(_ => NextSet());
            FinalSetCourtChangeCommand.Subscribe(_ => FinalSetCourtChange());
            CourtChangeCommand.Subscribe(_ => CourtChange());
            SwitchServerCommand.Subscribe(_ => SwitchServer());

            StreaminWindowCommand.Subscribe(_ => new StreamingWindow().Show());
            ScoreBoard1Command.Subscribe(_ => new ScoreBoardWindow().Show());
            ScoreBoard2Command.Subscribe(_ => new ScoreBoardWindow2().Show());
            GameSettingCommand.Subscribe(_ => GameSetting());
        }
        public ReactiveCommand APointCommand { get; } = new ReactiveCommand();
        public ReactiveCommand BPointCommand { get; } = new ReactiveCommand();
        public ReactiveCommand SettingButtonCommand { get; } = new ReactiveCommand();
        public ReactiveCommand UndoCommand { get; } = new ReactiveCommand();
        public ReactiveCommand NextSetCommand { get; } = new ReactiveCommand();
        public ReactiveCommand CourtChangeCommand { get; } = new ReactiveCommand();
        public ReactiveCommand FinalSetCourtChangeCommand { get; } = new ReactiveCommand();
        public ReactiveCommand SwitchServerCommand { get; } = new ReactiveCommand();
        public ReactiveCommand StreaminWindowCommand { get; } = new ReactiveCommand();
        public ReactiveCommand ScoreBoard1Command { get; } = new ReactiveCommand();
        public ReactiveCommand ScoreBoard2Command { get; } = new ReactiveCommand();
        public ReactiveCommand GameSettingCommand { get; } = new ReactiveCommand();

        private void GameSetting()
        {
            if (Display.Instance.APoint == 0&&Display.Instance.BPoint==0)
            {
                if (Display.Instance.ATeamSet == 0 && Display.Instance.BTeamSet == 0)
                {
                    new GameSettingWindow().Show();
                }
            }
        }
        private void SwitchServer()
        {
            if (Display.Instance.isAServe)
            {
                Display.Instance.isAServe = false;
            }
            else
            {
                Display.Instance.isAServe = true;
            }
        }

        private void SettingWindow()
        {
            var window = new TeamSettingWindow();
            window.Show();
        }

        static public class Rule
        {
            static public int Match = 5;
            static public int WinPoint = 25;
            static public int FinalSetWinPoint = 15;
            static public int FinalSetCourtChangePoint = 8;
        }

        private readonly List<HisDate> History = new List<HisDate>()
        {
            new HisDate()
            {
                APoint = 0,
                BPoint = 0,
                ASet = 0,
                BSet = 0,
                isAServe = true,
                LastSetChangeCourt = false,
                CurrentSet = 1,
                AName="ATeam",
                BName="BTeam",
                PointButtonEnable=true,
                SubButton1Enable=false,
                SubButton2Enable=false
            }
        };
        private void Undo()
        {
            var i = Math.Max(0, History.Count() - 2);

            if (History.Count > 1)
            {
                History.RemoveAt(Math.Max(0, History.Count() - 1));

                Display.Instance.APoint = History[i].APoint;
                Display.Instance.BPoint = History[i].BPoint;

                Display.Instance.ATeamName = History[i].AName;
                Display.Instance.BTeamName = History[i].BName;

                Display.Instance.isAServe = History[i].isAServe;

                Display.Instance.ATeamSet = History[i].ASet;
                Display.Instance.BTeamSet = History[i].BSet;

                Display.Instance.CurrentSet = History[i].CurrentSet;

                Display.Instance.LastSetCourtChange = History[i].LastSetChangeCourt;

                Display.Instance.PointEnable = History[i].PointButtonEnable;
                Display.Instance.SubButtonEnable = History[i].SubButton1Enable;
                Display.Instance.SubButton2Enable = History[i].SubButton2Enable;

            }
        }

        private class HisDate
        {
            public int APoint { get; set; }
            public int BPoint { get; set; }
            public int ASet { get; set; }
            public int BSet { get; set; }
            public bool isAServe { get; set; }
            public string AName { get; set; }
            public string BName { get; set; }
            public int CurrentSet { get; set; }
            public bool LastSetChangeCourt { get; set; }
            public bool PointButtonEnable { get; set; }
            public bool SubButton1Enable { get; set; }
            public bool SubButton2Enable { get; set; }
        }

        private void NextSet()
        {
            Display.Instance.APoint = 0;
            Display.Instance.BPoint = 0;
            Display.Instance.CurrentSet++;
            Display.Instance.PointEnable = true;

            if (Display.Instance.CurrentSet != Rule.Match)
            {
                CourtChange();
            }






            Display.Instance.SubButtonEnable = false;
            History.Add(new HisDate()
            {
                APoint = Display.Instance.APoint,
                BPoint = Display.Instance.BPoint,
                isAServe = Display.Instance.isAServe,
                ASet = Display.Instance.ATeamSet,
                BSet = Display.Instance.BTeamSet,
                AName = Display.Instance.ATeamName,
                BName = Display.Instance.BTeamName,
                CurrentSet = Display.Instance.CurrentSet,
                LastSetChangeCourt = Display.Instance.LastSetCourtChange
            });
        }
        private void FinalSetCourtChange()
        {
            Display.Instance.PointEnable = true;
            Display.Instance.LastSetCourtChange = true;

            CourtChange();
            Display.Instance.SubButton2Enable = false;

            History.Add(new HisDate()
            {
                APoint = Display.Instance.APoint,
                BPoint = Display.Instance.BPoint,
                isAServe = Display.Instance.isAServe,
                ASet = Display.Instance.ATeamSet,
                BSet = Display.Instance.BTeamSet,
                AName = Display.Instance.ATeamName,
                BName = Display.Instance.BTeamName,
                CurrentSet = Display.Instance.CurrentSet,
                LastSetChangeCourt = Display.Instance.LastSetCourtChange,
                PointButtonEnable = Display.Instance.PointEnable,
                SubButton1Enable = Display.Instance.SubButtonEnable,
                SubButton2Enable = Display.Instance.SubButton2Enable
            });
        }
        private void CourtChange()
        {
            var tmp = Display.Instance.ATeamName;
            Display.Instance.ATeamName = Display.Instance.BTeamName;
            Display.Instance.BTeamName = tmp;

            var tmp1 = Display.Instance.ATeamSet;
            Display.Instance.ATeamSet = Display.Instance.BTeamSet;
            Display.Instance.BTeamSet = tmp1;

            var tmp2 = Display.Instance.APoint;
            Display.Instance.APoint = Display.Instance.BPoint;
            Display.Instance.BPoint = tmp2;
        }


        private void APointAdd()
        {
            //GetPoint
            Display.Instance.APoint++;

            //ChangeServer
            Display.Instance.isAServe = true;

            if (Display.Instance.APoint >= Rule.WinPoint && Display.Instance.APoint - Display.Instance.BPoint >= Rule.Match/2 && Display.Instance.CurrentSet != Rule.Match)
            {
                Display.Instance.ATeamSet++;
                Display.Instance.PointEnable = false;
                Display.Instance.SubButtonEnable = true;

                if (Display.Instance.ATeamSet == 3)
                {
                    Display.Instance.PointEnable = false;
                    Display.Instance.SubButtonEnable = false;
                    Display.Instance.SubButton2Enable = false;
                }
            }
            else if (Display.Instance.APoint >= Rule.FinalSetWinPoint && Display.Instance.APoint - Display.Instance.BPoint >= 2 && Display.Instance.CurrentSet == Rule.Match)
            {
                Display.Instance.ATeamSet++;
                Display.Instance.PointEnable = false;
                Display.Instance.SubButtonEnable = false;
                Display.Instance.SubButton2Enable = false;
            }
            else if (Display.Instance.APoint == Rule.FinalSetCourtChangePoint && Display.Instance.APoint > Display.Instance.BPoint && Display.Instance.CurrentSet == Rule.Match)
            {
                Display.Instance.SubButton2Enable = true;
                Display.Instance.PointEnable = false;
            }

            History.Add(new HisDate()
            {
                APoint = Display.Instance.APoint,
                BPoint = Display.Instance.BPoint,
                isAServe = Display.Instance.isAServe,
                ASet = Display.Instance.ATeamSet,
                BSet = Display.Instance.BTeamSet,
                AName = Display.Instance.ATeamName,
                BName = Display.Instance.BTeamName,
                CurrentSet = Display.Instance.CurrentSet,
                LastSetChangeCourt = Display.Instance.LastSetCourtChange,
                PointButtonEnable = Display.Instance.PointEnable,
                SubButton1Enable = Display.Instance.SubButtonEnable,
                SubButton2Enable = Display.Instance.SubButton2Enable
            });
        }
        private void BPointAdd()
        {
            //GetPoint
            Display.Instance.BPoint++;

            //ChangeServer
            Display.Instance.isAServe = false;

            if (Display.Instance.BPoint >= Rule.WinPoint && Display.Instance.BPoint - Display.Instance.APoint >= Rule.Match/2 && Display.Instance.CurrentSet != Rule.Match)
            {
                //25点に到達したとき
                Display.Instance.BTeamSet++;
                Display.Instance.PointEnable = false;
                Display.Instance.SubButtonEnable = true;

                if (Display.Instance.BTeamSet == 3)
                {
                    Display.Instance.PointEnable = false;
                    Display.Instance.SubButtonEnable = false;
                    Display.Instance.SubButton2Enable = false;
                }
            }
            else if (Display.Instance.BPoint >= Rule.FinalSetWinPoint && Display.Instance.BPoint - Display.Instance.APoint >= Rule.Match/2 && Display.Instance.CurrentSet == Rule.Match)
            {
                //ファイナルセットで15点に到達したとき
                Display.Instance.BTeamSet++;

                Display.Instance.PointEnable = false;
                Display.Instance.SubButtonEnable = false;
                Display.Instance.SubButton2Enable = false;

            }
            else if (Display.Instance.BPoint == Rule.FinalSetCourtChangePoint && Display.Instance.APoint < Display.Instance.BPoint && Display.Instance.CurrentSet == Rule.Match)
            {
                //ファイナルセットで8点に到達したとき

                Display.Instance.SubButton2Enable = true;
                Display.Instance.PointEnable = false;
            }
            History.Add(new HisDate()
            {
                APoint = Display.Instance.APoint,
                BPoint = Display.Instance.BPoint,
                isAServe = Display.Instance.isAServe,
                ASet = Display.Instance.ATeamSet,
                BSet = Display.Instance.BTeamSet,
                AName = Display.Instance.ATeamName,
                BName = Display.Instance.BTeamName,
                CurrentSet = Display.Instance.CurrentSet,
                LastSetChangeCourt = Display.Instance.LastSetCourtChange,
                PointButtonEnable = Display.Instance.PointEnable,
                SubButton1Enable = Display.Instance.SubButtonEnable,
                SubButton2Enable = Display.Instance.SubButton2Enable
            });
        }
    }
}
