using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float _vertical, _horizontal;
    public float speed = 10f;
    public float JumpPower = 20f; 
    Rigidbody rb;
    public float dist;
    bool jump = false;
    private float floatingHeight=0.4f;
    Vector3 move;
    Transform mainCam;
    Vector3 Camforward;
    private float m_GravityMultiplier=2f;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        mainCam = Camera.main.transform;

	}

    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * hit.distance, Color.red);
            dist = hit.distance;
        }
        
    }

    // Update is called once per frame
    void Update () {
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x, Camera.main.transform.rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z);
        _vertical = Input.GetAxis("Vertical") *Time.deltaTime* speed;
        _horizontal = Input.GetAxis("Horizontal") *Time.deltaTime* speed;
       // this.transform.Rotate(new Vector3(0, this.transform.rotation.y - Camera.main.transform.rotation.y, 0));
        this.transform.Translate(_horizontal, 0, _vertical); 
        if (dist <= (transform.localScale.y+0.2f))
        {
            jump = true;
        }
        else
        {
            jump = false;
        }
        

        if (Input.GetKeyDown(KeyCode.Space) && jump == true) 
        {
            rb.AddForce(Vector3.up * JumpPower, ForceMode.VelocityChange);
            jump = false;
        }
	}
}
