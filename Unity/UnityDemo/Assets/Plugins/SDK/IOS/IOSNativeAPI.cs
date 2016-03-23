using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

#if UNITY_IPHONE
public class IOSNativeAPI : INativeAPI
{
    //-------------------------------------------------------------------------
    [DllImport("__Internal")]
    private static extern void pay_ios(string charge_data);

    //-------------------------------------------------------------------------
    public void pay(string charge_data)
    {
        pay_ios(charge_data);
    }
}
#endif