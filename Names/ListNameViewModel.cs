using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using ListName;

namespace Names
{
    //View model pour le MVVM
    public class ListNameViewModel : INotifyPropertyChanged
    {

        public People ListPerson = new People();

        //public ObservableCollection<PersonViewModel> ListObservablePerson = new ObservableCollection<PersonViewModel>
        //    {
        //        new PersonViewModel(new Person("Jean"), null, 0),
        //        new PersonViewModel(new Person("Niko", "Myoji"), null, 1),
        //        new PersonViewModel(new Person("Nono", "Mitsuyo", new DateTime(2000, 12, 24)), null, 2)
        //    };
        public ObservableCollection<PersonViewModel> ListObservablePerson = new ObservableCollection<PersonViewModel>();


        #region Properties

        private double _sliderValue = 100d;
        public double SliderValue
        {
            get => _sliderValue;
            set
            {
                _sliderValue = value;
                NotifyPropertyChanged();
            }
        }

        private string _colorSelected;
        public string ColorSelected
        {
            get => _colorSelected;
            set
            {
                _colorSelected = value;
                BrushColor = ChangeBackgroundColor.ChangeColor(value);
                NotifyPropertyChanged();
            }
        }

        private bool _isRadioRedCheck;
        public bool IsRadioRedCheck
        {
            get => _isRadioRedCheck;
            set
            {
                _isRadioRedCheck = value;
                if (value)
                    BrushColor = ChangeBackgroundColor.ChangeColor("red");
                NotifyPropertyChanged();
            }
        }
        private bool _isRadiGreenCheck;
        public bool IsRadioGreenCheck
        {
            get => _isRadiGreenCheck;
            set
            {
                _isRadiGreenCheck = value;
                if (value)
                    BrushColor = ChangeBackgroundColor.ChangeColor("green");
                NotifyPropertyChanged();
            }
        }
        private bool _isRadioBlueCheck;
        public bool IsRadioBlueCheck
        {
            get => _isRadioBlueCheck;
            set
            {
                _isRadioBlueCheck = value;
                if (value)
                    BrushColor = ChangeBackgroundColor.ChangeColor("blue");
                NotifyPropertyChanged();
            }
        }

        private bool _isBlueCheck = true;
        public bool IsBlueCheck
        {
            get => _isBlueCheck;
            set
            {
                _isBlueCheck = value;

                BrushColor = ChangeBackgroundColor.ChangeColor(Colors.Blue, BrushColor.Color, value);

                NotifyPropertyChanged();
            }
        }
        private bool _isRedCheck = true;
        public bool IsRedCheck
        {
            get => _isRedCheck;
            set
            {
                _isRedCheck = value;

                BrushColor = ChangeBackgroundColor.ChangeColor(Colors.Red, BrushColor.Color, value);

                NotifyPropertyChanged();
            }
        }
        private bool _isGreenCheck = true;
        public bool IsGreenCheck
        {
            get => _isGreenCheck;
            set
            {
                _isGreenCheck = value;

                BrushColor = ChangeBackgroundColor.ChangeColor(Colors.Lime, BrushColor.Color, value);

                NotifyPropertyChanged();
            }
        }

        private bool _isBlueEnabled = true;
        public bool IsBlueEnabled
        {
            get => _isBlueEnabled;
            set
            {
                _isBlueEnabled = value;
                NotifyPropertyChanged();

            }
        }
        private bool _isRedEnabled = true;
        public bool IsRedEnabled
        {
            get => _isRedEnabled;
            set
            {
                _isRedEnabled = value;
                NotifyPropertyChanged();

            }
        }
        private bool _isGreenEnabled = true;
        public bool IsGreenEnabled
        {
            get => _isGreenEnabled;
            set
            {
                _isGreenEnabled = value;
                NotifyPropertyChanged();

            }
        }

        private SolidColorBrush _brushColor = Brushes.White;
        public SolidColorBrush BrushColor
        {
            get => _brushColor;
            set
            {
                _brushColor = value;
                RefreshColorButtonEnableStates();
                NotifyPropertyChanged();
            }
        }

        private string _name;
        public string NewName
        {
            get => _name;
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }

        private Person _selName1;
        public Person ValueSelected1
        {
            get => _selName1;
            set
            {
                _selName1 = value;
                NotifyPropertyChanged();
            }
        }
        private PersonViewModel _selName;
        public PersonViewModel ValueSelected
        {
            get => _selName;
            set
            {
                _selName = value;
                NotifyPropertyChanged();
            }
        }
        private int _selIndex;
        public int IndexSelected
        {
            get => _selIndex;
            set
            {
                _selIndex = value;
                NotifyPropertyChanged();
            }
        }
        //public ObservableCollection<Person> ListPersons
        //{
        //    get
        //    {
        //        return ListObservablePerson;
        //    }
        //}
        public ObservableCollection<PersonViewModel> ListPersons
        {
            get
            {
                return ListObservablePerson;
            }
        }

        public List<string> ListColors
        {
            get
            {
                List<string> list = new();
                foreach (PropertyInfo t in typeof(Brushes).GetProperties())
                {
                    list.Add(t.Name.ToString());
                }
                return list;
                //var list = new List<string>();
                //foreach (System.Drawing.KnownColor c in Enum.GetValues(typeof(System.Drawing.KnownColor)))
                //{
                //    list.Add(c.ToString());
                //}
                //return list;
            }
        }
        #endregion

