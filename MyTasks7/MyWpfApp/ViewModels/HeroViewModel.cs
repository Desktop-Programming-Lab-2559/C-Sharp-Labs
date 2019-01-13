using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyWpfApp.ViewModels
{
    public class HeroViewModel : INotifyPropertyChanged
    {
        private ICollection<Hero> _heroes;
        public ICollection<Hero> Heroes
        {
            get => _heroes;
            set
            {
                _heroes = value;
                OnPropertyChanged("Heroes");
            }
        }
        private Hero _hero;

        public Hero ModelHero
        {
            get => _hero;
            set
            {
                _hero = value;
                OnPropertyChanged("ModelHero");
            }
        }

        private MyCommand _addHeroCommand;
        public MyCommand AddHeroCommand
        {
            get
            {
                return _addHeroCommand ?? 
                (_addHeroCommand = new MyCommand((obj) =>
                {
                    HeroWindow heroWindow = new HeroWindow(new Hero());
                    if(heroWindow.ShowDialog() == true)
                    {
                        Hero h = heroWindow.Hero;
                        Heroes.Add(h);
                    }
                }));
            }
        }

        private MyCommand _editHeroCommand;
        public MyCommand EditHeroCommand
        {
            get
            {
                return _editHeroCommand ?? (
                    _editHeroCommand = new MyCommand((item) =>
                    {
                        if (item == null)
                            return;
                        Hero hero = item as Hero;
                        Hero h = new Hero()
                        {
                            Id = hero.Id,
                            Name = hero.Name,
                            Level = hero.Level,
                            Speed = hero.Speed,
                            Energy = hero.Energy,
                            Strength = hero.Strength
                        };
                        HeroWindow heroWindow = new HeroWindow(h);
                        if (heroWindow.ShowDialog() == true)
                        {
                            hero = Heroes.Where(obj => obj.Id == heroWindow.Hero.Id).FirstOrDefault();
                            if (hero != null)
                            {
                                hero.Id = heroWindow.Hero.Id;
                                hero.Name = heroWindow.Hero.Name;
                                hero.Level = heroWindow.Hero.Level;
                                hero.Speed = heroWindow.Hero.Speed;
                                hero.Energy = heroWindow.Hero.Energy;
                                hero.Strength = heroWindow.Hero.Strength;
                            }
                        }
                    }));
            }
        }
        private MyCommand _removeHeroCommand;
        public MyCommand RemoveHeroCommand
        {
            get
            {
                return _removeHeroCommand ??
                  (_removeHeroCommand = new MyCommand((item) =>
                  {
                      if (item == null)
                          return;
                      Hero hero = item as Hero;
                      Heroes.Remove(hero);
                  }));
            }
        }

        public HeroViewModel()
        {
            LoadHeroes();
        }

        private void LoadHeroes()
        {
            _heroes = new ObservableCollection<Hero>
            {
                new Hero(){ Id = 1, Name = "Joker", Level = 4, Speed = 3, Energy = 10.3, Strength = 4 },
                new Hero(){ Id = 2, Name = "Batman", Level = 4, Speed = 4, Energy = 20.3, Strength = 5 },
                new Hero(){ Id = 3, Name = "Superman", Level = 10, Speed = 10, Energy = 70.3, Strength = 10 },
                new Hero(){ Id = 4, Name = "Supergirl", Level = 9, Speed = 9, Energy = 60.3, Strength = 8 },
                new Hero(){ Id = 5, Name = "Lex Luthor", Level = 10, Speed = 1, Energy = 1.3, Strength = 1 },
                new Hero(){ Id = 6, Name = "Green Arrow", Level = 5, Speed = 5, Energy = 20.3, Strength = 6 },
                new Hero(){ Id = 7, Name = "Batwoman", Level = 3, Speed = 4, Energy = 30.3, Strength = 5 },
                new Hero(){ Id = 8, Name = "Darkseid", Level = 10, Speed = 10, Energy = 80.3, Strength = 9 },
                new Hero(){ Id = 9, Name = "Aquaman", Level = 4, Speed = 7, Energy = 50.3, Strength = 7 },
                new Hero(){ Id = 10, Name = "Wonder Woman", Level = 6, Speed = 7, Energy = 50.3, Strength = 7 },
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MyCommand : ICommand
    {
        private Action<object> _execMethod;
        private Func<object, bool> _canExec;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public MyCommand(Action<object> exec, Func<object, bool> canExec = null)
        {
            _execMethod = exec;
            _canExec = canExec;
        }

        public bool CanExecute(object parameter)
        {
            return ((_canExec == null) || _canExec(parameter));
        }

        public void Execute(object parameter)
        {
            _execMethod(parameter);
        }
    }
}
