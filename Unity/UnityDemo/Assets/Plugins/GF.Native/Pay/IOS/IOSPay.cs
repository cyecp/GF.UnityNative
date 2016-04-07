using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

#if UNITY_IPHONE
public class IOSPay : IPay
{
    //-------------------------------------------------------------------------
    public void pay(string charge_data)
    {
        pay_ios(charge_data);
    }

#region DllImport
    //-------------------------------------------------------------------------
    [DllImport("__Internal")]
    private static extern void pay_ios(string charge_data);
#endregion
}
#endif