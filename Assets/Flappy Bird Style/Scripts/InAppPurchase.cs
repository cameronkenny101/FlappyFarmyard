using UnityEngine;
using System.Collections;
using UnityEngine.Purchasing;
using System;

public class InAppPurchase : MonoBehaviour, IStoreListener
{

    public string Test_Buy = "ads";
    public string Buy_1 = "";
    public string Buy_2 = "";
    public string Buy_3 = "";
    public string Buy_4 = "";
    public string Buy_5 = "";

    public GameObject adsButton;

    public IStoreController controller;
    private IExtensionProvider extensions;

    String adsEnabled;
    // Use this for initialization
    void Start()
    {
     //   DontDestroyOnLoad(transform.gameObject);
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());


        builder.AddProduct(Test_Buy, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);

        if (PlayerPrefs.GetString("Ads") == "Off")
        {
            adsButton.SetActive(false);
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("IAP Initizalization complete!!");
        this.controller = controller;
        this.extensions = extensions;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("IAP Initizalization FAILED!! " + error.ToString());
    }

    public void OnPurchaseFailed(Product i, PurchaseFailureReason p)
    {
        Debug.Log("IAP purchase FAILED!! " + p.ToString());
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
    {

        if (e.purchasedProduct.definition.id == Test_Buy)
        {
            /// Remove Ads
            adsEnabled = "Off";
            PlayerPrefs.SetString("Ads", adsEnabled);
            adsButton.SetActive(false);
            AdsManager.instance.closeBanner();

        }
        else if (e.purchasedProduct.definition.id == Buy_1)
        {

        }
        else if (e.purchasedProduct.definition.id == Buy_2)
        {

        }
        else if (e.purchasedProduct.definition.id == Buy_3)
        {

        }
        else if (e.purchasedProduct.definition.id == Buy_4)
        {

        }
        else if (e.purchasedProduct.definition.id == Buy_5)
        {

        }
        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseClicked(int which)
    {
        if (controller != null)
        {
            if (which == 0)
            {
                controller.InitiatePurchase(Test_Buy);
            }
            if (which == 1)
            {
                controller.InitiatePurchase(Buy_1);
            }
            if (which == 2)
            {
                controller.InitiatePurchase(Buy_2);
            }
            if (which == 3)
            {
                controller.InitiatePurchase(Buy_3);
            }
            if (which == 4)
            {
                controller.InitiatePurchase(Buy_4);
            }
            if (which == 5)
            {
                controller.InitiatePurchase(Buy_5);
            }

        }
    }


}

