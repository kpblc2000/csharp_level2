using System.Collections.Generic;
using System.ComponentModel;

namespace KulikWPF
{
    public class Employee : INotifyPropertyChanged
    {

        private string _name;
        private Department _dep;

        public event PropertyChangedEventHandler PropertyChanged;

        public Department DepName
        {
            get => this._dep;
            set
            {
                _dep = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.DepName)));
            }
        }

        public Employee(string EmployeeName)
        {
            _name = EmployeeName;
        }

        public string FullName
        {
            get => this._name;
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.FullName)));
            }
        }



    }
}
