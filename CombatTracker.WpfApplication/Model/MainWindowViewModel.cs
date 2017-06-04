using CombatTracker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatTracker.WpfApplication.Model
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private bool _formEnabled;
        public bool FormEnabled
        {
            get { return _formEnabled; }
            set
            {
                _formEnabled = value;
                OnPropertyChanged(nameof(FormEnabled));
            }
        }

        public ObservableCollection<Character> Characters { get; }

        private Character _current;
        public Character Current
        {
            get { return _current; }
            set
            {
                _current = value;
                OnPropertyChanged(nameof(Current));
            }
        }

        private int _characterIdx;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            _characterIdx = 0;
            Characters = new ObservableCollection<Character>();
            Characters.CollectionChanged += Characters_CollectionChanged;
        }

        public void SetSelectedIndex(int idx)
        {
            _characterIdx = idx;
            Current = _characterIdx < Characters.Count ? Characters.ElementAt(_characterIdx) : null;
        }

        private void Characters_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            FormEnabled = Characters.Any();
        }
        
        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
