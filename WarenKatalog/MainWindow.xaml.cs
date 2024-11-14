using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WarenKatalog;

public partial class MainWindow : Window
{
    public HttpClient client = new();
    public static List<Products> allProducts = new();

    public MainWindow()
    {
        InitializeComponent();
        InitializeContent();
    }

    private void lbProductList_OnSelectionChanged( object sender , SelectionChangedEventArgs e )
    {
        if ( lbProductList.SelectedIndex != -1 )
        {
            tbProductName.Text = lbProductList.SelectedItem.ToString();
            tbProductPrice.Text = allProducts [ lbProductList.SelectedIndex ].Details?.Price.ToString( "C" ) ?? "N/A";
            tbProductBrand.Text = allProducts [ lbProductList.SelectedIndex ].Details?.Vendors? [ 0 ].Name ?? "N/A";
            imgProductImage.Source = new BitmapImage( new Uri( "https://api.predic8.de" + allProducts [ lbProductList.SelectedIndex ].Details?.Image_link ) );
        }
    }

    public async void InitializeContent()
    {
        string baseUrl = "https://api.predic8.de";
        string urlExtension = "/shop/v2/products/";

        while ( !string.IsNullOrEmpty( urlExtension ) )
        {
            var root = await client.GetFromJsonAsync<RootProducts>( baseUrl + urlExtension );
            if ( root?.Products != null )
            {
                allProducts.AddRange( root.Products );
            }

            urlExtension = root?.Meta?.Next_link ?? string.Empty;
        }

        Parallel.ForEach( allProducts , async p =>
        {
            p.Details = await client.GetFromJsonAsync<ProductDetails>( baseUrl + p.Self_link );
        } );

        lbProductList.ItemsSource = allProducts.Select( x => x.Name );
    }
}