using UnityEditor;                              
using UnityEngine;
using kenbu.Neneneko;
using UnityEngine.EventSystems;
using System.Security.Cryptography;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(Neneneko))]               
public class NenenekoEditor : Editor          
{


    public static void StartTest(){
        EditorSceneManager.OpenScene ("Assets/Main.unity");

        EditorApplication.isPlaying = true;
    }





    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Neneneko neneneko = target as Neneneko;

        if( GUILayout.Button( "PlayEditor" ) )
        {
            StartTest ();
        }

        if( GUILayout.Button( "Play" ) )
        {
            neneneko.Play ();
        }
        if( GUILayout.Button( "Stop" ) )
        {
            neneneko.Stop ();
        }

    }



}
