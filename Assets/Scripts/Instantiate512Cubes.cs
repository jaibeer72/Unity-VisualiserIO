using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512Cubes : MonoBehaviour {

    public GameObject _sampleCubesPrefab;
    GameObject[] _sampleCube = new GameObject[512];
    public float _maxScale;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < _sampleCube.Length; i++)
        {
            GameObject _instanceSampleCube = (GameObject)Instantiate(_sampleCubesPrefab);
            _instanceSampleCube.transform.position = this.transform.position;
            _instanceSampleCube.transform.parent = this.transform;
            _instanceSampleCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, -(_sampleCube.Length / 360) * i, 0);
            _instanceSampleCube.transform.position = Vector3.forward * 100;
            _sampleCube[i] = _instanceSampleCube; 
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < _sampleCube.Length; i++)
        {   
            if(_sampleCube != null)
            {
             
                _sampleCube[i].transform.localScale = new Vector3(1, (AudioPeer._sapmples[i] * _maxScale) + 2, 1);
                _sampleCube[i].GetComponent<Renderer>().material.SetFloat("Vector1_816BD0D2", Mathf.Clamp(AudioPeer._sapmples[i], 0, 1.0f) * 100);

            }
        }
	}
}
