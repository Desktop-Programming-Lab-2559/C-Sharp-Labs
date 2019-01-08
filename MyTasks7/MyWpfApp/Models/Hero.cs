using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyWpfApp
{
    public class Hero : INotifyPropertyChanged, IDataErrorInfo, IComparable<Hero>, IEquatable<Hero>
    {
        public static int Count { get; private set; } = 0;

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private int _level;
        public int Level
        {
            get => _level;
            set
            {
                _level = value;
                OnPropertyChanged("Level");
            }
        }

        private int _speed;
        public int Speed
        {
            get => _speed;
            set
            {
                _speed = value;
                OnPropertyChanged("Speed");
            }
        }

        private double _energy;
        public double Energy
        {
            get => _energy;
            set
            {
                _energy = value;
                OnPropertyChanged("Energy");
            }
        }

        private int _strength;
        public int Strength
        {
            get => _strength;
            set
            {
                _strength = value;
                OnPropertyChanged("Strength");
            }
        }

        public string Error { get => null; }

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case "Id":
                        if ((_id < 1) || (_id > 99))
                        {
                            error = "0 < Id < 99";
                        }
                        break;
                    case "Name":
                        if (string.IsNullOrEmpty(_name))
                        {
                            error = "Can't be empty";
                        }
                        break;
                    case "Level":
                        if ((_level < 1) || (_level > 99))
                        {
                            error = "0 < Level < 100";
                        }
                        break;
                    case "Speed":
                        if (_speed < 1)
                        {
                            error = "Speed must be > 0";
                        }
                        break;
                    case "Energy":
                        if (_energy < 1.0)
                        {
                            error = "Energy should be > 0";
                        }
                        break;
                    case "Strength":
                        if ((_strength < 2) || (_strength > 100))
                        {
                            error = "2 < Strength < 100";
                        }
                        break;
                }

                return error;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Hero(int id = 0, string name = "", int level = 0,
                    int speed = 0, double energy = 0.0, int strength = 0)
        {
            Id = id;
            Name = name;
            Level = level;
            Speed = speed;
            Energy = energy;
            Strength = strength;
            Count++;
        }

        public override string ToString()
        {
            return $"-Id:{Id}\n-Name:{Name}\n\n";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            Hero h = obj as Hero;
            if (h != null)
            {
                if (Id == h.Id && Name == h.Name)
                    return 0;
                else if (Id < h.Id)
                    return -1;
                else
                    return 1;
            }
            else
                throw new ArgumentNullException();
        }

        public bool Equals(Hero other)
        {
            if (other == null)
                return false;
            Hero h = other as Hero;
            if (Id == h.Id)
                return true;
            else
                return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Hero h = obj as Hero;
            if (h == null)
                return false;
            else
                return Equals(h);
        }

        public int CompareTo(Hero other)
        {
            if (Id == other.Id && Name == other.Name)
                return 0;
            else if (Id < other.Id)
                return -1;
            else
                return 1;
        }

        public static bool operator ==(Hero h1, Hero h2)
        {
            if (((object)h1) == null || ((object)h2) == null)
                return Equals(h1, h2);
            return h1.Equals(h2);
        }

        public static bool operator !=(Hero h1, Hero h2)
        {
            if (((object)h1) == null || ((object)h2) == null)
                return !Equals(h1, h2);
            return !(h1.Equals(h2));
        }
    }
}
