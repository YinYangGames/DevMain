using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsManager : MonoBehaviour
{
    public bool testMode = false;
    public string AndroidID = "3897231";
    public string IosID = "3897230";

    public string BannderID = "Banner";
    public string RewardedID = "rewardedVideo";
    public string InterstitialID = "video";
    private void Start()
    {
       // Advertisement.AddListener(this);
#if UNITY_ANDROID
Advertisement.Initialize(AndroidID,testMode);
#else
       // Advertisement.Initialize(IosID, testMode);
#endif


    }

    public void ShowRewardAd()
    {
      //  if (Advertisement.IsReady(RewardedID))
        {
      //      Advertisement.Show(RewardedID);
        }
    }
    public void ShowInterstitialAd()
    {
      //  if (Advertisement.IsReady(InterstitialID))
        {
     //       Advertisement.Show(InterstitialID);
        }
    }
    public void ShowBannerAd()
    {
        StartCoroutine(ShowBanner());
    }
    public IEnumerator ShowBanner()
    {
     //   while (Advertisement.IsReady(BannderID))
        {
            yield return new WaitForSeconds(0.5f);
        }
     //   Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
      //  Advertisement.Banner.Show(BannderID);
        Debug.Log("Bannder ADS");
    }

    public void OnUnityAdsReady(string placementId)
    {
      
    }

    public void OnUnityAdsDidError(string message)
    {
      
    }

    public void OnUnityAdsDidStart(string placementId)
    {
       
    }

  
}
