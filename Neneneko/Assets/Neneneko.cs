using UnityEngine;
using System.Collections;
using System;

namespace kenbu.Neneneko{
    public class Neneneko : MonoBehaviour {

        private NenenekoErrorCatcher _errorCatcher;
        private NenenekoRecorder _recorder;
        private NenenekoTapExecutor _tapExecutor;   //todo: 一旦タップのみそのうちユーザーインタラクションをいろいろ設定可能に。

        private static bool _isTesting;
        public static bool IsTesting {
            get{
                return _isTesting;
            }
        } 

        // Use this for initialization
        void Awake () {
            //todo: スタート関数を作るランといかん。
            _isTesting = true;

            _recorder = GetComponent<NenenekoRecorder> ();
            _errorCatcher = GetComponent<NenenekoErrorCatcher> ();
            _tapExecutor = GetComponent<NenenekoTapExecutor> ();

            //タップスタート
            _tapExecutor.Play ();

            //レコーディング開始
            _recorder.StartRecording ();
            _errorCatcher.OnError = (logString, stackTrace, type)=>{
                Debug.Log("エラー拾った:" + logString);
                _tapExecutor.Stop ();
                _recorder.CompleateRecording();
                _isTesting = false;
            };
        }
    }
}
