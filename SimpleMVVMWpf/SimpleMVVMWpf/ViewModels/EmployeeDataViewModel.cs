using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SimpleMVVMWpf.Models;

namespace SimpleMVVMWpf.ViewModels {
    public class EmployeeDataViewModel : BaseViewModel {
        private EmployeeData _newInput = new EmployeeData();
        public EmployeeData NewInput {
            get {
                return _newInput;
            }
            set {
                _newInput = value;
                NotifyPropertyChanged("NewInput");
            }
        }

        //List to display the added items
        private ObservableCollection<EmployeeData> _EmployeeList;
        public ObservableCollection<EmployeeData> EmployeeList {
            get {
                return _EmployeeList;
            }
            set {
                _EmployeeList = value;
            }
        }

        public EmployeeDataViewModel() {
            _EmployeeList = new ObservableCollection<EmployeeData>();
            _EmployeeList.Add(new EmployeeData() { Name = "Mohan", Department = "IT", Email = "mohan@gmail.com" });
            _EmployeeList.Add(new EmployeeData() { Name = "Vel", Department = "Testing", Email = "vel@gmail.com" });

            //Adds a new item to the collection
            AddToMaster = new RelayCommand(param => {
                _EmployeeList.Add(NewInput);
                NewInput = new EmployeeData();
            });

            //Removes selected item from collection
            DeleteFromMaster = new RelayCommand(param => {
                _EmployeeList.Remove(ItemToDelete);
            });
        }

        public EmployeeData ItemToDelete { get; set; } //property to hold selected item

        public ICommand AddToMaster { get; set; } //Command to add a new item
        public ICommand DeleteFromMaster { get; set; } //Command to delete an item
    }
}