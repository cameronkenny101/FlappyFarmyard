using System.Collections;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{

    public string BannerId = "";
    public string inter = "";
    InterstitialAd interstitial;
    BannerView bannerView;

    public static AdManager instance;


    void Start()
    {
        RequestBanner();
        RequestInterstitial();


        DontDestroyOnLoad(this.gameObject);
    

        instance = this;
    }

    private void RequestBanner()
    {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = BannerId;
#elif UNITY_IPHONE
        string adUnitId = BannerId;
#else
        string adUnitId = BannerId;
#endif

         // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
        callBanner();
    }

    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = inter;
#elif UNITY_IPHONE
		string adUnitId = inter;
#else
		string adUnitId = inter;
#endif

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
    }



    public void CallInterstertial()             ///Called from other script
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

    public void callBanner()
    {
        bannerView.Show();
    }

    

}
