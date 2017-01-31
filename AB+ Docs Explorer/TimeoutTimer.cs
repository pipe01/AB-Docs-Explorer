using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Control = System.Windows.Forms.Control;

namespace AB__Docs_Explorer
{
    class TimeoutTimer
    {
        private Timer Timer;
        private int Count;
        private int Maximum = 5;
        private int TickMS = 100;
        private Control Owner = null;

        public int MaximumMS
        {
            get
            {
                return Maximum * TickMS;
            }
            set
            {
                Maximum = value / TickMS;
            }
        }

        public event EventHandler Timeout;

        public TimeoutTimer(Control owner = null)
        {
            Timer = new Timer();
            Timer.Interval = TickMS;
            Timer.Elapsed += Timer_Elapsed;

            this.Owner = owner;
        }

        public void Start()
        {
            if (!Timer.Enabled)
            {
                Reset();
                Timer.Start();
            }
        }

        public void Stop()
        {
            if (Timer.Enabled)
            {
                Timer.Stop();
                Reset();
            }
        }

        public void Reset()
        {
            Count = 0;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Count++;
            if (Count == Maximum)
            {
                if (this.Owner != null)
                {
                    this.Owner.Invoke(Timeout);
                }
                else
                {
                    Timeout?.Invoke(sender, e);
                }
                Stop();
            }
        }
    }
}
