using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace POMODOROTIMER.Model
{
    abstract class BaseTimer
    {
        public string strTime;
        public TimeSpan time;
        public DispatcherTimer pt;

        public BaseTimer()
        {
            time = new TimeSpan(0, 0, 0);
            pt = new DispatcherTimer();
            pt.Tick += new EventHandler(Timer_Tick);
            pt.Interval = new TimeSpan(0, 0, 1);
        }

        public bool Switch()
        {
            if (!pt.IsEnabled)
            {
                Start();
                return true;
            }
            else
                Stop();
            return false;
        }

        public abstract void Start();

        public abstract void Stop();

        public abstract PStopwatch UpdateState();
        public abstract PTimer UpdateState(string strtime);

        public abstract void Timer_Tick(object sender, EventArgs e);
    }
}
