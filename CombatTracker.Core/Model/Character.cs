using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatTracker.Model
{
    public class Character : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private int _initiative;
        public int Initiative
        {
            get { return _initiative; }
            set
            {
                _initiative = value;
                OnPropertyChanged(nameof(Initiative));
            }
        }

        private int _currentHitPoints;
        public int CurrentHitPoints
        {
            get { return _currentHitPoints; }
            set
            {
                _currentHitPoints = value;
                OnPropertyChanged(nameof(CurrentHitPoints));
            }
        }

        private int _maximumHitPoints;
        public int MaximumHitPoints
        {
            get { return _maximumHitPoints; }
            set
            {
                _maximumHitPoints = value;
                OnPropertyChanged(nameof(MaximumHitPoints));
            }
        }

        private int _temporaryHitPoints;
        public int TemporaryHitPoints
        {
            get { return _temporaryHitPoints; }
            set
            {
                _temporaryHitPoints = value;
                OnPropertyChanged(nameof(TemporaryHitPoints));
            }
        }

        private int? _temporaryHitPointsTurns;
        public int? TemporaryHitPointsTurns
        {
            get { return _temporaryHitPointsTurns; }
            set
            {
                _temporaryHitPointsTurns = value;
                OnPropertyChanged(nameof(TemporaryHitPointsTurns));
            }
        }

        public ObservableCollection<bool> DeathSaveSuccessChecked { get; set; }

        public ObservableCollection<bool> DeathSaveSuccessEnabled { get; }

        public ObservableCollection<bool> DeathSaveFailureChecked { get; set; }

        public ObservableCollection<bool> DeathSaveFailureEnabled { get; }

        public ObservableCollection<Condition> Conditions { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Character()
        {
            DeathSaveSuccessEnabled = new ObservableCollection<bool> { true, false, false };
            DeathSaveFailureEnabled = new ObservableCollection<bool> { true, false, false };

            DeathSaveSuccessChecked = new ObservableCollection<bool> { false, false, false };
            DeathSaveFailureChecked = new ObservableCollection<bool> { false, false, false };

            DeathSaveSuccessChecked.CollectionChanged += DeathSaveSuccessChecked_CollectionChanged;
            DeathSaveFailureChecked.CollectionChanged += DeathSaveFailureChecked_CollectionChanged;

            Conditions = new ObservableCollection<Condition>();
        }

        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void DeathSaveSuccessChecked_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            SetEnabled(DeathSaveSuccessEnabled, e.NewStartingIndex, (bool)e.NewItems[0]);
        }

        private void DeathSaveFailureChecked_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            SetEnabled(DeathSaveFailureEnabled, e.NewStartingIndex, (bool)e.NewItems[0]);
        }

        private void SetEnabled(ObservableCollection<bool> collection, int index, bool setting)
        {
            switch (index)
            {
                case 0:
                    collection[1] = setting;
                    break;
                case 1:
                    collection[0] = !setting;
                    collection[2] = setting;
                    break;
                case 2:
                    collection[1] = !setting;
                    collection[2] = setting;
                    break;
            }
        }
    }
}
