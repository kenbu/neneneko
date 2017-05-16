﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;


namespace kenbu.Neneneko{

    public class NenenekoRecorder : MonoBehaviour {

        private Coroutine _coroutine;
        private List<Texture2D> _capture = new List<Texture2D>();

        [SerializeField]
        private int _captureMaxNum = 10;

        [SerializeField]
        private float _interval = 0.05f;

        [SerializeField]
        private string _path = "/kenbu/Neneneko/Captured/";

        public void StartRecording(){
            _coroutine = StartCoroutine (Record());
        }

        private IEnumerator Record(){
            while (true) {
                yield return new WaitForEndOfFrame();

                //キャプチャ生成
                Capture();

                yield return new WaitForSeconds (_interval);

            }
        }

            

        // Use this for initialization
        public void CompleateRecording (System.Action callback) {
            if (_coroutine != null) {
                StopCoroutine (_coroutine);
                _coroutine = null;
            }

            StartCoroutine (_CompleateRecording(callback));
    	}

        private IEnumerator _CompleateRecording(System.Action callback){
            yield return new WaitForEndOfFrame ();
            Capture ();
            //ファイル生成
            // Encode texture into PNG
            int l = _capture.Count;
            for(int i = 0; i<l; i++){
                Texture2D tex = _capture [i];
                byte[] bytes = tex.EncodeToPNG();
                Object.Destroy(tex);
                //string path = Application.dataPath + _path + i + ".png";
                string path = Application.dataPath + "/" + i + ".png";
                //Debug.Log (path);
                //Write to a file in the project folder
                File.WriteAllBytes(path, bytes);

            }
            _capture = new List<Texture2D>(); 

            callback.Invoke ();
        }

        private void Capture(){
            //古いものから消していく
            if (_capture.Count > _captureMaxNum) {
                Object.Destroy(_capture [0]);
                _capture.RemoveAt (0);
            }

            var texture = new Texture2D(Screen.width, Screen.height);
            texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
            texture.Apply();
            _capture.Add (texture);

        }


    }
}