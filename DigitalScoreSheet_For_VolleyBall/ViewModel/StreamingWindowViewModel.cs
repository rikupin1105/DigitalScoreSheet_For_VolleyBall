using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalScoreSheet_For_VolleyBall.ViewModel
{
    class StreamingWindowViewModel
    {

        public ReadOnlyReactiveProperty<int> APoint { get; }
        public ReadOnlyReactiveProperty<int> BPoint { get; }

        public ReadOnlyReactiveProperty<string> ATeamName { get; }
        public ReadOnlyReactiveProperty<string> BTeamName { get; }

        public ReadOnlyReactiveProperty<int> ATeamSet { get; }
        public ReadOnlyReactiveProperty<int> BTeamSet { get; }
        public ReadOnlyReactiveProperty<string> AServe { get; }
        public ReadOnlyReactiveProperty<string> BServe { get; }


        public StreamingWindowViewModel()
        {
            APoint = Display.Instance.ObserveProperty(x => x.APoint).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            BPoint = Display.Instance.ObserveProperty(x => x.BPoint).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));

            ATeamName = Display.Instance.ObserveProperty(x => x.ATeamName).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            BTeamName = Display.Instance.ObserveProperty(x => x.BTeamName).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            
            ATeamSet = Display.Instance.ObserveProperty(x => x.ATeamSet).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            BTeamSet = Display.Instance.ObserveProperty(x => x.BTeamSet).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));

            AServe = Display.Instance.ObserveProperty(x => x.AServe).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));
            BServe = Display.Instance.ObserveProperty(x => x.BServe).ToReadOnlyReactiveProperty(eventScheduler: new SynchronizationContextScheduler(SynchronizationContext.Current));

        }
    }
}
