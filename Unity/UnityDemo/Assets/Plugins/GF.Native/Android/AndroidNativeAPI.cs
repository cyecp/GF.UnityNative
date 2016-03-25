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

    //-------------------------------------------------------------------------
    public AndroidNativeAPI()
    {
        mAndroidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        mAndroidJavaObject = mAndroidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
        mAndoridJavaClassTakePhoto = new AndroidJavaClass("com.TakePhoto.TakePhoto.TakePhoto");
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
    public void takeNewPhoto(int photo_width, int photo_height, string photo_name)
    {
        if (mAndroidTakePhoto == null)
        {
            mAndroidTakePhoto = mAndoridJavaClassTakePhoto.CallStatic<AndroidJavaObject>("Instantce", new object[] { photo_width, photo_height, "", photo_name, "NativeAPIMsgReceiver" });
        }

        if (mAndroidTakePhoto != null)
        {
            mAndroidTakePhoto.Call("takeNewPhoto");
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
            mAndroidTakePhoto = mAndoridJavaClassTakePhoto.CallStatic<AndroidJavaObject>("Instantce", new object[] { photo_width, photo_height, "", photo_name, "NativeAPIMsgReceiver" });
        }

        if (mAndroidTakePhoto != null)
        {
            mAndroidTakePhoto.Call("takeExistPhoto");
        }
        else
        {
            Debug.LogError("TakePhoto Is Null");
        }
    }
}
#endif