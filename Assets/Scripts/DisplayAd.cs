using GoogleMobileAds.Api;
using System;
using UnityEngine;

public class DisplayAd : MonoBehaviour
{
    private RewardedAd rewardedAd;

    [SerializeField]
    private string adUnitId;

    [SerializeField]
    private string test;

    [SerializeField]
    private bool isTesting = false;

    private static bool isInit = false;

    public static event Action<int> BonusHealth;

    public void Awake()
    {
#if UNITY_EDITOR
        if (isTesting)
            adUnitId = test;
#endif
        if (!isInit)
        {
            RequestConfiguration requestConfiguration =
                new RequestConfiguration.Builder()
                .SetSameAppKeyEnabled(true).build();
            MobileAds.SetRequestConfiguration(requestConfiguration);

            // Initialize the Google Mobile Ads SDK.
            MobileAds.Initialize(initStatus => { });
            isInit = true;
        }
        DontDestroyOnLoad(gameObject);
        InitAds();
    }

    private void InitAds()
    {
        rewardedAd = new RewardedAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        rewardedAd.LoadAd(request);

        // Called when an ad request has successfully loaded.
        rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;
    }

    public void DisplayAnAd()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.LoadAdError.GetMessage());
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.AdError.GetMessage());
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        rewardedAd.LoadAd(request);
        print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
        BonusHealth?.Invoke((int)amount);
    }
}