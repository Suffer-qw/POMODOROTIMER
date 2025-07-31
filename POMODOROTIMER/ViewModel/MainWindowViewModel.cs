using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using POMODOROTIMER.Model;
using POMODOROTIMER.MvvM;
using POMODOROTIMER.View;

namespace POMODOROTIMER.ViewModel
{

    internal static class HistoryManager
    {
        public static ObservableCollection<HistoriPT> _histlist { get; }
            = new ObservableCollection<HistoriPT>();
    }


    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public  BaseTimer _timer;
        private string _currentTime;
        public string _name = "Stopwatch";
        private string _ContentStart = "Start";
        public ObservableCollection<HistoriPT> Histlist => HistoryManager._histlist;
        public MainWindowViewModel()
        {
            _timer = new PStopwatch();
            _currentTime = "00:00:00";
            _timer.pt.Tick += (sender, e) => CurrentTime = _timer.strTime;
        }
      
        /*
        public MainWindowViewModel()
        {
            Histlist.Add(new HistoriPT
            {
                Name = "test",
                Time = "00:01:00",
                Date = "dd.MM.yyyy"
            });
        }
        */
        public RelayCommand SwitchCommand => new RelayCommand(execute => SwitchTimer(), canExecute => { return true; });
        public RelayCommand ShowHisCommand => new RelayCommand(execute => ShowHis(), canExecute => { return true; });

        private void ShowHis()
        {
            HistoryWindow hs = new HistoryWindow();
            hs.Show();
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
            }
        }
        public string CurrentTime
        {
            get => _currentTime;
            set
            {
                _currentTime = value;
                OnPropertyChanged(nameof(CurrentTime));
            }
        }
        

        public string ContentStart
        {
            get { return _ContentStart; }
            set {
                _ContentStart = value;
                OnPropertyChanged(nameof(ContentStart));
            }
        }



        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void SwitchTimer()
        {
            if (_timer.Switch())
            {
                ContentStart = "Stop";
            }
            else
            {
                SaveHis();
                ContentStart = "Start";
                CurrentTime = _timer.strTime;
            }
        }

        public void test(string strtime, bool tt)
        {
            if (tt)
            {
                _timer.pt.Tick -= (sender, e) => CurrentTime = _timer.strTime;
                Name = "PTimer";
                _timer = _timer.UpdateState(strtime);
                
            }
            else
            {
                if (_timer is PTimer)
                {
                    _timer.pt.Tick -= (sender, e) => CurrentTime = _timer.strTime;
                    Name = "PStopwatch";
                    _timer = _timer.UpdateState();
                }
            }
            _currentTime = _timer.strTime;
            _timer.pt.Tick += (sender, e) => CurrentTime = _timer.strTime;
        }

        public void SaveHis()
        {
            Histlist.Add(new HistoriPT
            {
                Name = _name,
                Time = CurrentTime,
                Date = DateTime.Today.ToString("dd.MM.yyyy")
            });
        }

    }
}
