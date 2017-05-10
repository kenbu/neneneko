using UnityEngine;
using System.Collections;
using System;

namespace kenbu.Neneneko{
    public class Neneneko : MonoBehaviour {

        private NenenekoErrorCatcher _errorCatcher;
        private NenenekoRecorder _screenRecorder;
        private NenenekoTapExecutor _tapExecutor;   //todo: 一旦タップのみそのうちユーザーインタラクションをいろいろ設定可能に。


        // Use this for initialization
        void Awake () {
            _screenRecorder = GetComponent<NenenekoRecorder> ();
            _errorCatcher = GetComponent<NenenekoErrorCatcher> ();
            _tapExecutor = GetComponent<NenenekoTapExecutor> ();

            //タップスタート
            _tapExecutor.Play ();

            //レコーディング開始
            _screenRecorder.StartRecording ();
            _errorCatcher.OnError = (logString, stackTrace, type)=>{
                _tapExecutor.Stop ();

                _screenRecorder.CompleateRecording();
            };
        }

        // Update is called once per frame
        void Update () {
            //throw new Exception ("aaaaaa");
        }
    }
}
