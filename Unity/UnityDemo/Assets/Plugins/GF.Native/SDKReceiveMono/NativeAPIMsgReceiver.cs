using System;
using System.Collections.Generic;
using UnityEngine;

public class NativeAPIMsgReceiver : MonoBehaviour
{
    public ITakePhotoReceiverListener TakePhotoReceiverListener { get; set; }
    public IPayReceiverListener PayReceiverListener { get; set; }

    //-------------------------------------------------------------------------
    public void PayResult(string result)
    {
        Debug.Log("PayResult::" + result);
        if (PayReceiverListener != null)
        {
            PayReceiverListener.PayResult(result);
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
    public void getPicSuccess(string getpic_result)
    {
        if (TakePhotoReceiverListener != null)
        {
            TakePhotoReceiverListener.getPicSuccess(getpic_result);
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

    //-------------------------------------------------------------------------
    public void getPicFail(string fail)
    {
        if (TakePhotoReceiverListener != null)
        {
            TakePhotoReceiverListener.getPicFail(fail);
        }
    }
}