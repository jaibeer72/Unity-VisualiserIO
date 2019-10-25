using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSpectrumData : MonoBehaviour {

    public static float[] _s =new float[512]; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static float[] RetuenSpectrumData()
    {
        AudioListener.GetSpectrumData(_s, 0, FFTWindow.Rectangular);
        return _s;
    }
}
