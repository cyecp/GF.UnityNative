using System;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_ANDROID
public class AndroidNativeAPI : INativeAPI
{
    //-------------------------------------------------------------------------
    public AndroidJavaClass mAndroidJavaClass;
    public AndroidJavaObject mAndroidJavaObject;
    public AndroidJavaClass mAndoridJavaClassTakePhoto;
    public AndroidJavaObject mAndroidTakePhoto;
    public AndroidJavaClass mAndroidJavaClassAudioControl;
    public AndroidJavaObject mAndroidAudioControl;

    //-------------------------------------------------------------------------
    public AndroidNativeAPI()
    {
        mAndroidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        mAndroidJavaObject = mAndroidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
        mAndoridJavaClassTakePhoto = new AndroidJavaClass("com.TakePhoto.TakePhoto.TakePhoto");
        mAndroidJavaClassAudioControl = new AndroidJavaClass("com.AudioController.AudioController.AudioController");
    }

    //-------------------------------------------------------------------------
    public void pay(string charge_data)
    {
        if (mAndroidJavaObject != null)
        {
            mAndroidJavaObject.Call(_eAndroidNativeAPI.pay.ToString(), charge_data);
        }
        else
        {
            Debug.LogError("AndroidJavaObject Is Null");
        }
    }

    //-------------------------------------------------------------------------
    public void takeNewPhoto(int photo_width, int photo_height, string photo_name)
    {
        if (mAndroidTakePhoto == null)
        {
            mAndroidTakePhoto = mAndoridJavaClassTakePhoto.CallStatic<AndroidJavaObject>("Instantce",
                photo_width, photo_height, "getPicSuccess", "getPicFail", photo_name, "NativeAPIMsgReceiver");
        }

        if (mAndroidTakePhoto != null)
        {
            mAndroidTakePhoto.Call(_eAndroidNativeAPI.takeNewPhoto.ToString());
        }
        else
        {
            Debug.LogError("TakePhoto Is Null");
        }
    }

    //-------------------------------------------------------------------------
    public void takeExistPhoto(int photo_width, int photo_height, string photo_name)
    {
        if (mAndroidTakePhoto == null)
        {
            mAndroidTakePhoto = mAndoridJavaClassTakePhoto.CallStatic<AndroidJavaObject>("Instantce",
                photo_width, photo_height, "getPicSuccess", "getPicFail", photo_name, "NativeAPIMsgReceiver");
        }

        if (mAndroidTakePhoto != null)
        {
            mAndroidTakePhoto.Call(_eAndroidNativeAPI.takeExistPhoto.ToString());
        }
        else
        {
            Debug.LogError("TakePhoto Is Null");
        }
    }

    //-------------------------------------------------------------------------
    public void setMusicSilence()
    {
        _initMusicJavaObject();

        mAndroidAudioControl.Call(_eAndroidNativeAPI.setMusicSilence.ToString());
    }

    //-------------------------------------------------------------------------
    public void cancelMusicSilence()
    {
        _initMusicJavaObject();

        mAndroidAudioControl.Call(_eAndroidNativeAPI.cancelMusicSilence.ToString());
    }

    //-------------------------------------------------------------------------
    public int getIsSilence()
    {
        _initMusicJavaObject();

        return mAndroidAudioControl.Call<int>(_eAndroidNativeAPI.getIsSilence.ToString());
    }

    //-------------------------------------------------------------------------
    public void setMusicMax()
    {
        _initMusicJavaObject();

        mAndroidAudioControl.Call(_eAndroidNativeAPI.setMusicMax.ToString());
    }

    //-------------------------------------------------------------------------
    public void cancelMusicMax()
    {
        _initMusicJavaObject();

        mAndroidAudioControl.Call(_eAndroidNativeAPI.cancelMusicMax.ToString());
    }

    //-------------------------------------------------------------------------
    public int getIsMaxVolume()
    {
        _initMusicJavaObject();

        return mAndroidAudioControl.Call<int>(_eAndroidNativeAPI.getIsMaxVolume.ToString());
    }

    //-------------------------------------------------------------------------
    public void setCurrentMusicVolume(float current_muiscvolume)
    {
        _initMusicJavaObject();

        mAndroidAudioControl.Call(_eAndroidNativeAPI.setCurrentMusicVolume.ToString(), current_muiscvolume);
    }

    //-------------------------------------------------------------------------
    public float getCurrentMusicVolume()
    {
        _initMusicJavaObject();

        return mAndroidAudioControl.Call<float>(_eAndroidNativeAPI.getCurrentMusicVolume.ToString());
    }

    //-------------------------------------------------------------------------
    void _initMusicJavaObject()
    {
        if (mAndroidAudioControl == null)
        {
            mAndroidAudioControl = mAndroidJavaClassAudioControl.CallStatic<AndroidJavaObject>("Instantce",
                "NativeAPIMsgReceiver", "audioChanged");
        }
    }
}

//-------------------------------------------------------------------------
public enum _eAndroidNativeAPI
{
    pay,
    takeNewPhoto,
    takeExistPhoto,
    setMusicSilence,
    cancelMusicSilence,
    getIsSilence,
    setMusicMax,
    cancelMusicMax,
    getIsMaxVolume,
    setCurrentMusicVolume,
    getCurrentMusicVolume,
}
#endif