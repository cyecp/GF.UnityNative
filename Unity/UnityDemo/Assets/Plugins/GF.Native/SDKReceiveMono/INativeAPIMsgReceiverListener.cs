using System;

public interface INativeAPIMsgReceiverListener
{
    //-------------------------------------------------------------------------
    void PayResult(string result);
    void getPicSuccess(string getpic_result);
    void getPicFail(string fail);
}