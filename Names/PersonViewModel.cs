using ListName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Names
{
    public class PersonViewModel
    {
        private Person Person;
        private Action onCloseCallback;
        private PersonView personWindow;

        public string FirstName
        {
            get => Person.FirstName;
            set => Person.FirstName = value;
        }
        public string LastName
        {
            get => Person.LastName;
            set => Person.LastName = value;
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
            set => Person.BirthDate = value;
        }


        public RelayCommand DoubleClickCommand { get; }
        public RelayCommand CloseCommand { get; }


        public PersonViewModel(Person person)
        {
            Person = person;
            DoubleClickCommand = new RelayCommand(o => OpenPersonWindow());
            CloseCommand = new RelayCommand(o=>ClosePersonWindow());
            personWindow = new PersonView();
        }
        public void OpenPersonWindow()
        {
            //MessageBox.Show("Hello !");
            //onCloseCallback = () => { personWindow.Close(); };
            personWindow.DataContext = this;
            personWindow.ShowDialog();
        }
        public void ClosePersonWindow()
        {
            personWindow.Close();
        }
    }
}
