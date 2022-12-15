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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace z4_Sadyrin.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Task _currentTask = new Task();

        public AddEditPage(Task selectedTask)
        {
            InitializeComponent();

            if (selectedTask != null)
                _currentTask = selectedTask;

            DataContext = _currentTask;
            ComboStatus.ItemsSource = z4_train_SadyrinEntities1.GetContext().StatusTask.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentTask.Title))
                errors.AppendLine("Укажите название задания");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentTask.ID == 0)
                z4_train_SadyrinEntities1.GetContext().Task.Add(_currentTask);


            try
            {
                z4_train_SadyrinEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager1.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager1.MainFrame.GoBack();
        }
    }
}
