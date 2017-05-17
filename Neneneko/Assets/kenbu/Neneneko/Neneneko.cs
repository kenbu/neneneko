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
        public static bool isExcutedCI = false;

        //todo: CIで設定されてたら優先


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
        public static float testTimeSconds = 5.0f * 60.0f;

        //成功か
        public bool success = true;

        private NenenekoErrorCatcher _errorCatcher;
        private NenenekoRecorder _recorder;
        private NenenekoTapExecutor _tapExecutor;   //todo: 一旦タップのみそのうちユーザーインタラクションをいろいろ設定可能に。


        private static bool _isTesting;
        public static bool IsTesting {
            get{
                return _isTesting;
            }
        } 

        private float _startTime;
        public float RemainingTestTime{
            get{ 
                return testTimeSconds - (Time.time - _startTime);
            }
        }

        // Use this for initialization
        void Awake () {
            //todo: EditorじゃなかったらDestroy


            _recorder = GetComponent<NenenekoRecorder> ();
            _errorCatcher = GetComponent<NenenekoErrorCatcher> ();
            _tapExecutor = GetComponent<NenenekoTapExecutor> ();

            //
            if(isExcutedCI) {
                Play();
            }
        }

        public void Play(){

            if (_isTesting) {
                return;
            } 

            _isTesting = true;

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
                _isTesting = false;
            } else {
                //Exceptionあり
                _recorder.CompleateRecording(()=>{
                    #if UNITY_EDITOR
                    if(isExcutedCI) {
                        Exit (1);
                    }
                    #endif
                    _isTesting = false;
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
