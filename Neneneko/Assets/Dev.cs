﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using kenbu.Neneneko;

public class Dev : MonoBehaviour {

    [SerializeField]
    private Button _button1;
    [SerializeField]
    private Button _button2;
    [SerializeField]
    private Button _button3;
    [SerializeField]
    private Button _button4;

    [SerializeField]
    private Neneneko _neneneko;

	// Use this for initialization
	void Start () {
        _button1.onClick.AddListener (()=>{
            Debug.Log("tapされました。1");
        });
        _button2.onClick.AddListener (()=>{
            Debug.Log("tapされました。2");

        });
        _button3.onClick.AddListener (()=>{
            throw new Exception("エラーボタン押したよ。");
        });
        _button4.onClick.AddListener (()=>{
            Debug.Log("テスト開始");
            _neneneko.Play();
        });
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
