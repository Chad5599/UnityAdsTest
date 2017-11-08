using System.Collections;

using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using System;

public class GameManagerAdmobAds : MonoBehaviour
{
    public Button requestBannerButton;
    public Button destroyBannerButton;
    public Button requestInterstitialButton;
    public Button showInterstitialButton;
    public Button destroyInterstitialButton;
    public Button requestRewardedVideoButton;
    public Button showRewardedVideoButton;

    public Text log;
    public Text statusAds;
    public Text coins;

    private int totalCoins = 0;

    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardBasedVideoAd rewardBasedVideo;

    //public static string key = "pub-6634668988903516";

    //private static string outputMessage = string.Empty;

    //public static string OutputMessage
    //{
    //    set { outputMessage = value; }
    //}

    //public string AndroidPublicKey
    //{
    //    get { return key; }
    //}

    void Start()
    {
        Button btn1 = requestBannerButton.GetComponent<Button>();
        btn1.onClick.AddListener(RequestBanner);
        Button btn2 = destroyBannerButton.GetComponent<Button>();
        btn2.onClick.AddListener(DestroyBanner);
        Button btn5 = requestInterstitialButton.GetComponent<Button>();
        btn5.onClick.AddListener(RequestInterstitial);
        Button btn6 = showInterstitialButton.GetComponent<Button>();
        btn6.onClick.AddListener(ShowInterstitial);
        Button btn9 = destroyInterstitialButton.GetComponent<Button>();
        btn9.onClick.AddListener(DestroyInterstitial);
        Button btn7 = requestRewardedVideoButton.GetComponent<Button>();
        btn7.onClick.AddListener(RequestRewardBasedVideo);
        Button btn8 = showRewardedVideoButton.GetComponent<Button>();
        btn8.onClick.AddListener(ShowRewardBasedVideo);



       
        #if UNITY_ANDROID
        string appId = "ca-app-pub-6634668988903516~5302587017";
        #elif UNITY_IPHONE
        string appId = "ca-app-pub-3940256099942544~1458002511";
        #else
        string appId = "unexpected_platform";
        #endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        // Get singleton reward based video ad reference.
        rewardBasedVideo = RewardBasedVideoAd.Instance;

        // RewardBasedVideoAd is a singleton, so handlers should only be registered once.
        // Called when an ad request has successfully loaded.
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        // Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

    }

    private void RequestBanner()
    {

        #if UNITY_ANDROID
        string bannerId = "ca-app-pub-6634668988903516/7334564429";
        #elif UNITY_IPHONE
        string bannerId = "add bannerId for IOS";
        #else
        string bannerId = "unexpected_platform";
        #endif

        // Clean up banner ad before creating a new one.
        if (bannerView != null)
        {
            bannerView.Destroy();
        }

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(bannerId, AdSize.SmartBanner, AdPosition.Top);

        // Register for ad events.
        // Called when an ad request has successfully loaded.
        bannerView.OnAdLoaded += HandleAdLoaded;
        // Called when an ad request failed to load.
        bannerView.OnAdFailedToLoad += HandleAdFailedToLoad;
        // Called when an ad is clicked.
        bannerView.OnAdOpening += HandleAdOpened;
        // Called when the user returned from the app after an ad click.
        bannerView.OnAdClosed += HandleAdClosed;
        // Called when the ad click caused the user to leave the application.
        bannerView.OnAdLeavingApplication += HandleAdLeftApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);


