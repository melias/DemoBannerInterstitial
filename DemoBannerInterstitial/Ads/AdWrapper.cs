using Android.Content;
using Android.Gms.Ads;

namespace DemoBannerInterstitial.Ads
{
    public static class AdWrapper
    {
        public static InterstitialAd ConstructFullPageAdd(Context con, string unitId)
        {
            var ad = new InterstitialAd(con) { AdUnitId = unitId };
            return ad;
        }

        public static AdView ConstructStandardBanner(Context con, AdSize adsize, string unitId)
        {
            var ad = new AdView(con) { AdSize = adsize, AdUnitId = unitId };
            return ad;
        }

        public static InterstitialAd CustomBuild(this InterstitialAd ad)
        {
            var requestbuilder = new AdRequest.Builder();
            ad.LoadAd(requestbuilder
                .AddTestDevice(AdRequest.DeviceIdEmulator) //comment that line for RELEASE
                .Build());
            return ad;
        }

        public static AdView CustomBuild(this AdView ad)
        {
            var requestbuilder = new AdRequest.Builder();
            ad.LoadAd(requestbuilder
                .AddTestDevice(AdRequest.DeviceIdEmulator) //comment that line for RELEASE
                .Build());
            return ad;
        }

    }
}