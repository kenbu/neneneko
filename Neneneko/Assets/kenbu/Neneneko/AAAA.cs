using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using kenbu.Neneneko;
using UnityEditor;


namespace kenbu.Neneneko{

    public class AAAA : MonoBehaviour {

        [SerializeField]
        private Neneneko _nenenko;

    	// Use this for initialization
    	void Start () {
            _nenenko.OnComplete = (result) => {
                Debug.Log (result);
                EditorApplication.Exit (0);
            };

    	}
    	
    	// Update is called once per frame
    	void Update () {
    		
    	}
    }
}