using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class LoadBanner : MonoBehaviour, IUnityAdsInitializationListener
{
    private string androidUnitId = "3940507";
    private string iosUnitId = "3940506";

    string adUnitId;

    [SerializeField] BannerPosition bannerPos = BannerPosition.BOTTOM_CENTER;
    public bool _testMode = true;

    private void Start()
    {

#if UNITY_ANDROID
    adUnitId = androidUnitId;
#elif UNITY_IOS
    adUnitId = iosUnitId;
#elif UNITY_EDITOR
    adUnitId = androidUnitId;
#endif
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(adUnitId, _testMode, this);
        }
        Advertisement.Banner.SetPosition(bannerPos);
        LoadBanners();
    }
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    // Implement a method to call when the Load Banner button is clicked:
    public void LoadBanners()
    {
        // Set up options to notify the SDK of load events:
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        // Load the Ad Unit with banner content:
        Advertisement.Banner.Load(adUnitId, options);
    }

    // Implement code to execute when the loadCallback event triggers:
    void OnBannerLoaded()
    {
        Debug.Log("Banner loaded");
    }

    // Implement code to execute when the load errorCallback event triggers:
    void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
        // Optionally execute additional code, such as attempting to load another ad.
    }

    // Implement a method to call when the Show Banner button is clicked:
    void ShowBannerAd()
    {
        // Set up options to notify the SDK of show events:
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };

        // Show the loaded Banner Ad Unit:
        Advertisement.Banner.Show(adUnitId, options);
    }

    // Implement a method to call when the Hide Banner button is clicked:
    void HideBannerAd()
    {
        // Hide the banner:
        Advertisement.Banner.Hide();
    }

    void OnBannerClicked() { }
    void OnBannerShown() { }
    void OnBannerHidden() { }


    //public void LoadBanners()
    //{
    //    BannerLoadOptions options = new BannerLoadOptions
    //    {
    //        loadCallback = OnBannerLoad,
    //        errorCallback = OnBannerLoadError
    //    };

    //    Advertisement.Banner.Load(adUnitId, options);
    //}
    //void OnBannerLoad()
    //{
    //    print("Banner loaded");
    //    ShowBannerAds();
    //}
    //void OnBannerLoadError(string error)
    //{
    //    print("Banner failed to load" + error);
    //}
    //public void ShowBannerAds()
    //{
    //    BannerOptions options = new BannerOptions
    //    {
    //        showCallback = OnBannerShown,
    //        clickCallback = OnBannerClicked,
    //        hideCallback = OnBannerHidden
    //    };

    //    Advertisement.Banner.Show(adUnitId, options);
    //}
    //void OnBannerShown()
    //{

    //}
    //void OnBannerClicked()
    //{

    //}
    //void OnBannerHidden()
    //{

    //}
    //public void HideBannerAd()
    //{
    //    Advertisement.Banner.Hide();
    //}

}
