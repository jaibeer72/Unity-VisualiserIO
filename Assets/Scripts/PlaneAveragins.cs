using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAveragins : MonoBehaviour {

    public GameObject[] CamerasSwitch;
    public Canvas UI; 
    float average = 0;
    float totalBandBuffer;
    public float _planeMultyplyer; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        average=GetAveragebandBuffer();
        if (average < 0.0005f)
        {
            average = -1f;
        }
        else
        {
            average *= _planeMultyplyer;
        }
        this.transform.position = new Vector3(0f, average , 0f); 
    }

    private float GetAveragebandBuffer()
    {
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            totalBandBuffer = AudioPeer._bandBuffer[i];
            count++;
        }
        return totalBandBuffer / count;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None; 
            CamerasSwitch[0].SetActive(false);
            CamerasSwitch[1].SetActive(true);
            UI.gameObject.SetActive(true);
            Destroy(other.gameObject); 
        }
    }
}
