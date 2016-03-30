using UnityEngine;
using System.Collections;

public class NativeSDK
{
    //-------------------------------------------------------------------------
    static INativeAPI mINativeAPI;

    //-------------------------------------------------------------------------
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

    //-------------------------------------------------------------------------
    public static void pay(string charge_data)
    {
        mINativeAPI.pay(charge_data);
    }

    //-------------------------------------------------------------------------
    public static void takeNewPhoto(int photo_width, int photo_height, string photo_name)
    {
        mINativeAPI.takeNewPhoto(photo_width, photo_height, photo_name);
    }

    //-------------------------------------------------------------------------
    public static void takeExistPhoto(int photo_width, int photo_height, string photo_name)
    {
        mINativeAPI.takeExistPhoto(photo_width, photo_height, photo_name);
    }

    //-------------------------------------------------------------------------
    public static void setMusicSilence()
    {
        mINativeAPI.setMusicSilence();
    }

    //-------------------------------------------------------------------------
    public static void cancelMusicSilence()
    {
        mINativeAPI.cancelMusicSilence();
    }

    //-------------------------------------------------------------------------
    public static void setMusicMax()
    {
        mINativeAPI.setMusicMax();
    }

    //-------------------------------------------------------------------------
    public static void cancelMusicMax()
    {
        mINativeAPI.cancelMusicMax();
    }

    //-------------------------------------------------------------------------
    public static void setCurrentMusicVolume(int current_muiscvolume)
    {
        mINativeAPI.setCurrentMusicVolume(current_muiscvolume);
    }
}
