using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualiserShaderGrad : MonoBehaviour {

    Renderer rend;
    int _band;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        _band = GetComponentInParent<ParmamCube>()._band;
    }

    // Update is called once per frame
    void Update()
    {
        rend.material.SetFloat("Vector1_816BD0D2", AudioPeer._frequencyBands[_band]);
    }
}
