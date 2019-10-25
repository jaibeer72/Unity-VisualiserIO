﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParmamCube : MonoBehaviour {
    public int _band;
    public float _startScale, _scaleMultiplier=20.0f;
    public bool _useBuffer;
    

    // Use this for initialization
    void Start () {
         
	}
	
	// Update is called once per frame
	void Update () {
        if (_useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer._bandBuffer[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
            //Debug.Log(AudioPeer._bandBuffer[_band]); 
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer._frequencyBands[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
        }
	}
}
