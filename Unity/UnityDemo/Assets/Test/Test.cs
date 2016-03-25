using UnityEngine;
using System.Collections;
using System;

public class Test : MonoBehaviour, INativeAPIMsgReceiverListener
{
    //-------------------------------------------------------------------------
    public void getPicResult(string getpic_result)
    {
        if (getpic_result.Equals(_eReceiveResult.getPicSuccess.ToString()))
        {
            //加载图片成功
            Debug.Log("加载图片成功");
        }
        else
        {
            //加载图片失败

        }
    }

    //-------------------------------------------------------------------------
    public void PayResult(string result)
    {
        Debug.Log("PayResult::" + result);
    }

    //-------------------------------------------------------------------------
    void Start()
    {

    }

    //-------------------------------------------------------------------------
    void Update()
    {

    }
}
