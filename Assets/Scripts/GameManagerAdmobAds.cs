using System.Collections;

using UnityEngine;
using UnityEngine.UI;

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

    }


    public void RequestBanner()
    {
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
