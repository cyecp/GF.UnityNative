using UnityEngine;
using System.Collections;

public class NativeSDK
{
    static INativeAPI mINativeAPI;

    static NativeSDK()
    {
#if UNITY_ANDROID
        mINativeAPI = new AndroidNativeAPI();
        Debug.Log("AndroidNativeAPI::");
#elif UNITY_IOS
        mINativeAPI = new IOSNativeAPI();
        Debug.Log("IOSNativeAPI");
#else
        Debug.LogError("Do not supported on this platform. ");
#endif
    }

    public static void pay(string charge_data)
    {
        mINativeAPI.pay(charge_data);
    }

}
