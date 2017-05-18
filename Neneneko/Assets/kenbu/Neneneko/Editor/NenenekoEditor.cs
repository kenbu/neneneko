using UnityEditor;                              
using UnityEngine;
using kenbu.Neneneko;

[CustomEditor(typeof(NenenekoPlayer))]               
public class NenenekoEditor : Editor          
{

    private GameObject resource;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (!EditorApplication.isPlaying) {
            //再生してない。
            if( GUILayout.Button( "PlayCI" ) )
            {
                NenenekoCI.StartTest ();
            }
            return;
        } 

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

        Neneneko.isExcutedCI = false;

        if (Neneneko.isTesting == false) {
            if( GUILayout.Button( "Play" ) )
            {
                if (resource == null) {
                    resource = Instantiate (Resources.Load ("Neneneko")as GameObject)as GameObject;
                }
            }
        } else {
            if( GUILayout.Button( "Stop" ) )
            {
                Neneneko neneneko = resource.GetComponent <Neneneko>();
                neneneko.Stop ();
            }
        }


    }



}
