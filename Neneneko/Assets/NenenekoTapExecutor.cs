using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;
using System;


namespace kenbu.Neneneko{

    public class NenenekoTapExecutor : MonoBehaviour {

        [SerializeField]
        private int _timeoutFrame = 1000;

        [SerializeField]
        private int _grid = 10;

        private Coroutine _loop;
    	// Use this for initialization
    	public void Play () {
            _loop = StartCoroutine (Loop());
    	}

        private IEnumerator Loop(){
            int tryCnt = 0;
            while(tryCnt < _timeoutFrame){
                var w = UnityEngine.Random.Range (0, Screen.width / _grid) * _grid;
                var h = UnityEngine.Random.Range (0, Screen.height / _grid) * _grid;
                var button = GetButton (w, h);
                yield return null;
            
                if (button != null) {
                    button.onClick.Invoke ();
                    tryCnt = 0;
                } else {
                    tryCnt++;
                }
            }

            throw new Exception ("NenekoTapExecutor TimeOut");
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
            if (_loop != null) {
                StopCoroutine (_loop);
                _loop = null;
            }
    	}
    }
}