using System;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace ScannerZXing.Paginas
{
    public partial class PaginaMenu : ContentPage
    {
        async void btnEscanear_Clicked(object sender, EventArgs e)
        {
            var pagina = new ZXingScannerPage();
            await Navigation.PushAsync(pagina);
            
            pagina.OnScanResult += (resultado) =>
            {
                pagina.IsScanning = false;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    lblResultado.Text = resultado.Text;
                });
            };
        }

        public PaginaMenu()
        {
            InitializeComponent();
        }
    }
}
