using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ChartboostSDK {


    public class GameManagerChartboostAds : MonoBehaviour {

        public Button loadVideo;
        public Button showVideo;

        public Text log;

        // Use this for initialization
        void Start () 
        {

            Button btn1 = loadVideo.GetComponent<Button>();
            btn1.onClick.AddListener(LoadVideo);
            Button btn2 = showVideo.GetComponent<Button>();
            btn2.onClick.AddListener(ShowVideo);

            Chartboost.didFailToLoadRewardedVideo += OnVideoLoadingFailed;
            Chartboost.didCacheRewardedVideo += OnVideoLoadingComplete;

        }


        public void LoadVideo()
        {
            Chartboost.cacheRewardedVideo(CBLocation.MainMenu);
            log.text = "Start loading chartboost video";
            Debug.Log("Start loading chartboost video");
        }

        public void ShowVideo()
        {
            if (Chartboost.hasRewardedVideo(CBLocation.MainMenu))
            {
                Chartboost.showRewardedVideo(CBLocation.MainMenu);
                log.text = "Showing Chartboost video";
                Debug.Log("Showing Chartboost video");
            }
            else
            {
                log.text = "No Chartboost video";
                Debug.Log("No Chartboost video");
            }
        }



        public void OnVideoLoadingComplete(CBLocation location)
        {
            log.text = "Chatboost Video loaded" + location;
            Debug.Log("Chatboost Video loaded" + location);
        }

        public void OnVideoLoadingFailed(CBLocation location, CBImpressionError error)
        {
            log.text = "didFailToLoadRewardedVideo: " + error + " at location " + location;
            Debug.Log("didFailToLoadRewardedVideo: " + error + " at location " +location);
        }

    }
}


