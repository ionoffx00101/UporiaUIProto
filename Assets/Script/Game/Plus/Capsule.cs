using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour {

    GameObject capsuleobject;
    // Transform

    private void Awake ()
    {
        Capsule capsule = capsuleobject.GetComponent<Capsule>();
        Transform capsuleTransform = capsule.transform;
    }
    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
