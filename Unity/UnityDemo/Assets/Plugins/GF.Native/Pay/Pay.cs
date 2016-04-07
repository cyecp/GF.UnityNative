using UnityEngine;
using System.Collections;

public class Pay
{
    //-------------------------------------------------------------------------
    static IPay mIPay;

    //-------------------------------------------------------------------------
    static Pay()
    {
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
    public static void pay(string charge_data)
    {
        mIPay.pay(charge_data);
    }
}
