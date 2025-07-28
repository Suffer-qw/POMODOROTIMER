using System;
using System.Collections.Generic;
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

        public override void Start()
        {// 0 1 3 4 6 7
            time[0] = (int)strstart[0] - '0';
            time[1] = (int)strstart[1] - '0';
            time[2] = (int)strstart[3] - '0';
            time[3] = (int)strstart[4] - '0';
            time[4] = (int)strstart[6] - '0';
            time[5] = (int)strstart[7] - '0';
            pt.Start();
        }

        public override void Stop()
        {
            pt.Stop();
            strTime = strstart;
            time = new int[6];
        }

        public override void Timer_Tick(object sender, EventArgs e)
        {
            // Уменьшаем последнюю цифру (секунды)
            time[5]--;

            // Обрабатываем заимствования по разрядам
            for (int i = 5; i >= 0; i--)
            {
                if (time[i] >= 0) continue;

                if (i == 4 || i == 2) // Разряды с основанием 6 (десятки секунд/минут)
                {
                    time[i] = 5;
                    time[i - 1]--;
                }
                else if (i > 0) // Обычные разряды (основание 10)
                {
                    time[i] = 9;
                    time[i - 1]--;
                }
                else // Достигли старшего разряда (десятки часов)
                {
                    // Обнуляем время при достижении 00:00:00
                    for (int j = 0; j < 6; j++) time[j] = 0;
                    break;
                }
            }

            // Проверяем и корректируем отрицательные значения (дополнительная защита)
            for (int i = 0; i < 6; i++)
            {
                if (time[i] < 0) time[i] = 0;
            }

            // Форматируем строку времени
            strTime = $"{time[0]}{time[1]}:{time[2]}{time[3]}:{time[4]}{time[5]}";
        }
    }
}
