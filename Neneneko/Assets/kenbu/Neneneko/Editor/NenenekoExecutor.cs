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

        var resource = Resources.Load ("Neneneko")as GameObject;

        Instantiate (resource);
    }
}
