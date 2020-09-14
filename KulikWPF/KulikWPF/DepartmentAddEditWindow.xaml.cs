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
    /// Логика взаимодействия для DepartmentAddEditWindow.xaml
    /// </summary>
    public partial class DepartmentAddEditWindow : Window
    {
        public DepartmentAddEditWindow()
        {
            InitializeComponent();
            txtAdd.Text = "";
            bAdd.IsEnabled = false;
        }


        private void lstDep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox obj = sender as ListBox;
            if (obj.ItemsSource != null)
                txtEdit.Text = obj.SelectedItem.ToString();
            else
                txtEdit.Text = "";
        }

        private void bSet_Click(object sender, RoutedEventArgs e)
        {
            int index = lstDep.SelectedIndex;
            //MainWindow.departments[this.lstDep.SelectedIndex].DepartName = txtEdit.Text;
            lstDep.ItemsSource = null;
            //lstDep.ItemsSource = MainWindow.departments;
            lstDep.SelectedIndex = index;
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtAdd.Text != "")
            {
                //MainWindow.departments.Add(new Department(txtAdd.Text));
                txtAdd.Text = "";
                lstDep.ItemsSource = null;
                //lstDep.ItemsSource = MainWindow.departments;
                //lstDep.SelectedIndex = MainWindow.departments.Count - 1;
            }
        }

        private void txtAdd_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;
            EnableByText.MakeEnabled(txt, bAdd);

        }
    }
}
