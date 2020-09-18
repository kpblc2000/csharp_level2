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
    /// Логика взаимодействия для WinEditDepart.xaml
    /// </summary>
    public partial class WinEditDepart : Window
    {

        public delegate void NewEditDepartment(string DepartmentName);

        public event NewEditDepartment EventNewEditDepart;

        public WinEditDepart()
        {
            InitializeComponent();
        }

        public WinEditDepart(MainWindow w) : this()
        {
            MainGrid.DataContext = w.DepProp;
            if (w.DepProp!=null)
            {
                txtName.Text = w.DepProp.DepartName;
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            EventNewEditDepart?.Invoke(this.txtName.Text);
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

     }
}
