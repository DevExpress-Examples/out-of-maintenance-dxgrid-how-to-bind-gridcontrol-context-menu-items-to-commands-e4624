using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DevExpress.Mvvm;
namespace GridCommandToPopupMenuProject {
    class PersonViewModel :INotifyPropertyChanged{
        public PersonViewModel(List<Person> lPerson) {
            ListPerson = new ObservableCollection<Person>();
            foreach(Person p in lPerson) {
                ListPerson.Add(p);
            }
        }

        public ObservableCollection<Person> ListPerson { get; set; }
        public Person SelectedPerson {
            get { return _selectedPerson; }
            set {
                _selectedPerson = value;
                NotifyPropertyChanged();
            }
        }
        public int SelectedPersonNum {
            get { return _selectedPersonNum; }
            set { _selectedPersonNum = value;
            SelectedPerson = ListPerson[value];
            NotifyPropertyChanged();
            }
        }

        Person _selectedPerson;
        int _selectedPersonNum;

        public ICommand CreateNewPerson {
            get {
                if(createNewPerson == null) {
                    createNewPerson = new DelegateCommand<Person>(p => CreatePerson());
                }
                 return createNewPerson;
            }
        }
        public ICommand DeletePerson {
            get {
                if(deletePerson == null)
                    deletePerson = new DelegateCommand<Person>(p => DelPerson(), o=>CanDeletePerson());
                return deletePerson;
            }
        }
        public ICommand GoToFivePersonNext {
            get {
                if(goToFivePersonNext == null)
                    goToFivePersonNext = new DelegateCommand<Person>(p => GoTo5PersonNext(), o => CanGoToFivePersonNext());
                return goToFivePersonNext;
            }
        }

        private DelegateCommand<Person> createNewPerson;
        private DelegateCommand<Person> deletePerson;
        private DelegateCommand<Person> goToFivePersonNext;

        void CreatePerson() {
            Person p = new Person(1);
            p.FirstName = "test";
            p.LastName = "test";
            ListPerson.Add(p);
        }
      
        void DelPerson() {
            ListPerson.Remove(SelectedPerson);
        }
        bool CanDeletePerson() {
            return SelectedPerson != null;
        }
        
        void GoTo5PersonNext() {
            SelectedPersonNum += 5;
        }
        bool CanGoToFivePersonNext() {
            return SelectedPersonNum + 5 < ListPerson.Count;
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName]String propertyName = "") {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
