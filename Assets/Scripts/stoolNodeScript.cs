using UnityEngine;
using System.Collections;

public class stoolNodeScript : MonoBehaviour {
	public GameObject head;

	public bool isEmpty;

	GameObject currentAgent;

	int noodleRefills;
	// Use this for initialization
	void Start () {
		//initialize the node as empty
		isEmpty = true;

		currentAgent = null;
	}

	IEnumerator eatingTimer(){
		yield return new WaitForSeconds (simpleAgentScript.eatingDuration);
		if (noodleRefills < 1) {
			noodleRefills = 0;
			currentAgent.GetComponent<simpleAgentScript>().setState ("leaving");
			currentAgent.GetComponent<NavMeshAgent>().destination = head.GetComponent<stoolHeadScript>().exit.transform.position;
			isEmpty = true;
			head.GetComponent<stoolHeadScript> ().lineEnd.GetComponent<lineFinishScript> ().updateNode ();
		} else {
			head.GetComponent<stoolHeadScript>().waiterManager.GetComponent<waiterManagerScript>().callWaiter(gameObject);
		}
	}

	void OnTriggerEnter(Collider other){
		//if this is contact with a waiter
		if (other.gameObject.tag == "Waiter" && other.gameObject.GetComponent<NavMeshAgent>().remainingDistance < 1f) {
			other.gameObject.GetComponent<NavMeshAgent>().destination = other.gameObject.GetComponent<waiterAgentScript>().waiterManager.transform.position;
			noodleRefills--;
			StartCoroutine("eatingTimer");
		}

		//if this is contact with a person
		if (other.gameObject.tag == "PersonAgent" && other.gameObject.GetComponent<NavMeshAgent>().remainingDistance < 1f) {
			isEmpty = false;
			other.gameObject.transform.position = transform.position;
			other.gameObject.GetComponent<simpleAgentScript>().setState ("eating");
			currentAgent = other.gameObject;
			//generate a random amount of noodle refills and make the person start eating
			noodleRefills = Mathf.FloorToInt(Random.Range (0,simpleAgentScript.noodleRefills));
			StartCoroutine("eatingTimer");
		}
	}
}