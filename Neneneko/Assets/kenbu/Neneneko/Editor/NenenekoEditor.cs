using UnityEditor;                              
using UnityEngine;
using kenbu.Neneneko;
using UnityEngine.EventSystems;

public class NenenekoBatchMode{
    public static string BatchTest(){
        Debug.Log("aaa");
        return "From Unity!!!!";
    }
}

[CustomEditor(typeof(Neneneko))]               
public class NenenekoEditor : Editor          
{


    public static void StartTest(){
        Debug.Log("aaa");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Neneneko neneneko = target as Neneneko;


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
