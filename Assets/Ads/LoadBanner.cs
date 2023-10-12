using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class LoadBanner : MonoBehaviour
{
    public string androidUnitId;
    public string iosUnitId;

    string adUnitId;

    BannerPosition bannerPos = BannerPosition.BOTTOM_CENTER;

    private void Start()
    {

#if UNITY_IOS
    adUnitId = iosUnitId;
#elif UNITY_ANDROID
    adUnitId = androidUnitId;
#endif

        Advertisement.Banner.SetPosition(bannerPos);
        LoadBanners();
    }
    public void LoadBanners()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoad,
            errorCallback = OnBannerLoadError
        };

        Advertisement.Banner.Load(adUnitId, options);
    }
    void OnBannerLoad()
    {
        print("Banner loaded");
        ShowBannerAds();
    }
    void OnBannerLoadError(string error)
    {
        print("Banner failed to load" + error);
    }
    public void ShowBannerAds()
    {
        BannerOptions options = new BannerOptions
        {
            showCallback = OnBannerShown,
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden
        };

        Advertisement.Banner.Show(adUnitId, options);
    }
    void OnBannerShown()
    {

    }
    void OnBannerClicked()
    {

    }
    void OnBannerHidden()
    {

    }
    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }
}
