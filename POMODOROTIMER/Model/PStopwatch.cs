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
            time = new int[6];
        }

        public override void Timer_Tick(object sender, EventArgs e)
        {
            time[5] += 1;
            for (int i = 5; i > 0; i--)
            {
                if (i == 4 || i == 2)
                {
                    if (time[i] == 6 || time[i] > 6)
                    {
                        time[i] = 0;
                        time[i - 1] += 1;
                    }
                }
                else
                {
                    if (time[i] == 10 || time[i] > 10)
                    {
                        time[i] = 0;
                        time[i - 1] += 1;
                    }
                }
            }
            strTime = $"{time[0]}{time[1]}:{time[2]}{time[3]}:{time[4]}{time[5]}";
        }
    }
}
