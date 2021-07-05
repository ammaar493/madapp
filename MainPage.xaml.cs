using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace Assignment
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        string lati;
        string longi;
        string filepath;
        DateTime currentDateTime = DateTime.Now;

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var personList = await App.SQLiteDb.GetItemsAsync();
            if (personList != null)
            {
                lstNames.ItemsSource = personList;
            }
        }

        private async void btnCamera_Clicked(object sender, EventArgs e)
        {
            

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Error", "No camera app exist.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                Directory = "MyCam",
                Name = "abc.jpg"
            });

            if (file == null)
                return;
            filepath = file.Path;
            await DisplayAlert("File Location", file.Path, "OK");

        }

        private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location != null)
                {

                    lati = location.Latitude.ToString();
                    longi = location.Longitude.ToString();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }

            if (!string.IsNullOrEmpty(txtname.Text) && !string.IsNullOrEmpty(txtcontact.Text) && !string.IsNullOrEmpty(txtemail.Text) && !string.IsNullOrEmpty(txtuniversity.Text) && !string.IsNullOrEmpty(txtranking.Text) && !string.IsNullOrEmpty(txtdiscipline.Text))
            {
                Review _review = new Review()
                {
                    name = txtname.Text,
                    email = txtemail.Text,
                    contact = Convert.ToInt32(txtcontact.Text),
                    ranking = Convert.ToInt32(txtranking.Text),
                    discpline = txtdiscipline.Text,
                    longitude = longi,
                    latitude= lati,
                    filepath= filepath,
                    university= txtuniversity.Text,
                    datetime = currentDateTime
                };

                await App.SQLiteDb.SaveItemAsync(_review);
                txtname.Text = string.Empty;
                txtemail.Text = string.Empty;
                txtcontact.Text = string.Empty;
                txtranking.Text = string.Empty;
                txtdiscipline.Text = string.Empty;
                txtuniversity.Text = string.Empty;
                await DisplayAlert("Alert", "Transaction successful", "ok");

                var personList = await App.SQLiteDb.GetItemsAsync();
                if (personList != null)
                {
                    lstNames.ItemsSource = personList;
                }
            }
            else
            {
                await DisplayAlert("Alert", "Please enter required fields", "Ok");
            }
        }

        private async void btnyes_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Welcome", "Please fill all fields before you go..!", "Ok");
        }

        private async void btnno_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Education Alert", "Please keep safe distance", "Ok");
        }
    }
}
