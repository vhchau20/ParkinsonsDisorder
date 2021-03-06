﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fix_object : MonoBehaviour {

    public GameObject left_cube;
    public GameObject parent;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnJointBreak(float breakForce)
    {
        StartCoroutine(release_leftcube());

        
        if(left_cube.transform.name == "c8")
        {
            Debug.Log(left_cube.transform.name);
            StartCoroutine(delete_parent());
        }
    }

    IEnumerator delete_parent()
    {
        Debug.Log("We are running delete_parent");
        yield return new WaitForSeconds(3f);
        parent.SetActive(false);
    }

    IEnumerator release_leftcube()
    {
        yield return new WaitForSeconds(0.7f);
        left_cube.GetComponent<Rigidbody>().isKinematic = false;
        left_cube.GetComponent<FixedJoint>().breakForce = 250;
        left_cube.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
