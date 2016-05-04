using UnityEngine;
using System.Collections;
using OnePF;
using System.Collections.Generic;

public class Pay
{
    //-------------------------------------------------------------------------
    static Pay mPay;
    static IPay mIPay;
    static Inventory mInventory = null;
    string mMsg = "";

    //-------------------------------------------------------------------------
    public Pay()
    {
        // Listen to all events for illustration purposes
        OpenIABEventManager.billingSupportedEvent += billingSupportedEvent;
        OpenIABEventManager.billingNotSupportedEvent += billingNotSupportedEvent;
        OpenIABEventManager.queryInventorySucceededEvent += queryInventorySucceededEvent;
        OpenIABEventManager.queryInventoryFailedEvent += queryInventoryFailedEvent;
        OpenIABEventManager.purchaseSucceededEvent += purchaseSucceededEvent;
        OpenIABEventManager.purchaseFailedEvent += purchaseFailedEvent;
        OpenIABEventManager.consumePurchaseSucceededEvent += consumePurchaseSucceededEvent;
        OpenIABEventManager.consumePurchaseFailedEvent += consumePurchaseFailedEvent;

#if UNITY_ANDROID
        mIPay = new AndroidPay();
        Debug.Log("AndroidPay::");
#elif UNITY_IOS
        mIPay = new IOSPay();
        Debug.Log("IOSPay::");
#else
        Debug.LogError("Do not supported on this platform. ");
#endif
    }

    //-------------------------------------------------------------------------
    public static Pay Instant()
    {
        if (mPay == null)
        {
            mPay = new Pay();
        }

        return mPay;
    }

    //-------------------------------------------------------------------------
    public static void pay(string buy_item_key, string charge_data, _ePayType pay_type)
    {
        if (pay_type == _ePayType.AppStore)
        {
            //OpenIAB.purchaseProduct(buy_item_key);

            if (mInventory != null && mInventory.HasPurchase(buy_item_key))
            {
                OpenIAB.consumeProduct(mInventory.GetPurchase(buy_item_key));
            }
        }
        else
        {
            mIPay.pay(charge_data, (int)pay_type);
        }
    }

    //-------------------------------------------------------------------------
    public void initInventory(List<int> list_inventory)
    {
        Debug.LogError("Pay::initInventory");
        foreach (var i in list_inventory)
        {
            OpenIAB.mapSku(i.ToString(), OpenIAB_iOS.STORE, i.ToString());
        }

        var options = new Options();
        OpenIAB.init(options);
    }

    //-------------------------------------------------------------------------
    private void billingSupportedEvent()
    {
        //_isInitialized = true;
        Debug.Log("billingSupportedEvent");
    }

    //-------------------------------------------------------------------------
    private void billingNotSupportedEvent(string error)
    {
        Debug.Log("billingNotSupportedEvent: " + error);
    }

    //-------------------------------------------------------------------------
    private void queryInventorySucceededEvent(Inventory inventory)
    {
        Debug.Log("queryInventorySucceededEvent: " + inventory);
        if (inventory != null)
        {
            mMsg = inventory.ToString();
            mInventory = inventory;
        }
    }

    //-------------------------------------------------------------------------
    private void queryInventoryFailedEvent(string error)
    {
        Debug.Log("queryInventoryFailedEvent Failed: " + error);
        mMsg = error;

        NativeAPIMsgReceiver.instance().PayResult(mMsg);
    }

    //-------------------------------------------------------------------------
    private void purchaseSucceededEvent(Purchase purchase)
    {
        Debug.Log("purchaseSucceededEvent: " + purchase);
        mMsg = "PURCHASED Succeeded:" + purchase.ToString();

        NativeAPIMsgReceiver.instance().PayResult(mMsg);
    }

    //-------------------------------------------------------------------------
    private void purchaseFailedEvent(int errorCode, string errorMessage)
    {
        Debug.Log("purchaseFailedEvent: " + errorMessage);
        mMsg = "Purchase Failed: " + errorMessage;

        NativeAPIMsgReceiver.instance().PayResult(mMsg);
    }

    //-------------------------------------------------------------------------
    private void consumePurchaseSucceededEvent(Purchase purchase)
    {
        Debug.Log("consumePurchaseSucceededEvent: " + purchase);
        mMsg = "CONSUMED Succeeded: " + purchase.ToString();

        NativeAPIMsgReceiver.instance().PayResult(mMsg);
    }

    //-------------------------------------------------------------------------
    private void consumePurchaseFailedEvent(string error)
    {
        Debug.Log("consumePurchaseFailedEvent: " + error);
        mMsg = "Consume Failed: " + error;

        NativeAPIMsgReceiver.instance().PayResult(mMsg);
    }
}
