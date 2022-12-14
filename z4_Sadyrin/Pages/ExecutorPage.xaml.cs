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
    /// Логика взаимодействия для ExecutorPage.xaml
    /// </summary>
    public partial class ExecutorPage : Page
    {
        public ExecutorPage()
        {
            InitializeComponent();
            var currentTask = z4_train_SadyrinEntities1.GetContext().Task.ToList();
            LVExecutor.ItemsSource = currentTask;
        }
    }
}
