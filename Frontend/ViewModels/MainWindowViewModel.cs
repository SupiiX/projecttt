using Frontend.Logic;
using Frontend.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Frontend.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        IArmyLogic logic;
        public ObservableCollection<Trooper> Barrack { get; set; }
        public ObservableCollection<Trooper> Army { get; set; }
        public Trooper SelectedFromBarack
        {
            get { return selectedFromBarack; }
            set { 
                SetProperty(ref selectedFromBarack, value);
                (AddToArmyCommand as RelayCommand).NotifyCanExecuteChanged();
                (EditTrooperCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public Trooper SelectedFromArmy
        {
            get { return selectedFromArmy; }
            set { 
                SetProperty(ref selectedFromArmy, value);
                (RemoveFromArmyCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private Trooper selectedFromBarack;
        private Trooper selectedFromArmy;

        public ICommand AddToArmyCommand { get; set; }
        public ICommand RemoveFromArmyCommand { get; set; }
        public ICommand EditTrooperCommand { get; set; }

        public int AllCost
        {
            get { return logic.AllCost; }
        }
        /*
        public double AVGpower
        {
            get { return logic.AVGpower; }
        }
        
        public double AVGspeed
        {
            get { return logic.AVGspeed; }
        }*/
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<IArmyLogic>())
        {

        }
        public MainWindowViewModel(IArmyLogic logic) {

            this.logic = logic;
            Barrack = new ObservableCollection<Trooper>();
            Army = new ObservableCollection<Trooper>();

            Barrack.Add(new Trooper() { Type = "marine", Power = 8, Vitality = 6, Cost = 6});
            Barrack.Add(new Trooper() { Type = "pilot", Power = 7, Vitality = 3, Cost = 10 });
            Barrack.Add(new Trooper() { Type = "infantry", Power = 6, Vitality = 8, Cost = 10 });
            Barrack.Add(new Trooper() { Type = "sniper", Power = 3, Vitality = 3, Cost = 7 });
            Barrack.Add(new Trooper() { Type = "engineer", Power = 5, Vitality = 6, Cost = 8 });

            Army.Add(Barrack[2].GetCopy());
            Army.Add(Barrack[4].GetCopy());

            logic.SetupCollections(Barrack, Army);

            AddToArmyCommand = new RelayCommand(
                () => logic.AddToArmy(SelectedFromBarack), 
                () => SelectedFromBarack != null
                );
            RemoveFromArmyCommand = new RelayCommand(
                () => logic.RemoveFromArmy(SelectedFromArmy), 
                () => SelectedFromArmy != null
                );
            EditTrooperCommand = new RelayCommand(
                () => logic.EditTrooper(SelectedFromBarack), 
                () => SelectedFromBarack != null
                );

            Messenger.Register<MainWindowViewModel, string, string>(this, "TrooperInfo", (recipient, msg) => 
            {
                OnPropertyChanged("AllCost");
               // OnPropertyChanged("AVGpower");
               // OnPropertyChanged("AVGspeed");
                });
        }
    }
}
