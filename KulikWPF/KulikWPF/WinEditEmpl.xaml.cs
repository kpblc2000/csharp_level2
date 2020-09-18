using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KulikWPF
{
    /// <summary>
    /// Логика взаимодействия для WinEditEmpl.xaml
    /// </summary>
    public partial class WinEditEmpl : Window
    {

        public delegate void NewEmpl(string EmployeeName, int SelectedDepartment);

        public event NewEmpl EventAddNewEmpl;

        public WinEditEmpl()
        {
            InitializeComponent();
        }

        //public WinEditEmpl(Employee e) : this()
        //{
        //    MainGrid.DataContext = e;
        //}

        public WinEditEmpl(MainWindow w) : this()
        {
            MainGrid.DataContext = w.EmplProp;
            // lstDep.DataContext = w.departments;
            lstDep.ItemsSource = w.departments;
            if (w.EmplProp.DepName != null)
            {
                lstDep.SelectedItem = w.EmplProp.DepName;
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            EventAddNewEmpl?.Invoke(this.txtName.Text, this.lstDep.SelectedIndex);
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
