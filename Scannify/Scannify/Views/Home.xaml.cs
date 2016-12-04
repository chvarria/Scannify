using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ZXing.Net;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;
using Xamarin.Forms;
using ZXing;

namespace Scannify.Views
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var opciones = new MobileBarcodeScanningOptions
            {
                AutoRotate = false,
                UseFrontCameraIfAvailable = false,
                TryHarder = true
            };

            var scanPage = new ZXingScannerPage(opciones)
            {
                DefaultOverlayTopText = "Scannify",
                DefaultOverlayBottomText = "XXX",
                DefaultOverlayShowFlashButton = true
            };

            scanPage.Title = "Escanea ahora";

            await Navigation.PushAsync(scanPage);

            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();


                    switch (result.BarcodeFormat)
                    {
                            case BarcodeFormat.QR_CODE:
                            ValidarQRCode(result);
                            break;
                    }

                    await DisplayAlert("Scannify",
                        $"{result.Text}   -    {result.BarcodeFormat} - {result.ResultMetadata}",
                        "Aceptar", "Cancelar");
                    await Navigation.PushAsync(new Home());
                });
                scanPage.PauseAnalysis();


            };
        }

        private void ValidarQRCode(Result result)
        {
            if (result.Text.Contains("http://") || result.Text.Contains("https://"))
            {
                Regex urlRx =
                    new Regex(@"((https?|ftp|file)\://|www.)[A-Za-z0-9\.\-]+(/[A-Za-z0-9\?\&\=;\+!'\(\)\*\-\._~%]*)*",RegexOptions.IgnoreCase);
                var response = urlRx.Match(result.Text);

                if (response.Success)
                    Device.OpenUri(new Uri(result.Text));
            }
            else if (result.Text.Contains("geo:"))
            {
                
            }
            else if(result.Text.Contains("BEGIN:VCARD"))
            {
                
            }
            else if (result.Text.Contains("MATMSG:"))
            {
                
            }
            else if (result.Text.Contains("SMSTO:"))
            {
            }

        }
    }
}
