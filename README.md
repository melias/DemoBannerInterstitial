# DemoBannerInterstitial
This Demonstration is as use the AdMob Banner and Interstitial without complication.

Usage:
```html
  Xamarin in VisualStudio for build that Demo.
```

Simple and easy to monetize your apps and games.

Example Code:
```C#
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
```

Note: This Demo has three calls for AdMob plugin(event click for the button, CallBanner direct call and BackgroundWorker for Interstitial). 
  
Observation: 
You need change the tag "Your_admob_id_here" in /Resourses/layout/Main.axml source and MainActivity.cs CallInterstitial() and CallBanner() for your Admob key.

For finish, it have other call ClearBanner(), that method clean the Banner for your tests.
