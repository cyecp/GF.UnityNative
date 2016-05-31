using UnityEngine;
using UnityEditor;
using System.Collections;

public class EditorGFNativeInternal : EditorWindow
{
    static string mUnityPackagePath = "";

    //-------------------------------------------------------------------------
    static EditorGFNativeInternal()
    {
        string unity_path = System.Environment.CurrentDirectory;
        mUnityPackagePath = unity_path.Replace(@"Unity\UnityDemo", "Package");
    }

    //-------------------------------------------------------------------------
    [MenuItem("GF/GF.Native/导出UnityNativePackageAll")]
    static void exportGFUnityPackage()
    {
        string[] arr_assetpathname = new string[3];
        arr_assetpathname[0] = "Assets/GF.Native";
        arr_assetpathname[1] = "Assets/Plugins";
        arr_assetpathname[2] = "Assets/Test";

        AssetDatabase.ExportPackage(arr_assetpathname, mUnityPackagePath + "\\UnityNativePackageAll.unitypackage", ExportPackageOptions.Recurse);

        Debug.Log("Export UnityNativePackageAll.unitypackage Finished!");
    }

    //-------------------------------------------------------------------------
    [MenuItem("GF/GF.Native/导出UnityNativeDataEye")]
    static void exportGFJsonPackage()
    {
        string[] arr_assetpathname = new string[4];
        arr_assetpathname[0] = "Assets/GF.Native";
        arr_assetpathname[1] = "Assets/Plugins/Android";
        arr_assetpathname[2] = "Assets/Plugins/GF.Native/DataEye";
        arr_assetpathname[3] = "Assets/Plugins/GF.Native/SDKReceiveMono";
        AssetDatabase.ExportPackage(arr_assetpathname, mUnityPackagePath + "\\UnityNativeDataEye.unitypackage", ExportPackageOptions.Recurse);

        Debug.Log("Export UnityNativeDataEye.unitypackage Finished!");
    }

    //-------------------------------------------------------------------------
    [MenuItem("GF/GF.Native/导出UnityNativePay")]
    static void exportUnityNativePay()
    {
        string[] arr_assetpathname = new string[4];
        arr_assetpathname[0] = "Assets/GF.Native";
        arr_assetpathname[1] = "Assets/Plugins/Android";
        arr_assetpathname[2] = "Assets/Plugins/GF.Native/Pay";
        arr_assetpathname[3] = "Assets/Plugins/GF.Native/SDKReceiveMono";
        AssetDatabase.ExportPackage(arr_assetpathname, mUnityPackagePath + "\\UnityNativePay.unitypackage", ExportPackageOptions.Recurse);

        Debug.Log("Export UnityNativePay.unitypackage Finished!");
    }

    //-------------------------------------------------------------------------
    [MenuItem("GF/GF.Native/导出GFNativeBySelf")]
    static void exportGFNativeBySelf()
    {
        string[] arr_assetpathname = new string[4];
        arr_assetpathname[0] = "Assets/GF.Native";
        arr_assetpathname[1] = "Assets/Plugins/Android";
        arr_assetpathname[2] = "Assets/Plugins/GF.Native/Native";
        arr_assetpathname[3] = "Assets/Plugins/GF.Native/SDKReceiveMono";
        AssetDatabase.ExportPackage(arr_assetpathname, mUnityPackagePath + "\\GFNativeBySelf.unitypackage", ExportPackageOptions.Recurse);

        Debug.Log("Export GFNativeBySelf.unitypackage Finished!");
    }

    //-------------------------------------------------------------------------
    [MenuItem("GF/GF.Native/导出Speech")]
    static void exportBaiduSpeech()
    {
        string[] arr_assetpathname = new string[4];
        arr_assetpathname[0] = "Assets/GF.Native";
        arr_assetpathname[1] = "Assets/Plugins/Android";
        arr_assetpathname[2] = "Assets/Plugins/GF.Native/Speech";
        arr_assetpathname[3] = "Assets/Plugins/GF.Native/SDKReceiveMono";
        AssetDatabase.ExportPackage(arr_assetpathname, mUnityPackagePath + "\\Speech.unitypackage", ExportPackageOptions.Recurse);

        Debug.Log("Export BaiduSpeech.unitypackage Finished!");
    }
}
