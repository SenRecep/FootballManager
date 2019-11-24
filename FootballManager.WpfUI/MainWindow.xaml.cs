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
        public async void Add(User user)
        {
            //IEnumerable<User> datas = ApiCenter.getData<IEnumerable<User>>(await ApiCenter.GetAsync("User"));
            //User data = ApiCenter.getData<User>(await ApiCenter.GetAsync("User/5"));
            //data.Firstname = "Artik Duzellll";
            EntityHttpResponse entityHttpResponse = await ApiCenter.CreateAsync(user, "User/Create");
            //EntityHttpResponse entityHttpResponse = await ApiCenter.UpdateAsync(data, "User/Update");
            //EntityHttpResponse entityHttpResponse = await ApiCenter.DeleteAsync("5", "User/");
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Add(new User()
            {
                Firstname = "Recep",
                Lastname = "Sen",
                Email = "67rsen00@gmail.com",
                Password = "patates",
                Adress = new Adress()
                {
                    Adresses = "Turkiye/Istanbul/Gokturk No:61 D:3",
                    PostalCode = new Postalcode()
                    {
                        City = "Istanbul",
                        AdressPostalCode = 3477
                    }
                }
            });
        }
    }
}
