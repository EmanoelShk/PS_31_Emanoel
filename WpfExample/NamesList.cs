using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfExample
{
    public class NamesList : INotifyPropertyChanged
    {
        string _firstName = "";

        string _lastName = "";

        string _selectedName;

        public ICommand AddNameCommand { get; set; }

        public ICommand RemoveNameCommand { get; set; }

        public NamesList()
        {
            Names = new ObservableCollection<string>();
            AddNameCommand = new RelayCommand(AddExecute, AddCanExecute);
            RemoveNameCommand = new RelayCommand(RemoveExecute, RemoveCanExecute);
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set

            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        public string SelectedName
        {
            get { return _selectedName; }
            set
            {
                if (_selectedName != value)
                {

                    _selectedName = value;
                    OnPropertyChanged("SelectedName");
                }
            }
        }

        public ObservableCollection<string> Names { get; private set; }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RemoveExecute(object value)
        {

            var nameList = value as NamesList;
            var oldName = nameList.SelectedName;
            nameList.Names.Remove(oldName);
        }

        private void AddExecute(object value)
        {
            var nameList = value as NamesList;
            var newName = string.Format("{0} {1}", nameList.FirstName,
            nameList.LastName);
            nameList.Names.Add(newName);
            nameList.FirstName = nameList.LastName = "";
        }

        private bool RemoveCanExecute(object value)
        {

            var nameList = value as NamesList;
            return nameList != null && nameList.SelectedName != null;
        }

        private bool AddCanExecute(object value)
        {

            return true;
        }
    }
}
