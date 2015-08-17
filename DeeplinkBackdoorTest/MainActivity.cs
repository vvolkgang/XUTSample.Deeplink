using System;
using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Java.Interop;

namespace DeeplinkBackdoorTest
{
    [Activity(Label = "DeeplinkBackdoorTest", MainLauncher = true, Icon = "@drawable/icon")]
    [IntentFilter(new[] { Intent.ActionView },
        Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable},
        DataScheme = "dementedVice",
        DataHost = "DementedViceDotCom")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            var statusView = FindViewById<TextView>(Resource.Id.StatusView);

            statusView.Click += OpenDeeplink;
            if (Intent.Scheme == "dementedVice")
                statusView.Text = "Opened from deeplink!";
          

        }

        public void OpenDeeplink(object sender, EventArgs eventArgs)
        {
            OpenLink("dementedVice://DementedViceDotCom");
        }

        [Export]
        public void InvokeDeepLink()
        {
            OpenLink("dementedVice://DementedViceDotCom");
        }

        [Preserve]
        [Java.Interop.Export]
        public void InvokeDeepLink(string url)
        {
            OpenLink(url);
        }

        private void OpenLink(string url)
        {
            var uri = Android.Net.Uri.Parse(url);
            var intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);
        }
    }
}

