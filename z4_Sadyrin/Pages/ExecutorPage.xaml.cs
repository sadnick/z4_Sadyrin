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

            var allTask = z4_train_SadyrinEntities1.GetContext().StatusTask.ToList();
            allTask.Insert(0, new StatusTask
            {
                Status = "Все типы"

            });

            ComboType.ItemsSource = allTask;

            ComboType.SelectedIndex = 0;

            var currentTask = z4_train_SadyrinEntities1.GetContext().Task.ToList();
            LVExecutor.ItemsSource = currentTask;
        }

        private void UpdateExecutor()
        {
            var currentExecutor = z4_train_SadyrinEntities1.GetContext().StatusTask.ToList();

            if (ComboType.SelectedIndex > 0)
                currentExecutor = currentExecutor.Where(p => p.Status.Contains(ComboType.SelectedItem as string)).ToList();

            currentExecutor = currentExecutor.Where(p => p.Status.ToLower().Contains(TboxSearch.Text.ToLower())).ToList();

            LVExecutor.ItemsSource = currentExecutor.OrderBy(p => p.Status).ToList();

        }

        private void TboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CheckActual_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CheckActual_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}