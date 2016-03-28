using UnityEngine;
using System.Collections;
using System;

public class Test : MonoBehaviour, ITakePhotoReceiverListener, IPayReceiverListener
{
    //-------------------------------------------------------------------------
    public void getPicFail(string fail)
    {
        //加载图片失败
        Debug.Log("加载图片失败");

    }

    //-------------------------------------------------------------------------
    public void getPicSuccess(string getpic_result)
    {
        //加载图片成功
        Debug.Log("加载图片成功");

    }

    //-------------------------------------------------------------------------
    public void PayResult(string result)
    {
        Debug.Log("PayResult::" + result);
    }

    //-------------------------------------------------------------------------
    void Start()
    {
        //初始化各个Listener
        _initNativeMsgReceiverListener();
    }

    //-------------------------------------------------------------------------
    void Update()
    {

    }

    //-------------------------------------------------------------------------
    void _initNativeMsgReceiverListener()
    {
        NativeAPIMsgReceiver nativeAPI_msgreceiver = GameObject.Find("NativeAPIMsgReceiver").GetComponent<NativeAPIMsgReceiver>();
        nativeAPI_msgreceiver.TakePhotoReceiverListener = this;
        nativeAPI_msgreceiver.PayReceiverListener = this;
    }
}
