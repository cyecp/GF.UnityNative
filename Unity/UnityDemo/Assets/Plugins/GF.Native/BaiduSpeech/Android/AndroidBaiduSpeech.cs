using UnityEngine;
using System.Collections;
using System;

public class AndroidBaiduSpeech : IBaiduSpeech
{
    public AndroidJavaClass mAndroidJavaClassBaiduSpeech;
    public AndroidJavaObject mAndroidBaiduSpeech;

    //-------------------------------------------------------------------------
    public AndroidBaiduSpeech()
    {
        mAndroidJavaClassBaiduSpeech = new AndroidJavaClass("com.BaiduSpeech.BaiduSpeech.BaiduSpeech");
    }

    //-------------------------------------------------------------------------
    public void cancelSpeech()
    {
        _initJavaObject();
        mAndroidBaiduSpeech.Call(_eAndroidBaiduSpeechMsg.cancelSpeech.ToString());
    }

    //-------------------------------------------------------------------------
    public void startSpeech()
    {
        _initJavaObject();
        mAndroidBaiduSpeech.Call(_eAndroidBaiduSpeechMsg.startSpeech.ToString());
    }

    //-------------------------------------------------------------------------
    void _initJavaObject()
    {
        if (mAndroidBaiduSpeech == null)
        {
            mAndroidBaiduSpeech = mAndroidJavaClassBaiduSpeech.CallStatic<AndroidJavaObject>("Instantce",
                "NativeAPIMsgReceiver");
        }
    }
}

//-------------------------------------------------------------------------
public enum _eAndroidBaiduSpeechMsg
{
    startSpeech,
    cancelSpeech
}
