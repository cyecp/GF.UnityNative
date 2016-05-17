using UnityEngine;
using System.Collections;

public class NativeSpeech
{
    //-------------------------------------------------------------------------
	static NativeSpeech mNativeSpeech;
	static ISpeech mISpeech;

    //-------------------------------------------------------------------------
	public NativeSpeech(string app_id,_eSpeechLanguage speech_language)
    {
#if UNITY_ANDROID
		mISpeech = new AndroidSpeech(app_id,speech_language);
        Debug.Log("AndroidSpeech::");
#elif UNITY_IOS
		mISpeech = new IOSSpeech(app_id,speech_language);
        Debug.Log("IOSSpeech::");
#else
        Debug.LogError("Do not supported on this platform. ");
#endif
    }

		//-------------------------------------------------------------------------
		public static NativeSpeech Instantce(string app_id,_eSpeechLanguage speech_language)
	{
		if (mNativeSpeech == null) {
			mNativeSpeech = new NativeSpeech (app_id, speech_language);
		}

		return mNativeSpeech;
	}

    //-------------------------------------------------------------------------
    public  void startSpeech()
    {
        Debug.Log("startSpeech::");
		mISpeech.startSpeech();
    }
}

//-------------------------------------------------------------------------
		public enum _eSpeechLanguage
		{
		zh_cn,
		en_us,
		}
