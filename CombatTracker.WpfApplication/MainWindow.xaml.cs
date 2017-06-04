using CombatTracker.Model;
using CombatTracker.WpfApplication.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CombatTracker.WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel ViewModel { get; }

        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new MainWindowViewModel();
            DataContext = ViewModel;
        }
        
        private void RollInitiative_Click(object sender, RoutedEventArgs e)
        {
            var init = DieRoller.Instance.Roll(1, 20, 0);
            ViewModel.Current.Initiative = init;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Characters.Add(new Character());
            SelectCharacter(ViewModel.Characters.Count - 1);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
        }

        private void CharactersListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.SetSelectedIndex(CharactersListView.SelectedIndex);
        }

        private void SelectCharacter(int idx)
        {
            CharactersListView.SelectedIndex = idx;
            ViewModel.SetSelectedIndex(idx);
        }

        private void SortCharacters()
        {
            var dataView = CollectionViewSource.GetDefaultView(CharactersListView.ItemsSource);
            dataView.SortDescriptions.Clear();
            dataView.SortDescriptions.Add(new SortDescription("Initiative", ListSortDirection.Descending));
            dataView.Refresh();
        }
    }
}
