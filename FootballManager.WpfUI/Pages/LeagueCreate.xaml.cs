using FootballManager.Bll.Concrete;
using FootballManager.Bll.Helpers;
using FootBallManager.Entities.ComplexTypes;
using FootBallManager.Entities.Concrete;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Windows.Controls;

namespace FootballManager.WpfUI.Pages
{
    /// <summary>
    /// Interaction logic for LeagueCreate.xaml
    /// </summary>
    public partial class LeagueCreate : Page
    {
        public LeagueCreate()
        {
            InitializeComponent();
            Loaded += LeagueCreate_Loaded;
        }

        private async void LeagueCreate_Loaded(object sender, RoutedEventArgs e)
        {
            EntityHttpResponse Http_seasons = await ApiCenter.GetAsync("Season");
            EntityHttpResponse Http_team = await ApiCenter.GetAsync("Team");
            ICollection<Team> Teams;
            ICollection<Season> Seasons;
            if (Http_seasons.IsTrue && Http_team.IsTrue)
            {
                Seasons = ApiCenter.getData<ICollection<Season>>(Http_seasons);
                Teams = ApiCenter.getData<ICollection<Team>>(Http_team);
                LB_Teams.ItemsSource = Teams;
                CB_Season.ItemsSource = Seasons;
            }
            else
            {
                MessageBox.Show("Sayfa yuklenirken sorun olustu lutfen daha sonra tekrar deneyiniz.");
            }
        }

        private async void submit_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(leagueName.Text) && CB_Season.SelectedIndex > -1 && LB_Teams.SelectedItems.Count > 1)
            {
                League league = new League()
                {
                    Name = leagueName.Text,
                    Seasonid = (CB_Season.SelectedItem as Season).id,
                    Season = (CB_Season.SelectedItem as Season)
                };
                EntityHttpResponse Httpleague = await ApiCenter.CreateAsync<League>(league, "League/Create");
                if (Httpleague.IsTrue)
                {
                    var teams = LB_Teams.SelectedItems.Cast<Team>().ToList();
                    List<Matches> Matches = new List<Matches>();
                    foreach (Team item in teams)
                    {
                        var lt= new LeagueTeam()
                        {
                            Team = item,
                            Teamid = item.id,
                            League =league,
                            Leagueid =league.id,
                        };
                        EntityHttpResponse entityHttpResponse= await ApiCenter.CreateAsync<LeagueTeam>(lt, "LeagueTeam/Create");
                    }
                    int MatchCount = 0;
                    for (int i = 0; i < teams.Count; i++)
                    {
                        Team firstTeam = teams[i];
                        for (int j = i + 1; j < teams.Count; j++)
                        {
                            Team SecondTeam = teams[j];
                            Matches.Add(new Matches()
                            {
                                FirstTeam = firstTeam,
                                SecondTeam = SecondTeam
                            });
                            MatchCount++;
                        }
                    }

                    foreach (var item in Matches)
                    {
                        int matchday = 365 / MatchCount;
                        if (matchday == 365) matchday = 0;
                        item.Date = league.Season.Date.AddDays(matchday);
                        EntityHttpResponse entityHttpResponse =await ApiCenter.CreateAsync<Matches>(item, "Matches/Create");
                    }

                    MessageBox.Show("League Olusturuldu");
                    NavigationService.Navigate(null);
                }
                else
                {
                    MessageBox.Show("Sistemsel bir sikintidan dolayi ekleme gerceklesmedi lutfen tekrar deneyiniz.");
                }
            }
            else
                MessageBox.Show("Lutfen, Gerekli Tum Alanlari Doldurunuz\nTakim Adini Giriniiz\nSezon Seciniz\nEn Az Iki Takim Seciniz");
        }
    }
}
