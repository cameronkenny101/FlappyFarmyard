using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using System;
using UnityEngine.Advertisements;
public class AdsManager : MonoBehaviour
{

    #region AdMob
    [Header("Admob")]
    public string adMobAppID = "";
    public string id = "";
    public string interstitalAdMobId = "";
    public string videoAdMobId = "";
    InterstitialAd interstitialAdMob;
    private RewardBasedVideoAd rewardedAd;
    BannerView bannerView;
    AdRequest requestAdMobInterstitial;
    #endregion
    [Space(15)]
    #region
    [Header("UnityAds")]
    public string unityAdsGameId = "";
    public string unityAdsVideoPlacementId = "rewardedVideo";
    #endregion

    public static AdsManager instance;

    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        if (PlayerPrefs.GetString("Ads") != "Off")
        {
            InitializeAds();
        }
    }

    void InitializeAds()
    {

        Advertisement.Initialize(unityAdsGameId);
        //  MobileAds.Initialize(adMobAppID);
        RequestBanner();
        RequestRewardedVideo();
        RequestInterstitial();

    }


    private void RequestInterstitial()
    {
        // Initialize an InterstitialAd.
        interstitialAdMob = new InterstitialAd(interstitalAdMobId);


        // Create an empty ad request.
        requestAdMobInterstitial = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitialAdMob.LoadAd(requestAdMobInterstitial);
    }

    private void RequestRewardedVideo()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request, videoAdMobId);
    }


    private void RequestBanner()
    {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = id;
#elif UNITY_IPHONE
        string adUnitId = id;
#else
        string adUnitId = id;
#endif
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);

        Debug.Log("Show banner Ad");
        ShowBanner();

    }

    void ShowBanner()
    {
        bannerView.Show();
    }

    public void closeBanner()
    {
        bannerView.Hide();
    }

    public void ShowVideoReward()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }


    public void ShowAdMob()
    {
        if (interstitialAdMob.IsLoaded())
        {
            interstitialAdMob.Show();
        }
        else
        {
            interstitialAdMob.LoadAd(requestAdMobInterstitial);
        }
    }

    public void ShowUnityInterstitialAd()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    }


    public void ShowUnityVideoAd()
    {
        if (Advertisement.IsReady("video"))
        {
            Advertisement.Show("video");
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    }

    /*    public void HandleRewardBasedVideoLoadedAdMob(object sender, EventArgs args)
        {
            MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");

        }

        public void HandleRewardBasedVideoFailedToLoadAdMob(object sender, AdFailedToLoadEventArgs args)
        {
            MonoBehaviour.print("HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);

        }

        public void HandleRewardBasedVideoOpenedAdMob(object sender, EventArgs args)
        {
            MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
        }

        public void HandleRewardBasedVideoStartedAdMob(object sender, EventArgs args)
        {
            MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
        }

        public void HandleRewardBasedVideoClosedAdMob(object sender, EventArgs args)
        {
            MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
            this.rewardBasedAdMobVideo.LoadAd(AdMobVideoRequest, videoAdMobId);
        }
*/
    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;


        MonoBehaviour.print("HandleRewardBasedVideoRewarded event received for " + amount.ToString() + " " + type);

    }

    public void HandleRewardBasedVideoLeftApplicationAdMob(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }



}