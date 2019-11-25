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
            //Adress adress = ApiCenter.getData<Adress>(await ApiCenter.GetAsync("Adress/1"));
            //adress.PostalCode= ApiCenter.getData<Postalcode>(await ApiCenter.GetAsync("Postalcode/"+adress.PostalCodeid));
            //User user = new User()
            //{
            //    Firstname="Recep",
            //    Lastname="Şen",
            //    Email="67rsen00@gmail.com",
            //    Adress= adress,
            //    Password="1943332733Rec",
            //};
            //EntityHttpResponse entityHttpResponse = await ApiCenter.CreateAsync(user, "User/Create");
        }


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
