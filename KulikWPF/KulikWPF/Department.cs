namespace KulikWPF
{
    public class Department
    {
        public string DepartName { get; set; }
        public Department(string Name)
        { DepartName = Name; }

        public override string ToString()
        {
            return DepartName;
        }

        public static void AddEdit()
        {
            DepartmentAddEditWindow win = new DepartmentAddEditWindow();
            win.lstDep.ItemsSource = MainWindow.departments;
            win.lstDep.SelectedIndex = 0;
            win.ShowDialog();
        }
    }
}
