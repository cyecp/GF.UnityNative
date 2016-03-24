using System;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_ANDROID
public class AndroidNativeAPI : INativeAPI
{
    //-------------------------------------------------------------------------
    public AndroidJavaClass mAndroidJavaClass;
    public AndroidJavaObject mAndroidJavaObject;

    //-------------------------------------------------------------------------
    public AndroidNativeAPI()
    {
        mAndroidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        mAndroidJavaObject = mAndroidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
    }

    //-------------------------------------------------------------------------
    public void pay(string charge_data)
    {
        if (mAndroidJavaObject != null)
        {
            mAndroidJavaObject.Call("pay", charge_data);
        }
        else
        {
            Debug.LogError("AndroidJavaObject Is Null");
        }
    }

    //-------------------------------------------------------------------------
    public void takeNewPhoto(int photo_width, int photo_height, string store_photopath)
    {
        if (mAndroidJavaObject != null)
        {
            //mAndroidJavaObject.Call("pay", charge_data);
        }
        else
        {
            Debug.LogError("AndroidJavaObject Is Null");
        }
    }

    //-------------------------------------------------------------------------
    public void takeExistPhoto(int photo_width, int photo_height, string store_photopath)
    {
        if (mAndroidJavaObject != null)
        {
            //mAndroidJavaObject.Call("pay", charge_data);
        }
        else
        {
            Debug.LogError("AndroidJavaObject Is Null");
        }
    }
}
#endif