using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WpfApp1.cs
{
    public class TimerA: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string m_dateTime;
        private int X;
        private Point m_Point ;
        public string DateTimea { get { return m_dateTime; } set { m_dateTime = value; OnPropertyChanged(nameof(DateTimea)); } }
        public Point Points { get { return m_Point; }set { m_Point = value; OnPropertyChanged2(nameof(Points)); } }
            private DispatcherTimer _timer;
        public TimerA()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);//更新频率设为每秒
            _timer.Tick += Time_Tick;
            _timer.Start();
            X = 0;
        }
        private void Time_Tick(object sender, EventArgs e)
        {
            updateTime();
            updatepoint();
        }
        private void updateTime()
        {
            DateTimea = DateTime.Now.ToString("HH:mm:ss");

        }
        private void updatepoint()
        {
            Random ran = new Random();
            int m = ran.Next(10000);
            Points = new Point(X, m);
            X++;

        }
        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
        private void OnPropertyChanged2(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
    }
}
