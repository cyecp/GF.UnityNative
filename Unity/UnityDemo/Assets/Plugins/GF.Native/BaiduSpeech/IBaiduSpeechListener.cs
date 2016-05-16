using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IBaiduSpeechListener
{
    //-------------------------------------------------------------------------
    void speechResult(int result_code, string most_possibleresult);
}

//-------------------------------------------------------------------------
public enum _eSpeechResult
{
    None,
    ReadyForSpeech,
    BeginningOfSpeech,
    EndOfSpeech,
    FinalResults,
    PartialResults,
    Error,
}