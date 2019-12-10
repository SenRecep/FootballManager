using FootballManager.Bll.Concrete;
using FootballManager.Bll.Helpers;
using FootBallManager.Entities.Concrete;
using Newtonsoft.Json;
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

namespace FootballManager.WpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void frm_Loader_Click(object sender, RoutedEventArgs e)
        {
            if (sender!=null && sender is MenuItem menuItem)
            {
                page_manager.Source = new Uri($"/FootballManager.WpfUI;component/Pages/{menuItem.Tag}.xaml", UriKind.RelativeOrAbsolute);
            }
        }
    }
}
