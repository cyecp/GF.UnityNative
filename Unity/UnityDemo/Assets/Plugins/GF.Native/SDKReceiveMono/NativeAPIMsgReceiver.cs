using System;
using System.Collections.Generic;
using UnityEngine;

public class NativeAPIMsgReceiver : MonoBehaviour
{
    public INativeAPIMsgReceiverListener NativeAPIMsgReceiverListner { get; set; }

    //-------------------------------------------------------------------------
    public void PayResult(string result)
    {
        Debug.Log("PayResult::" + result);
        if (NativeAPIMsgReceiverListner != null)
        {
            NativeAPIMsgReceiverListner.PayResult(result);
        }
    }

    //-------------------------------------------------------------------------
    public void ReceiveError(string error)
    {
        Debug.Log("ReceiveError::" + error);
    }

    //-------------------------------------------------------------------------
    public void sendPicture(string picture_data)
    {
        Debug.Log("sendPicture::" + picture_data);
    }

    //-------------------------------------------------------------------------
    public void getPicResult(string getpic_result)
    {
        if (NativeAPIMsgReceiverListner != null)
        {
            NativeAPIMsgReceiverListner.getPicResult(getpic_result);
        }

        //if (getpic_result.Equals(_eReceiveResult.getPicSuccess.ToString()))
        //{
        //    //加载图片成功
        //    Debug.Log("加载图片成功");
        //}
        //else
        //{
        //    //加载图片失败

        //}
    }
}

//-------------------------------------------------------------------------
public enum _eReceiveResult
{
    getPicFailed,
    getPicSuccess,
}
