using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;
using System;


namespace kenbu.Neneneko{

    public class NenenekoTapExecutor : MonoBehaviour {

        [SerializeField]
        private RectTransform _tapPoint;


        private List<string> _history = new List<string>();

        private Coroutine _loop;

        private bool tapEnable;
        private int tryCnt;

    	// Use this for initialization
    	public void Play () {
            tryCnt = 0;
            tapEnable = true;
    	}

        //UPDATE
        private void OnGUI(){
            if (tapEnable) {
            
                if (tryCnt < Neneneko.tapTimeoutErrorFrame) {
                    var w = UnityEngine.Random.Range (0, Screen.width / Neneneko.tapGrid) * Neneneko.tapGrid;
                    var h = UnityEngine.Random.Range (0, Screen.height / Neneneko.tapGrid) * Neneneko.tapGrid;
                    var button = GetButton (w, h);
                    _tapPoint.anchoredPosition = new Vector2 (w - Screen.width / 2, h - Screen.height / 2);


                    if (button != null) {
                        _history.Add (button.name);
                        //古いものから消す。

                        button.onClick.Invoke ();
                        tryCnt = 0;
                    } else {
                        tryCnt++;
                    }

                } else {
                    tapEnable = false;
                    throw new Exception ("NenekoTapExecutor TimeOut");

                }

            }

        }


        private Button GetButton(int x, int y)
        {
            var ev = new PointerEventData(EventSystem.current);
            var results = new List<RaycastResult>();
            ev.position = new Vector2(x, y);
            ev.button = PointerEventData.InputButton.Left;
            EventSystem.current.RaycastAll(ev, results);
            if (results.Count > 0) {
                int l = results.Count;
                for (int i = 0; i < l; i++) {
                    var result = results [i];
                    //NenenekoTestExcluedingがアタッチされている場合はタップ対象としない。
                    if (result.gameObject.GetComponent <NenenekoTestExclueding> () != null) {
                        continue;
                    }
                    var button = result.gameObject.GetComponent<Button> ();

                    if (button != null && button.onClick != null && button.isActiveAndEnabled) {
                        return button;
                    }
                }
            }
            return null;
        }



    	// Update is called once per frame
        public void Stop () {
            tapEnable = false;
             
            if (_loop != null) {
                StopCoroutine (_loop);
                _loop = null;
            }
    	}
    }
}