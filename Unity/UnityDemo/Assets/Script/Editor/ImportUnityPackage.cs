using UnityEngine;
using UnityEditor;
using System.Collections;

public class ImportUnityPackage : EditorWindow
{
    //-------------------------------------------------------------------------
    static string mPackagePath;

    //-------------------------------------------------------------------------
    [MenuItem("ImportUnityPackage/Import")]
    static void AddWindow()
    {
        EditorWindow.GetWindow(typeof(ImportUnityPackage));

        string current_dir = System.Environment.CurrentDirectory;
        Debug.LogError(current_dir);
        //\ThirdPackage
                
    }
}