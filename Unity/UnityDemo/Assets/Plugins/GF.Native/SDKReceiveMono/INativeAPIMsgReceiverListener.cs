using System;

public interface INativeAPIMsgReceiverListener
{
    //-------------------------------------------------------------------------
    void PayResult(string result);
    void getPicResult(string getpic_result);
}