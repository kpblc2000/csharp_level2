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

/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// C#, уровень 2, урок 5
/// </summary>
/// 
namespace KulikWPF
{
    /// <summary>
    /// Логика взаимодействия для EmployeeAddEditWindow.xaml
    /// </summary>
    public partial class EmployeeAddEditWindow : Window
    {

        /// <summary>
        /// Определяет, ннаходимся в режиме редактирования (true) или добавления (false) пользователя
        /// </summary>
        private bool editMode;

        public EmployeeAddEditWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Вызов группы для добавления нового пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            grp.Visibility = Visibility.Visible;
            txtFirstName.Text = "";
            txtLastName.Text = "";
            lstDep.SelectedIndex = 0;
            editMode = false;
            bAccept.IsEnabled = editMode;
            bCancel.IsEnabled = editMode;
            lstEmpl.IsEnabled = false;
        }

        /// <summary>
        /// Вызов подгруппы для редактирования текущего пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bEdit_Click(object sender, RoutedEventArgs e)
        {
            grp.Visibility = Visibility.Visible;
            int index = lstEmpl.SelectedIndex;
            txtFirstName.Text = MainWindow.employees[index].FirstName;
            txtLastName.Text = MainWindow.employees[index].LastName;
            if (MainWindow.employees[index].depart != null)
            {
                lstDep.SelectedIndex = MainWindow.departments.IndexOf(MainWindow.employees[index].depart);
            }
            editMode = true;
            bAccept.IsEnabled = editMode;
            bCancel.IsEnabled = editMode;
            lstEmpl.IsEnabled = false;
        }

        /// <summary>
        /// Нажатие кнопки "Принять" при редактировании / добавлении нового пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bAccept_Click(object sender, RoutedEventArgs e)
        {
            char[] trim = new char[] { ' ' };
            string firstName = txtFirstName.Text.Trim(trim);
            string lastName = txtLastName.Text.Trim(trim);
            int index;
            if (firstName != "" && lastName != "")
            {
                Employee empl = new Employee(firstName, lastName);

                if (editMode)
                { // Режим редактирования. Топорно, но на что хватило мозгов
                    index = lstEmpl.SelectedIndex;
                    MainWindow.employees.RemoveAt(index);
                }
                else
                {
                    index = MainWindow.employees.Count;
                }

                if (lstDep.SelectedItem != null)
                {
                    empl.depart = MainWindow.departments[lstDep.SelectedIndex];
                }
                MainWindow.employees.Insert(index, empl);

                lstEmpl.ItemsSource = null;
                lstEmpl.ItemsSource = MainWindow.employees;
            }
            lstEmpl.IsEnabled = true;
            grp.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Нажатие кнопки "Отменить" при редактировании / добавлении нового пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            grp.Visibility = Visibility.Hidden;
            lstEmpl.IsEnabled = true;
        }

        /// <summary>
        /// Обработка события нажатия клавиши на текстовом поле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxKeyUpEvent(object sender, KeyEventArgs e)
        {
            List<Control> ctrlList = new List<Control>();
            ctrlList.Add(bAccept);
            ctrlList.Add(bCancel);
            EnableByText.MakeEnabled(sender as TextBox, ctrlList);
        }

    }
}
