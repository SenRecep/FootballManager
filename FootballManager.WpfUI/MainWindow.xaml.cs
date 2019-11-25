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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        #region User
        //Adress adress = ApiCenter.getData<Adress>(await ApiCenter.GetAsync("Adress/1"));
        //User user = new User()
        //{
        //    Firstname = "Murat",
        //    Lastname = "Şen",
        //    Email = "kefkenahsapdekorasyon@gmail.com",
        //    Adress = adress,
        //    Password = "bubirsifre",
        //};
        //EntityHttpResponse entityHttpResponse = await ApiCenter.CreateAsync(user, "User/Create");
        //IEnumerable<User> datas = ApiCenter.getData<IEnumerable<User>>(await ApiCenter.GetAsync("User"));
        #endregion
        #region Adress
        //Postalcode data = ApiCenter.getData<Postalcode>(await ApiCenter.GetAsync("PostalCode/1"));
        //Adress adress = new Adress()
        //{
        //    Adresses = "Turkiye/Istanbul/Gokturk No:61 D:3",
        //    PostalCode = data,
        //};
        //EntityHttpResponse entityHttpResponse = await ApiCenter.CreateAsync(adress, "Adress/Create");
        #endregion
        #region CRUD PostalCode
        //EntityHttpResponse entityHttpResponse = await ApiCenter.CreateAsync(postalcode, "PostalCode/Create");
        //IEnumerable<Postalcode> datas = ApiCenter.getData<IEnumerable<Postalcode>>(await ApiCenter.GetAsync("PostalCode"));
        //Postalcode data = ApiCenter.getData<Postalcode>(await ApiCenter.GetAsync("PostalCode/1"));
        //EntityHttpResponse entityHttpResponse = await ApiCenter.UpdateAsync(data, "PostalCode/Update");
        //EntityHttpResponse entityHttpResponse = await ApiCenter.DeleteAsync("2", "PostalCode");
        #endregion
    }
}
