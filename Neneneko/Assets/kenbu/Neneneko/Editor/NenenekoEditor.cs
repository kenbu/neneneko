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

    /// <summary>
    /// CIから叩かれる。
    /// </summary>
    public static void StartTest(){

        string defaultScene = "Assets/Main.unity";

        EditorSceneManager.OpenScene (defaultScene);
        Neneneko.isExcutedCI = true;
        EditorApplication.isPlaying = true;
    }





    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Neneneko neneneko = target as Neneneko;

        if (!Neneneko.isExcutedCI) {
            Neneneko.outputPath = "/kenbu/Neneneko/Captured/";

            //キャプチャ数
            Neneneko.captureMaxNum = EditorGUILayout.IntField ("最大キャプチャ枚数", Neneneko.captureMaxNum);

            //キャプチャインターバル
            Neneneko.captureInterval = EditorGUILayout.IntField ("キャプチャインターバルフレーム", Neneneko.captureInterval);

            //タップタイムアウト
            Neneneko.tapTimeoutErrorFrame = EditorGUILayout.IntField ("タップ タイムアウトフレーム", Neneneko.tapTimeoutErrorFrame);

            //タップグリッド
            Neneneko.tapGrid = EditorGUILayout.IntField ("タップグリッド", Neneneko.tapGrid);

            //todo: タップインターバル 
            Neneneko.tapInterval = EditorGUILayout.IntField ("タップインターバル", Neneneko.tapInterval);

            Neneneko.testTimeSconds = EditorGUILayout.FloatField ("テスト時間", Neneneko.testTimeSconds);

        }
        if (Neneneko.IsTesting) {
            GUILayout.Label ("残り時間:" + neneneko.RemainingTestTime);
        }

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
