using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;

namespace POMODOROTIMER.Model
{
    class PTimer : BaseTimer
    {
        public string strstart;
      
        public PTimer(string strstart) 
        {
            this.strstart = strstart;
        }
        public PTimer(TimeSpan timeSpan)
        {
            strstart = timeSpan.ToString(); 
            time = timeSpan;
        }
        public TimeSpan UpdateTime(string strtime)
        {
            int hour = (((int)strtime[0] - '0') * 10) + ((int)strtime[1] - '0');
            int min = (((int)strtime[3] - '0') * 10) + ((int)strtime[4] - '0');
            int sec = (((int)strtime[6] - '0') * 10) + ((int)strtime[7] - '0');
            return new TimeSpan(hour, min, sec);
        }


        public override void Start()
        {
            time = UpdateTime(strstart);
            pt.Start();
        }


        public override void Stop()
        {
            pt.Stop();
            strTime = strstart;
            time = UpdateTime(strTime);
        }

        public override void Timer_Tick(object sender, EventArgs e)
        {
            time -= TimeSpan.FromSeconds(1);
            if (time.ToString() == "00:00:00")
            {
                Console.WriteLine("A vce");
                Stop();
            }
            strTime = time.ToString();
        }

        public override PTimer UpdateState( string strtime)
        {
            return new PTimer(UpdateTime(strtime));
        }

        public override PStopwatch UpdateState()
        {
           return new PStopwatch();
        }
    }
}
