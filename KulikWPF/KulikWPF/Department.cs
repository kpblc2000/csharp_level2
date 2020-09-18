using System.ComponentModel;

namespace KulikWPF
{
    public class Department : INotifyPropertyChanged
    {
        private string _name;

        public event PropertyChangedEventHandler PropertyChanged;

        public string DepartName
        {
            get => this._name;
            set
            {
                this._name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.DepartName)));
            }
        }

        public Department(string Name)
        { _name = Name; }

        public override string ToString()
        {
            return _name;
        }
    }
}
