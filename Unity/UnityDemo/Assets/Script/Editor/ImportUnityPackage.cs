using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class ImportUnityPackage : EditorWindow
{
    //-------------------------------------------------------------------------
    static string mPackagePath;
    const string mThirdPackageDirectoryName = "ThirdPackage";

    //-------------------------------------------------------------------------
    [MenuItem("ImportUnityPackage/Import")]
    static void AddWindow()
    {
        EditorWindow.GetWindow(typeof(ImportUnityPackage));

        string current_dir = System.Environment.CurrentDirectory;
        mPackagePath = string.Format(current_dir.Substring(0, current_dir.LastIndexOf(@"\")) + "{0}", @"\" + mThirdPackageDirectoryName);
    }

    //-------------------------------------------------------------------------
    void OnGUI()
    {
        EditorGUILayout.LabelField("UnityPackagePath:", mPackagePath);
        bool import = GUILayout.Button("ImportPackage", GUILayout.Width(200));
        if (import)
        {
            _importPackage();
        }
    }

    //-------------------------------------------------------------------------
    void _importPackage()
    {
        if (!Directory.Exists(mPackagePath))
        {
            ShowNotification(new GUIContent("无该目录!"));
        }
        else
        {
            string[] files = Directory.GetFiles(mPackagePath);
            foreach (var i in files)
            {
                AssetDatabase.ImportPackage(i, false);

            }
        }
    }    
}