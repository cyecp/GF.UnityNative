using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

#if UNITY_IPHONE
public class IOSNativeAPI : INativeAPI
{
    //-------------------------------------------------------------------------
    public void pay(string charge_data)
    {
        pay_ios(charge_data);
    }

    //-------------------------------------------------------------------------
    public void takeNewPhoto(int photo_width, int photo_height, string photo_name)
    {
        takeNewPhoto_ios("NativeAPIMsgReceiver", "getPicSuccess",
            "getPicFail", photo_width, photo_height, photo_name);
    }

    //-------------------------------------------------------------------------
    public void takeExistPhoto(int photo_width, int photo_height, string photo_name)
    {
        takeExistPhoto_ios("NativeAPIMsgReceiver", "getPicSuccess",
            "getPicFail", photo_width, photo_height, photo_name);
    }

    //-------------------------------------------------------------------------
    public void setMusicSilence()
    {
        setMusicSilence_ios();
    }

    //-------------------------------------------------------------------------
    public void cancelMusicSilence()
    {
        cancelMusicSilence_ios();
    }

    //-------------------------------------------------------------------------
    public bool getIsSilence()
    {
        return getIsSilence_ios();
    }

    //-------------------------------------------------------------------------
    public void setMusicMax()
    {
        setMusicMax_ios();
    }

    //-------------------------------------------------------------------------
    public void cancelMusicMax()
    {
        cancelMusicMax_ios();
    }

    //-------------------------------------------------------------------------
    public bool getIsMaxVolume()
    {
        return getIsMaxVolume_ios();
    }

    //-------------------------------------------------------------------------
    public void setCurrentMusicVolume(int current_muiscvolume)
    {
        setCurrentMusicVolum_ios(current_muiscvolume);
    }

    //-------------------------------------------------------------------------
    public float getCurrentMusicVolume()
    {
        return getCurrentMusicVolume_ios();
    }
#region DllImport
    //-------------------------------------------------------------------------
    [DllImport("__Internal")]
    private static extern void pay_ios(string charge_data);
    [DllImport("__Internal")]
    private static extern void takeNewPhoto_ios(string msg_recivername, string take_photosuccessmsgname,
        string take_photofailmsgname, int photo_width, int photo_height, string store_photopath);
    [DllImport("__Internal")]
    private static extern void takeExistPhoto_ios(string msg_recivername, string take_photosuccessmsgname,
        string take_photofailmsgname, int photo_width, int photo_height, string store_photopath);
    [DllImport("__Internal")]
    private static extern void setMusicSilence_ios();
    [DllImport("__Internal")]
    private static extern void cancelMusicSilence_ios();
    [DllImport("__Internal")]
    private static extern bool getIsSilence_ios();
    [DllImport("__Internal")]
    private static extern void setMusicMax_ios();
    [DllImport("__Internal")]
    private static extern void cancelMusicMax_ios();
    [DllImport("__Internal")]
    private static extern bool getIsMaxVolume_ios();
    [DllImport("__Internal")]
    private static extern void setCurrentMusicVolum_ios(int current_musicvolume);
    [DllImport("__Internal")]
    private static extern float getCurrentMusicVolume_ios();
#endregion
}
#endif