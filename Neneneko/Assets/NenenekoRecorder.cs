using UnityEngine;
using System.Collections;
namespace kenbu.Neneneko{

    public class NenenekoRecorder : MonoBehaviour {

        private Coroutine _coroutine;

        public void StartRecording(){
            _coroutine = StartCoroutine (Record());
        }

        private IEnumerator Record(){
            while (true) {



                yield return null;

            }

            yield return null;
        }

        // Use this for initialization
        public void CompleateRecording () {
            if (_coroutine != null) {
                StopCoroutine (_coroutine);
                _coroutine = null;
            }
    	}
    	
    }
}