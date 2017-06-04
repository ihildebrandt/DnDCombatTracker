using CombatTracker.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatTracker.WpfApplication.Model.Design
{
    public class MainWindowViewModel : Model.MainWindowViewModel
    {
        public MainWindowViewModel() : base()
        {
            for (var i=0; i<10; i++)
            {
                Characters.Add(CreateCharacter(i));
            }
        }

        private Character CreateCharacter(int idx)
        {
            var character = new Character
            {
                Name = "ABCDE",
                Initiative = idx,
                CurrentHitPoints = 77,
                MaximumHitPoints = 100,
                TemporaryHitPoints = 15,
                TemporaryHitPointsTurns = 1,
                DeathSaveSuccessChecked = new ObservableCollection<bool> { true, true, false },
                DeathSaveFailureChecked = new ObservableCollection<bool> { true, false, false },
                Conditions = new ObservableCollection<Condition>
                {
                    new Condition
                    {
                        Name="Blinded",
                        Turns=17
                    },
                    new Condition
                    {
                        Name="Dead",
                        Turns=1000000
                    }
                }
            };

            return character;
        }
    }
}
