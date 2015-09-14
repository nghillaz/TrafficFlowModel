using UnityEngine;
using System.Collections;

public class lineStartScript : MonoBehaviour {
	public GameObject next;

	public bool isEmpty;

	GameObject currentAgent;
	// Use this for initialization
	void Start () {
		//make it invisible
		GetComponent<Renderer> ().enabled = false;

		//initialize the node as empty
		isEmpty = true;

		currentAgent = null;

		next.GetComponent<lineNodeScript> ().previous = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "PersonAgent" && other.gameObject.GetComponent<NavMeshAgent>().remainingDistance < 1f) {
			isEmpty = false;
			other.gameObject.transform.position = transform.position;
			currentAgent = other.gameObject;
			updateNode ();
		}
	}

	public void updateNode(){
		if (isEmpty) {
			return;
		}

		//if the next node is empty, reroute the agent to the next node
		//the case where the next node is the finish node
		if(next.GetComponent<lineNodeScript>() == null){
			//check to see if the next node is empty
			if(next.GetComponent<lineFinishScript>().isEmpty){
				currentAgent.GetComponent<NavMeshAgent>().destination = next.transform.position;
				currentAgent.GetComponent<simpleAgentScript>().setState ("walking");
				return;
			}
		}
		//the case where the next node is another middle node
		else{
			//check to see if the next node is empty
			if(next.GetComponent<lineNodeScript>().isEmpty){
				currentAgent.GetComponent<NavMeshAgent>().destination = next.transform.position;
				currentAgent.GetComponent<simpleAgentScript>().setState ("walking");
				return;
			}
		}
		
		//if this node has an agent and the next node is not empty, keep the agent at this node
		//if the next node is the finish node
		if (next.GetComponent<lineNodeScript> () == null) {
			if (!next.GetComponent<lineFinishScript> ().isEmpty) {
				currentAgent.GetComponent<simpleAgentScript> ().setState ("waiting");
				isEmpty = false;
				return;
			}
		}else{
			if(!next.GetComponent<lineNodeScript> ().isEmpty) {
				currentAgent.GetComponent<simpleAgentScript>().setState ("waiting");
				isEmpty = false;
				return;
			}
		}
	}
}