using System.Collections;

using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class GameManagerAdmobAds : MonoBehaviour
{
    public Button requestBannerButton;
    public Button destroyBannerButton;
    public Button requestNativeExpressButton;
    public Button destroyNativeExpressButton;
    public Button requestInerstitialButton;
    public Button showInterstitialButton;
    public Button requestRewardedVideoButton;
    public Button showRewardedVideoButton;
    public Button destroyRewardedVideButton;

    public Text log;
    public Text coins;

    private int totalCoins = 0;

    private BannerView bannerView;
    private InterstitialAd interstitial;
    private NativeExpressAdView nativeExpressAdView;
    private RewardBasedVideoAd rewardBasedVideo;

    void Start()
    {
        Button btn1 = requestBannerButton.GetComponent<Button>();
        btn1.onClick.AddListener(RequestBanner);
        Button btn2 = destroyBannerButton.GetComponent<Button>();
        btn2.onClick.AddListener(DestroyBanner);
        Button btn3 = requestNativeExpressButton.GetComponent<Button>();
        btn3.onClick.AddListener(RequestNativeExpress);
        Button btn4 = destroyNativeExpressButton.GetComponent<Button>();
        btn4.onClick.AddListener(DestroyNativeExpress);
        Button btn5 = requestInerstitialButton.GetComponent<Button>();
        btn5.onClick.AddListener(RequestInerstitial);
        Button btn6 = showInterstitialButton.GetComponent<Button>();
        btn6.onClick.AddListener(ShowInterstitial);
        Button btn7 = requestRewardedVideoButton.GetComponent<Button>();
        btn7.onClick.AddListener(RequestRewardedVideo);
        Button btn8 = showRewardedVideoButton.GetComponent<Button>();
        btn8.onClick.AddListener(ShowRewardedVideo);
        Button btn9 = destroyRewardedVideButton.GetComponent<Button>();
        btn9.onClick.AddListener(DestroyRewardedVide);



       
            #if UNITY_ANDROID
            string appId = "ca-app-pub-3940256099942544~3347511713";
            #elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
            #else
            string appId = "unexpected_platform";
            #endif

            // Initialize the Google Mobile Ads SDK.
            MobileAds.Initialize(appId);

            // Get singleton reward based video ad reference.
            this.rewardBasedVideo = RewardBasedVideoAd.Instance;

            // RewardBasedVideoAd is a singleton, so handlers should only be registered once.
            this.rewardBasedVideo.OnAdLoaded += this.HandleRewardBasedVideoLoaded;
            this.rewardBasedVideo.OnAdFailedToLoad += this.HandleRewardBasedVideoFailedToLoad;
            this.rewardBasedVideo.OnAdOpening += this.HandleRewardBasedVideoOpened;
            this.rewardBasedVideo.OnAdStarted += this.HandleRewardBasedVideoStarted;
            this.rewardBasedVideo.OnAdRewarded += this.HandleRewardBasedVideoRewarded;
            this.rewardBasedVideo.OnAdClosed += this.HandleRewardBasedVideoClosed;
            this.rewardBasedVideo.OnAdLeavingApplication += this.HandleRewardBasedVideoLeftApplication;
           
    }


    public void RequestBanner()
    {
        // These ad units are configured to always serve test ads.
        #if UNITY_EDITOR
        string adUnitId = "unused";
        #elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        #elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        #else
        string adUnitId = "unexpected_platform";
        #endif

        // Clean up banner ad before creating a new one.
        if (this.bannerView != null)
        {
        this.bannerView.Destroy();
        }

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);

        // Register for ad events.
        this.bannerView.OnAdLoaded += this.HandleAdLoaded;
        this.bannerView.OnAdFailedToLoad += this.HandleAdFailedToLoad;
        this.bannerView.OnAdOpening += this.HandleAdOpened;
        this.bannerView.OnAdClosed += this.HandleAdClosed;
        this.bannerView.OnAdLeavingApplication += this.HandleAdLeftApplication;

        // Load a banner ad.
        this.bannerView.LoadAd(this.CreateAdRequest());

        log.text = "button RequestBanner() pressed";
    }

    public void DestroyBanner()
    {
        log.text = "button DestroyBanner() pressed";
    }

    public void RequestNativeExpress()
    {
        log.text = "button RequestNativeExpress() pressed";
    }

    public void DestroyNativeExpress()
    {
        log.text = "button DestroyNativeExpress() pressed";
    }

    public void RequestInerstitial()
    {
        log.text = "button RequestInerstitial() pressed";
    }

    public void ShowInterstitial()
    {
        log.text = "button ShowInterstitial() pressed";
    }

    public void RequestRewardedVideo()
    {
        log.text = "button RequestRewardedVideo() pressed";
    }

    public void ShowRewardedVideo()
    {
        log.text = "button ShowRewardedVideo() pressed";
    }

    public void DestroyRewardedVide()
    {
        log.text = "button DestroyRewardedVide() pressed";
    }

}
