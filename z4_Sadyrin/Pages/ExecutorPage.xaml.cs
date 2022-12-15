using System;
using System.Collections.Generic;
using System.IdentityModel.Protocols.WSTrust;
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
    /// Логика взаимодействия для ExecutorPage.xaml
    /// </summary>
    public partial class ExecutorPage : Page
    {
        public ExecutorPage()
        {
            InitializeComponent();
            var allTypes = z4_train_SadyrinEntities1.GetContext().StatusTask.ToList();
            allTypes.Insert(0, new StatusTask
            {
                Status = "Все типы"
            });
            ComboType.ItemsSource = allTypes;

            ComboType.SelectedIndex = 0;

            var currentTask = z4_train_SadyrinEntities1.GetContext().Task.ToList();
            LVExecutor.ItemsSource = currentTask;

        }

        private void UpdateExecutor()
        {
            var currentExecutor = z4_train_SadyrinEntities1.GetContext().StatusTask.ToList();

            //if (ComboType.SelectedIndex > 0)
            //    currentExecutor = currentExecutor.Where(p => p.Status.Contains(ComboType.SelectedItem as StatusTask)).ToList();

            currentExecutor = currentExecutor.Where(p => p.Status.ToLower().Contains(TboxSearch.Text.ToLower())).ToList();

            LVExecutor.ItemsSource = currentExecutor.OrderBy(p => p.Status).ToList();

        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Manager1.MainFrame.GoBack();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateExecutor();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateExecutor();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager1.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Task));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var agentForRemoving = LVExecutor.SelectedItems.Cast<Task>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {agentForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    z4_train_SadyrinEntities1.GetContext().Task.RemoveRange(agentForRemoving);
                    z4_train_SadyrinEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    LVExecutor.ItemsSource = z4_train_SadyrinEntities1.GetContext().Task.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager1.MainFrame.Navigate(new AddEditPage(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                z4_train_SadyrinEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                LVExecutor.ItemsSource = z4_train_SadyrinEntities1.GetContext().Task.ToList();
            }
        }

        private void TboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}