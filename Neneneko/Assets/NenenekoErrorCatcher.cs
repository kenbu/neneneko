using UnityEngine;
using System.Collections;
namespace kenbu.Neneneko{

    public class NenenekoErrorCatcher : MonoBehaviour {


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
            if (OnError == null) {
            
                }

            if (type == LogType.Exception)
            {
                OnError.Invoke (logString, stackTrace, type);
            }
        }
    }
}