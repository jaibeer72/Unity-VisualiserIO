using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIscripts : MonoBehaviour {


    public void ReloadScean()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
	
}