        statusAds.text = "Processing banner";
        log.text = "button RequestBanner() pressed";
    }

    public void DestroyBanner()
    {
        bannerView.Destroy();
        log.text = "button DestroyBanner() pressed";
    }

    private void RequestInterstitial()
    {

        #if UNITY_ANDROID
        string interstitialId = "ca-app-pub-6634668988903516/7049469875";
        #elif UNITY_IPHONE
        string interstitialId = "add interstitialId for IOS";
        #else
        string interstitialId = "unexpected_platform";
        #endif

        // Clean up interstitial ad before creating a new one.
        if (interstitial != null)
        {
            interstitial.Destroy();
        }

        // Create an interstitial.
        interstitial = new InterstitialAd(interstitialId);

        // Register for ad events.
        // Called when an ad request has successfully loaded.
        interstitial.OnAdLoaded += HandleInterstitialLoaded;
        // Called when an ad request failed to load.
        interstitial.OnAdFailedToLoad += HandleInterstitialFailedToLoad;
        // Called when an ad is shown.
        interstitial.OnAdOpening += HandleInterstitialOpened;
        // Called when the ad is closed.
        interstitial.OnAdClosed += HandleInterstitialClosed;
        // Called when the ad click caused the user to leave the application.
        interstitial.OnAdLeavingApplication += HandleInterstitialLeftApplication;

          
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);

       
       
        statusAds.text = "Processing Interstitial";
        log.text = "button RequestInerstitial() pressed";
    }

    private void ShowInterstitial()
    {
        log.text = "button ShowInterstitial() pressed";
        if (interstitial.IsLoaded())
        {
            statusAds.text = "Showing Interstitial";
            interstitial.Show();
        }
        else
        {
            log.text = "Interstitial is not ready yet";
            Debug.Log("Interstitial is not ready yet");
        }
    }

    public void DestroyInterstitial()
    {
        statusAds.text = "Destroyed Interstitial";
        interstitial.Destroy();
        log.text = "button DestroyInterstitial() pressed";
    }

    private void RequestRewardBasedVideo()
    {

        #if UNITY_ANDROID
        string rewardedId = "ca-app-pub-6634668988903516/2317331027";
        #elif UNITY_IPHONE
        string rewardedId = "add rewardedId for IOS";
        #else
        string interstitialId = "unexpected_platform";
        #endif
       
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded video ad with the request.
        rewardBasedVideo.LoadAd(request, rewardedId);
       
        statusAds.text = "Processing Video";
        log.text = "button RequestRewardBasedVideo() pressed";
    }

    private void ShowRewardBasedVideo()
    {
        log.text = "button ShowRewardBasedVideo() pressed";
        if (rewardBasedVideo.IsLoaded())
        {
            statusAds.text = "Showing video";
            rewardBasedVideo.Show();
        }
        else
        {
            log.text = "Reward based video ad is not ready yet";
            Debug.Log("Reward based video ad is not ready yet");
        }
    }

    #region Banner callback handlers

    public void HandleAdLoaded(object sender, EventArgs args)
    {
        statusAds.text = "Loaded Banner";
        Debug.Log("HandleAdLoaded event received :");
    }

    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        statusAds.text = "Failed Banner";
        Debug.Log("HandleFailedToReceiveAd event received with message: " + args.Message);
    }

    public void HandleAdOpened(object sender, EventArgs args)
    {
        Debug.Log("HandleAdOpened event received");
    }

    public void HandleAdClosed(object sender, EventArgs args)
    {
        Debug.Log("HandleAdClosed event received");
    }

    public void HandleAdLeftApplication(object sender, EventArgs args)
    {
        Debug.Log("HandleAdLeftApplication event received");
    }

    #endregion

    #region Interstitial callback handlers

    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {
        statusAds.text = "Loaded Interstitial";
        Debug.Log("HandleInterstitialLoaded event received");
    }

    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        statusAds.text = "Failed Interstitial";
        Debug.Log("HandleInterstitialFailedToLoad event received with message: " + args.Message);
    }

    public void HandleInterstitialOpened(object sender, EventArgs args)
    {
        Debug.Log("HandleInterstitialOpened event received");
    }

    public void HandleInterstitialClosed(object sender, EventArgs args)
    {
        Debug.Log("HandleInterstitialClosed event received");
    }

    public void HandleInterstitialLeftApplication(object sender, EventArgs args)
    {
        Debug.Log("HandleInterstitialLeftApplication event received");
    }

    #endregion

    #region RewardBasedVideo callback handlers

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        statusAds.text = "Loaded Video";
        Debug.Log("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        statusAds.text = "Failed video";
        Debug.Log("HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        Debug.Log("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        Debug.Log("HandleRewardBasedVideoStarted event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        Debug.Log("HandleRewardBasedVideoClosed event received");
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        string type = args.Type;     // this is the string we can set in add setting on admob
        double amount = args.Amount; // this is the amount we can set in add setting on admob

        statusAds.text = "Rewarded";
        totalCoins += 5;
        coins.text = totalCoins.ToString();

        Debug.Log("HandleRewardBasedVideoRewarded event received");
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        totalCoins += 10;
        coins.text = totalCoins.ToString();
        Debug.Log("HandleRewardBasedVideoLeftApplication event received");
    }

    #endregion

}
