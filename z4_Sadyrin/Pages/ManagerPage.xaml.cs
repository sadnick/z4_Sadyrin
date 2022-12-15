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
    /// Логика взаимодействия для ManagerPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        public ManagerPage()
        {
            InitializeComponent();
            var allTypes = z4_train_SadyrinEntities1.GetContext().StatusTask.ToList();

            var currentTask = z4_train_SadyrinEntities1.GetContext().Task.ToList();
            LViewExecutor.ItemsSource = currentTask;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Manager1.MainFrame.GoBack();
        }
    }
}
