using UnityEngine;
using System.Collections;

public class BaiduSpeech
{
    //-------------------------------------------------------------------------
    static IBaiduSpeech mIBaiduSpeech;

    //-------------------------------------------------------------------------
    static BaiduSpeech()
    {
#if UNITY_ANDROID
        mIBaiduSpeech = new AndroidBaiduSpeech();
        Debug.Log("AndroidBaiduSpeech::");
#elif UNITY_IOS
        mIBaiduSpeech = new IOSBaiduSpeech();
        Debug.Log("IOSBaiduSpeech::");
#else
        Debug.LogError("Do not supported on this platform. ");
#endif
    }

    //-------------------------------------------------------------------------
    public static void startSpeech()
    {
        Debug.Log("startSpeech::");
        mIBaiduSpeech.startSpeech();
    }

    //-------------------------------------------------------------------------
    public static void cancelSpeech()
    {
        Debug.Log("cancelSpeech::");
        mIBaiduSpeech.cancelSpeech();
    }
}
