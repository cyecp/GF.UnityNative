using UnityEngine;
using System.Collections;

public class NativeSDK
{
    //-------------------------------------------------------------------------
    static INativeAPI mINativeAPI;
    static string mNativeAPIMsgReceiverName;

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
    public static NativeAPIMsgReceiver getNativeAPIMsgReceiver()
    {
        mNativeAPIMsgReceiverName = (typeof(NativeAPIMsgReceiver)).Name;
        GameObject msg_receiver = GameObject.Find(mNativeAPIMsgReceiverName);
        NativeAPIMsgReceiver msg_receivermono;
        if (msg_receiver == null)
        {
            msg_receiver = new GameObject(mNativeAPIMsgReceiverName);
            msg_receivermono = msg_receiver.AddComponent<NativeAPIMsgReceiver>();
            GameObject.DontDestroyOnLoad(msg_receiver);
        }
        else
        {
            msg_receivermono = msg_receiver.GetComponent<NativeAPIMsgReceiver>();
        }

        return msg_receivermono;
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
    /// <summary>
    /// 0 false 1 true
    /// </summary>
    /// <returns></returns>
    public static int getIsSilence()
    {
        return mINativeAPI.getIsSilence();
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
    /// <summary>
    /// 0 false 1 true
    /// </summary>
    /// <returns></returns>
    public static int getIsMaxVolume()
    {
        return mINativeAPI.getIsMaxVolume();
    }

    //-------------------------------------------------------------------------
    public static void setCurrentMusicVolume(float current_muiscvolume)
    {
        mINativeAPI.setCurrentMusicVolume(current_muiscvolume);
    }

    //-------------------------------------------------------------------------
    public static float getCurrentMusicVolume()
    {
        return mINativeAPI.getCurrentMusicVolume();
    }

    //-------------------------------------------------------------------------
    /// <summary>
    /// DataEye统计初始化
    /// </summary>
    /// <param name="app_id"></param>
    /// <param name="channel_id"></param>
    /// <param name="report_mode"></param>
    public static void initWithAppIdAndChannelId(string app_id, string channel_id, DCReportMode report_mode = DCReportMode.DC_AFTER_LOGIN)
    {
        DCAgent.getInstance().initWithAppIdAndChannelId(app_id, channel_id);
    }

    //-------------------------------------------------------------------------
    /// <summary>
    /// DataEye登陆 
    /// </summary>
    /// <param name="acc_id"></param>
    public static void login(string acc_id)
    {
        DCAccount.login(acc_id);
    }

    //-------------------------------------------------------------------------
    /// <summary>
    /// DataEye登出
    /// </summary>
    public static void logout()
    {
        DCAccount.logout();
    }
}
