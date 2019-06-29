using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mergiInfata : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody>().velocity = transform.forward * 5;
        }
	}
}
