using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Timers;


#if UNITY_EDITOR
using UnityEditor;
#endif
namespace kenbu.Neneneko{
    public class Neneneko : MonoBehaviour {

        //CIが実行したか
        public static bool isExcutedCI = true;
        public bool isExcutedCI2 = false;

        //アウトプットパス
        public static string outputPath = "/kenbu/Neneneko/Captured/";

        //キャプチャ数
        public static int captureMaxNum = 50;

        //キャプチャインターバル
        public static int captureInterval = 0;

        //タップタイムアウト
        public static int tapTimeoutErrorFrame = 1000;

        //タップグリッド
        public static int tapGrid = 10;

        //タップインターバル
        public static int tapInterval = 0;

        //テストタイム 5分
        public static float testTimeSconds = 1.0f * 60.0f;

        public static bool isTesting = false;

        //成功か
        public bool success = true;

        private NenenekoErrorCatcher _errorCatcher;
        private NenenekoTimer _timer;
        private NenenekoRecorder _recorder;
        private NenenekoTapExecutor _tapExecutor;   //todo: 一旦タップのみそのうちユーザーインタラクションをいろいろ設定可能に。


        private float _startTime;
        public float RemainingTestTime{
            get{ 
                return testTimeSconds - (Time.time - _startTime);
            }
        }

        // Use this for initialization
        void Start () {
            
            _recorder = GetComponent<NenenekoRecorder> ();
            _errorCatcher = GetComponent<NenenekoErrorCatcher> ();
            _tapExecutor = GetComponent<NenenekoTapExecutor> ();
            _timer = GetComponent<NenenekoTimer> ();

            Debug.Log ("いかがか" + isExcutedCI2);

            Play();
        }

        public void Play(){

            if (isTesting) {
                return;
            } 

            isTesting = true;

            StartCoroutine (_Play());

        }

        private IEnumerator _Play(){
            //タップスタート
            _tapExecutor.Play ();

            _startTime = Time.time;

            //レコーディング開始
            _recorder.StartRecording ();
            _errorCatcher.OnError = (logString, stackTrace, type)=>{
                Debug.Log("エラー拾った:" + logString);
                success = false;
            };
            yield return new WaitUntil (()=>{
                _timer.SetRemainingTime (RemainingTestTime);
                return success == false || RemainingTestTime <= 0;
            });
            Stop();
        }


        public void Stop(){
            _tapExecutor.Stop ();
            if (success) {
                //問題なしで終わった。
                Debug.Log("問題なしかも");
                Exit (0);
                isTesting = false;
            } else {
                //Exceptionあり
                _recorder.CompleateRecording(()=>{
                    #if UNITY_EDITOR
                    if(isExcutedCI) {
                        Exit (1);
                    }
                    #endif
                    isTesting = false;
                });
            }
        }

        private void Exit(int result){
            if (isExcutedCI) {
                EditorApplication.Exit (result);
            }

        }


    }
}