        #region Labels
        public string ButtonLabel => "Add Person";
        public string ButtonDelLabel => "Remove Person";
        public string ButtonDelIndLabel => "Remove Person at Index";
        public string ButtonColorLabel1 => "Red";
        public string ButtonColorLabel2 => "Green";
        public string ButtonColorLabel3 => "Blue";
        #endregion

        #region RelayCommand
        //RelayCommand pour les evenement de boutons
        public RelayCommand AddButtonCommand { get; }
        public RelayCommand DelButtonCommand { get; }
        public RelayCommand DelIndButtonCommand { get; }
        public RelayCommand ChangeBackgroundColorCommand { get; }
        //public RelayCommand DoubleClickCommand { get; }

        #endregion

        // Pour refresh l'affichage de l'UI
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.

        public List<Person> List => new List<Person> { new Person("Nono", "Mitsuyo", new DateTime(2000, 12, 24)), new Person("Niko"), new Person("Jean") };
        //public List<string> ListS => new List<string> { "Nono", "Niko", "Jean" };

        public ListNameViewModel()
        {
            AddButtonCommand = new RelayCommand(o => AddName());
            DelButtonCommand = new RelayCommand(o => RemoveName());
            DelIndButtonCommand = new RelayCommand(o => RemoveNameIndex());
            ChangeBackgroundColorCommand = new RelayCommand(o => BrushColor = ChangeBackgroundColor.ChangeColor(o as string));
            //DoubleClickCommand = new RelayCommand(o => OpenPersonWindow(o as Person));


            ListObservablePerson.Add(new PersonViewModel(new Person("Jean"), saveEditedPerson, 0));
            ListObservablePerson.Add(new PersonViewModel(new Person("Niko", "Myoji"), saveEditedPerson, 1));
            ListObservablePerson.Add(new PersonViewModel(new Person("Nono", "Mitsuyo", new DateTime(2000, 12, 24)), saveEditedPerson, 2));


        }

        public void OpenPersonWindow(Person person)
        {
            //MessageBox.Show("Hello !");
            PersonView personWindow = new PersonView();
            //  personWindow.DataContext = new PersonViewModel(person, saveEditedPerson);
            personWindow.ShowDialog();
        }

        // Méthode pour refresh l'affichage
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void saveEditedPerson(PersonViewModel pm)
        {
            MessageBox.Show("Saved");
            ListPerson.ListName[pm.Index] = pm.Person;
        }


        #region List Methods
        //public void AddName()
        //{
        //    ListPerson.Add(NewName);
        //    if (!string.IsNullOrWhiteSpace(NewName))
        //    {
        //        Person person = new Person(NewName);
        //        foreach (Person pers in ListObservablePerson)
        //        {
        //            if (pers.FirstName.Equals(NewName))
        //            {
        //                return;
        //            }
        //        }
        //        ListObservablePerson.Add(person);
        //    }
        //    NewName = string.Empty;
        //}
        public void AddName()
        {
            ListPerson.Add(NewName);
            if (!string.IsNullOrWhiteSpace(NewName))
            {
                PersonViewModel person = new PersonViewModel(new Person(NewName), saveEditedPerson, ListObservablePerson.Count);
                foreach (PersonViewModel pers in ListObservablePerson)
                {
                    if (pers.FirstName.Equals(NewName))
                    {
                        return;
                    }
                }
                ListObservablePerson.Add(person);
            }
            NewName = string.Empty;
        }

        //public void RemoveName()
        //{
        //    if (ValueSelected != null)
        //    {
        //        ListPerson.Remove(ValueSelected.FirstName);


        //        foreach (Person pers in ListObservablePerson)
        //        {
        //            if (pers.FirstName.Equals(ValueSelected.FirstName))
        //            {
        //                ListObservablePerson.Remove(pers);
        //                break;
        //            }

        //        }

        //        ListObservablePerson.Remove(ValueSelected);
        //    }
        //}
        public void RemoveName()
        {
            if (ValueSelected != null)
            {
                ListPerson.Remove(ValueSelected.FirstName);


                foreach (PersonViewModel pers in ListObservablePerson)
                {
                    if (pers.FirstName.Equals(ValueSelected.FirstName))
                    {
                        ListObservablePerson.Remove(pers);
                        break;
                    }

                }

                ListObservablePerson.Remove(ValueSelected);
            }
        }

        public void RemoveNameIndex()
        {
            if (IndexSelected < 0)
            {
                IndexSelected = 0;
            }
            ListPerson.RemoveAt(IndexSelected);
            if (ListObservablePerson.Count > 0)
            {
                ListObservablePerson.RemoveAt(IndexSelected);
            }
        }
        #endregion

        private void RefreshColorButtonEnableStates()
        {
            IsRedEnabled = BrushColor?.Color != Colors.Red;
            IsGreenEnabled = BrushColor?.Color != Colors.Green;
            IsBlueEnabled = BrushColor?.Color != Colors.Blue;
        }
    }
}

