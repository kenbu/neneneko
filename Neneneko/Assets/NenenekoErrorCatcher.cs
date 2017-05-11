using UnityEngine;
using System.Collections;
namespace kenbu.Neneneko{

    public class NenenekoErrorCatcher : MonoBehaviour {

        [SerializeField]
        private string[] _exclueds;

        public System.Action<string, string, LogType> OnError;

        void OnEnable()
        {
            Application.logMessageReceived += HandleException;
        }

        void OnDisable()
        {
            Application.logMessageReceived -= HandleException;
        }

        void HandleException(string logString, string stackTrace, LogType type)
        {
            if (type == LogType.Exception) {
                if(!IsExclueding (logString)) {
                    OnError.Invoke (logString, stackTrace, type);
                }
            }
        }

        private bool IsExclueding(string log){
            int l = _exclueds.Length;
            for (int i = 0; i < l; i++) {
                var exclued = _exclueds [i];
                if (log.IndexOf (exclued) >= 0) {
                    return true;
                }
            }
            return false;
        }
    }
}