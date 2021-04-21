using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive.Concurrency;
using System.Threading;

namespace ScoreBoard_For_VolleyBall.ViewModel
{
    class ScoreBoardWindow2ViewModel
    {
        public ReadOnlyReactiveProperty<int> APoint { get; }
        public ReadOnlyReactiveProperty<int> BPoint { get; }

        public ReadOnlyReactiveProperty<string> ATeamName { get; }
        public ReadOnlyReactiveProperty<string> BTeamName { get; }

        public ReadOnlyReactiveProperty<string> AServe { get; }
        public ReadOnlyReactiveProperty<string> BServe { get; }
        public ScoreBoardWindow2ViewModel()
        {
            APoint = Display.Instance.ObserveProperty(x => x.APoint).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            BPoint = Display.Instance.ObserveProperty(x => x.BPoint).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            ATeamName = Display.Instance.ObserveProperty(x => x.ATeamName).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            BTeamName = Display.Instance.ObserveProperty(x => x.BTeamName).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            AServe = Display.Instance.ObserveProperty(x => x.AServe).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            BServe = Display.Instance.ObserveProperty(x => x.BServe).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
        }
    }
}