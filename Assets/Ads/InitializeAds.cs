using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InitializeAds : MonoBehaviour, IUnityAdsInitializationListener
{
    public string androidGameId;
    public string iosGameId;

    public bool isTestingMode = true;

    string gameId;

    private void Awake()
    {
        InitializeAd();
    }
    void InitializeAd()
    {

#if UNITY_IOS
    gameId = iosGameId;
#elif UNITY_ANDROID
    gameId = androidGameId;
#elif UNITY_EDITOR
#endif

        if (Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, isTestingMode, this); 
        }
    }

    void IUnityAdsInitializationListener.OnInitializationComplete()
    {
        print("Ads Initialized");
    }

    void IUnityAdsInitializationListener.OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        print("Ads failed to Initialize");        
    }
}
