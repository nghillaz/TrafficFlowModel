using UnityEngine;
using System.Collections;

public class exitScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//make it invisible
		GetComponent<Renderer> ().enabled = false;

		//set the output values to zeroes
		singletonControlScript.peopleServed = 0;
		singletonControlScript.timePassed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			GetComponent<Renderer> ().enabled = !GetComponent<Renderer> ().enabled;
		}
		singletonControlScript.timePassed = Time.timeSinceLevelLoad;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "PersonAgent") {
			Destroy(other.gameObject);
			singletonControlScript.peopleServed++;
		}
	}
}
