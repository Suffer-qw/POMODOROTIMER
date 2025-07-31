using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMODOROTIMER.Model
{
    class PStopwatch : BaseTimer
    {
        public PStopwatch() 
        { 
        }
        public override void Start()
        {
            pt.Start();
        }

        public override void Stop()
        {
            pt.Stop();
            strTime = "00:00:00";
            time = new TimeSpan(0, 0, 0);
        }

        public override void Timer_Tick(object sender, EventArgs e)
        {
            time = time.Add(TimeSpan.FromSeconds(1));
            strTime = time.ToString();
        }

        public override PTimer UpdateState(string strtime) 
        { 
            return new PTimer(strtime); 
        }

        public override PStopwatch UpdateState()
        {
            throw new NotImplementedException();
        }
    }
}
