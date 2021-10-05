using ListName;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Names
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        public Person Person { get; set; }
        public Action<bool, PersonViewModel> CloseCallback { get; set; }
        private Action<PersonViewModel> SaveCallback;
        private PersonView personWindow;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Index { get; }

        public string FirstName
        {
            get => Person.FirstName;
            set
            {
                Person.FirstName = value;
                NotifyPropertyChanged();
            }
        }
        public string LastName
        {
            get => Person.LastName;
            set
            {
                Person.LastName = value;
                NotifyPropertyChanged();
            }
        }
        public string FullName
        {
            get
            {
                return $"{Person.FirstName} {Person.LastName} ({DateTime.Now.Year - Person.BirthDate.Year} ans)";
            }
        }
        public DateTime BirthDate
        {
            get => Person.BirthDate;
            set 
            {
                Person.BirthDate = value;
                NotifyPropertyChanged();
            }
        }


        public RelayCommand DoubleClickCommand { get; }
        public RelayCommand CloseCommand { get; }
        public RelayCommand SaveCommand { get; }


        public PersonViewModel(Person person, Action<PersonViewModel> callback, int _index)
        {
            Person = person;
            DoubleClickCommand = new RelayCommand(o => OpenPersonWindow());
            CloseCommand = new RelayCommand(o => ClosePersonWindow());
            SaveCommand = new RelayCommand(o => SavePersonWindow());
            CloseCallback = (_, _) => { personWindow.Close(); };
            SaveCallback = callback;
            Index = _index;
        }
        public void OpenPersonWindow()
        {
            personWindow = new PersonView();
            var clone = new PersonViewModel(new Person(Person.FirstName, Person.LastName, Person.BirthDate), SaveCallback, Index);
            clone.CloseCallback = (isSaving, personVM) => EditFinished(isSaving, clone);
            personWindow.DataContext = clone;
            //personWindow.DataContext = this;
            personWindow.ShowDialog();
        }
        public void ClosePersonWindow()
        {
            CloseCallback(false, null);
        }
        public void SavePersonWindow()
        {
            CloseCallback(true, this);
        }
        private void EditFinished(bool applyChanges, PersonViewModel editedPersonVM)
        {
           
            if (applyChanges)
            {
                _ = MessageBox.Show("Edited");
                Person = editedPersonVM.Person;
                FirstName = editedPersonVM.FirstName;
                LastName = editedPersonVM.LastName;
                BirthDate = editedPersonVM.BirthDate;
                SaveCallback(this);
            }
            else
            {
                _ = MessageBox.Show("Cancel");
                editedPersonVM.Person = Person;
                editedPersonVM.FirstName = FirstName;
                editedPersonVM.LastName = LastName;
                editedPersonVM.BirthDate = BirthDate;
            }
            ClosePersonWindow();
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
