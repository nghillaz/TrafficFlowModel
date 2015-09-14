using UnityEngine;
using System.Collections;

public class waiterManagerScript : MonoBehaviour {
	public GameObject waiterPrefab;

	// Use this for initialization
	void Start () {
		//make it invisible
		GetComponent<Renderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
		}
	}

	public void callWaiter(GameObject input){
		GameObject tempWaiter = (GameObject)Instantiate (waiterPrefab, transform.position, Quaternion.identity);
		tempWaiter.GetComponent<waiterAgentScript> ().waiterManager = gameObject;
		tempWaiter.GetComponent<NavMeshAgent> ().destination = input.transform.position;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Waiter" && other.gameObject.GetComponent<waiterAgentScript> ().alreadyServed) {
			Destroy (other.gameObject);
		} else {
			other.gameObject.GetComponent<waiterAgentScript> ().alreadyServed = true;
		}
	}
}