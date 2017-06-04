using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("test motion");
	}
}
