using System.Collections;

using UnityEngine;
using UnityEngine.UI;

using GoogleMobileAds.Api;

public class GameManagerAdmobAds : MonoBehaviour
{
    public Button AdmobAdsButton;

    public Text log;
    public Text coins;

    private int totalCoins = 0;

    void Start()
    {
        Button rewardBtn = AdmobAdsButton.GetComponent<Button>();
        rewardBtn.onClick.AddListener(ShowRewardedAd);

        SetButtonsFalse();

        StartCoroutine(ShowButtonWhenAdsReady());
    }

    IEnumerator ShowButtonWhenAdsReady()
    {
        while (true)
            yield return null;
        AdmobAdsButton.interactable = true;
        log.text = "Unity Ads Ready let the game earn money. Watch it. Watch it.";
    }

    public void ShowRewardedAd()
    {
       
    }

    public void SetButtonsFalse()
    {
        AdmobAdsButton.interactable = false;
    }
}
