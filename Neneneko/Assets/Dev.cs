﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dev : MonoBehaviour {

    [SerializeField]
    private Button _button1;
    [SerializeField]
    private Button _button2;
    [SerializeField]
    private Button _button3;

	// Use this for initialization
	void Start () {
        _button1.onClick.AddListener (()=>{
            Debug.Log("tapされました。1");
        });
        /*
        _button2.onClick.AddListener (()=>{
            Debug.Log("tapされました。2");
        });
        _button3.onClick.AddListener (()=>{
            Debug.Log("tapされました。3");
        });
        */
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}