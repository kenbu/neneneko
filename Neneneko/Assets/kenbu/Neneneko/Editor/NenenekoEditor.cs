using UnityEditor;                              
using UnityEngine;
using kenbu.Neneneko;
[CustomEditor(typeof(Neneneko))]               
public class NenenekoEditor : Editor          
{


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
