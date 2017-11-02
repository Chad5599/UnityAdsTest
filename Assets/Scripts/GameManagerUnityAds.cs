using System.Collections;

using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class GameManagerUnityAds : MonoBehaviour
{
    public Button UnityRewardedAdsButton;
    public Button UnitySkipAdsButton;

    public Text log;
    public Text coins;

    private int totalCoins = 0;

    void Start()
    {
        Button rewardBtn = UnityRewardedAdsButton.GetComponent<Button>();
        rewardBtn.onClick.AddListener(ShowRewardedAd);

        Button skipBtn = UnitySkipAdsButton.GetComponent<Button>();
        skipBtn.onClick.AddListener(ShowSkipAd);

        SetButtonsFalse();

        StartCoroutine(ShowButtonWhenAdsReady());
    }

    IEnumerator ShowButtonWhenAdsReady()
    {
        while (!Advertisement.IsReady())
            yield return null;
        
        UnityRewardedAdsButton.interactable = false;
        UnitySkipAdsButton.interactable = false;

        log.text = "Unity Ads Ready let the game earn money. Watch it. Watch it.";
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            log.text = "Unity Rewarded ads button pressed";

            ShowOptions options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    public void ShowSkipAd()
    {
        if (Advertisement.IsReady("video"))
        {
            log.text = "Unity skip ads button pressed";

            ShowOptions options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("video", options);
        }
    }

    private void HandleShowResult(ShowResult result) // result is an enum argument
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The Unity ad was successfully shown.");

                log.text = "The Unity ad was successfully shown.";

                totalCoins += 5;
                coins.text = totalCoins.ToString();

                SetButtonsFalse();

                StartCoroutine(ShowButtonWhenAdsReady());// again checking when the ads will available to watch.

                break;

            case ShowResult.Skipped:
                
                Debug.Log("The Unity ad was skipped before reaching the end.");
                log.text = "The Unity ad was skipped before reaching the end.";

                SetButtonsFalse();

                break;

            case ShowResult.Failed:
                
                Debug.LogError("The Unity ad failed to be shown.");
                log.text = "The Unity ad failed to be shown.";

                SetButtonsFalse();

                break;

        }
    }

    public void SetButtonsFalse()
    {
        UnityRewardedAdsButton.interactable = false;
        UnitySkipAdsButton.interactable = false;
    }
}
