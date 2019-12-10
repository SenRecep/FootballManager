using FootballManager.Bll.Concrete;
using FootballManager.Bll.Helpers;
using FootBallManager.Entities.ComplexTypes;
using FootBallManager.Entities.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FootballManager.WpfUI.Pages
{
    /// <summary>
    /// Interaction logic for SeasonCreate.xaml
    /// </summary>
    public partial class SeasonCreate : Page
    {
        public SeasonCreate()
        {
            InitializeComponent();
        }

        private async void Create_Season_Click(object sender, RoutedEventArgs e)
        {
            Season season = new Season()
            {
                Date = dp.SelectedDate.Value
            };
            EntityHttpResponse SeasonCreate = await ApiCenter.CreateAsync<Season>(season, "Season/Create");
            if (SeasonCreate.IsTrue)
            {
                MessageBox.Show("Season Basari ile kayit edilmistir");
                NavigationService.Navigate(new LeagueCreate());
            }
            else
            {
                MessageBox.Show("Ekleme Basarisiz");
            }
        }
    }
}
