using UnityEngine;
using System.Collections;

public class StepThroughPortal : MonoBehaviour {

	public GameObject otherPortal;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("something hit the portal");
		if(other.tag == "Player") {
			other.transform.position = otherPortal.transform.position + otherPortal.transform.forward * 1;
			other.transform.rotation = other.transform.rotation;
		}
	}
}
