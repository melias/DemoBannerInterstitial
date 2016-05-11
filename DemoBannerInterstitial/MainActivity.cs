using System.ComponentModel;
using System.Threading;
using Android.App;
using Android.Gms.Ads;
using Android.OS;
using Android.Widget;
using DemoBannerInterstitial.Ads;

namespace DemoBannerInterstitial
{
    [Activity(Label = "DemoBannerInterstitial", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        BackgroundWorker _bgWorker;
        private InterstitialAd _adInterstitial;
        private AdView _adView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            var button = FindViewById<Button>(Resource.Id.MyButton);

            //#########################################################
            // Call banner interstitial for click button
            button.Click += delegate { CallInterstitial(); };
                        
            // Banner what stay in bottom
            CallBanner();

            // Banner interstitial open each 1 minute
            _bgWorker = new BackgroundWorker();
            _bgWorker.DoWork += BgWorkerDoWork;
            _bgWorker.RunWorkerAsync();
            //#########################################################
        }

        public void BgWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(60000); //each 1 minute
                RunOnUiThread(CallInterstitial);


                //if you want clear banner and after open again
                /*
                Thread.Sleep(10000); //10 secunds
                RunOnUiThread(ClearBanner);
                Thread.Sleep(10000); //10 secunds
                RunOnUiThread(CallBanner);
                */
            }
        }
        public void CallInterstitial()
        {
            if (_adInterstitial != null)
                return;
            var intlistener = new AdlistenerCustom();
            _adInterstitial = AdWrapper.ConstructFullPageAdd(this, "Your_admob_id_here");
            intlistener.AdLoaded += () => { if (_adInterstitial.IsLoaded) _adInterstitial.Show(); };
            _adInterstitial.AdListener = intlistener;
            _adInterstitial.CustomBuild();
            intlistener.AdClosed += (() => _adInterstitial = null);
        }
        public void CallBanner()
        {
            var listener = new AdlistenerCustom();
            listener.AdClosed += (() => _adView = null);
            _adView = AdWrapper.ConstructStandardBanner(this, AdSize.SmartBanner, "Your_admob_id_here");
            listener.AdLoaded += () => { };
            _adView.AdListener = listener;
            var ad = _adView.CustomBuild();
            var layout = (AdView)FindViewById(Resource.Id.adView);
            layout.AddView(ad);
        }
        public void ClearBanner()
        {
            var listener = new AdlistenerCustom();
            _adView.RemoveAllViews();
            listener.AdClosed += (() => _adView = null);
            listener.AdLoaded += () => { };
            var layout = (AdView)FindViewById(Resource.Id.adView);
            layout.RemoveAllViews();
        }
    }
}

