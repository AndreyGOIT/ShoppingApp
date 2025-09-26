using System.Collections.ObjectModel;
using Newtonsoft.Json;
using ShopingApp.Models;

namespace ShopingApp
{
    public partial class MainPage : ContentPage
    {
     
        public MainPage()
        {
            InitializeComponent();
            LoadDataFromRestAPI();
        }

        // LISTAN HAKEMINEN BACKENDISTÄ
        public async Task LoadDataFromRestAPI()
        {

            // Latausilmoitus näkyviin
            Loading_label.IsVisible = true;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://shoppingbackendmob.azurewebsites.net");
            string json = await client.GetStringAsync("/api/shoplist");

            // Deserialisoidaan json muodosta C# muotoon
            IEnumerable<Shoplist> ienumShoplist = JsonConvert.DeserializeObject<Shoplist[]>(json);

            ObservableCollection<Shoplist> Shoplist = new ObservableCollection<Shoplist>(ienumShoplist);

            // Setting the ItemSource of ListView
            itemList.ItemsSource = Shoplist;

            // Latausilmoitus piiloon
            Loading_label.IsVisible = false;
        }

    }

}
