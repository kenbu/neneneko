using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NenenekoTimer : MonoBehaviour {

    [SerializeField]
    private Text _text;


    public void SetRemainingTime(float seconds) {
        _text.text = seconds+"sec";
    }
}
