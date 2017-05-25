using UnityEditor;                              
using UnityEngine;
using kenbu.Neneneko;
using UnityEngine.EventSystems;
using System.Security.Cryptography;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using NUnit.Framework.Constraints;
using System;

public class NenenekoCI : Editor          
{
    
    /// <summary>
    /// CIから叩かれる。
    /// </summary>
    public static void StartTest(){
        string defaultScene = "Assets/Main.unity";

        EditorSceneManager.OpenScene (defaultScene);

        EditorApplication.isPlaying = true;

        var nennekoResource = Resources.Load ("Neneneko")as GameObject;

        var nenenekoGo = Instantiate (nennekoResource)as GameObject;

        var neneneko = nenenekoGo.GetComponent <Neneneko>();


        var args = System.Environment.GetCommandLineArgs();
        foreach (var str in args) {
            Debug.Log (str);
            //neneneko.isExcutedCI2 = true;
            //これはやっぱり無効ですね。

            //System.Environment.GetCommandLineArgs これで受け取る形は難しいなぁ。配列だからぁ。。他の環境になったらぶつかっちゃうわ。



        }
    }
}
