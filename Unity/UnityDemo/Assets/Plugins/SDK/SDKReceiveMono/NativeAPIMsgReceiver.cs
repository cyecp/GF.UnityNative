using System;
using System.Collections.Generic;
using UnityEngine;

public class NativeAPIMsgReceiver : MonoBehaviour
{
    //-------------------------------------------------------------------------
    public void PayResult(string result)
    {
        Debug.Log("PayResult::" + result);
    }

    //-------------------------------------------------------------------------
    public void ReceiveError(string error)
    {
        Debug.Log("ReceiveError::" + error);
    }
}
