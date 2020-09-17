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

        public delegate void NewEmpl(string EmployeeName);

        public event NewEmpl AddNewEmpl;

        public WinEditEmpl()
        {
            InitializeComponent();
            //btnOk.Click += delegate { this.DialogResult = true; };
            //btnCancel.Click += delegate { this.DialogResult = false; };
        }

        public WinEditEmpl(Employee e) : this()
        {
            MainGrid.DataContext = e;
        }

        public WinEditEmpl(MainWindow w) : this()
        {
            MainGrid.DataContext = w.EmplProp;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            AddNewEmpl?.Invoke(this.txtName.Text);
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
