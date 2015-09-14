using UnityEngine;
using System.Collections;

public class lineNodeScript : MonoBehaviour {
	public GameObject next;
	public GameObject previous;

	public bool isEmpty;

	public GameObject currentAgent;
	// Use this for initialization
	void Start () {
		//make it invisible
		GetComponent<Renderer> ().enabled = false;

		//set the list to be doubly linked, just in case!
		//if it is the second to last node, there's an extra check
		if (next.GetComponent<lineNodeScript> () == null) {
			next.GetComponent<lineFinishScript>().previous = gameObject;
		}else{
			next.GetComponent<lineNodeScript> ().previous = gameObject;
		}

		//initialize the node as empty
		isEmpty = true;

		currentAgent = null;

		//previous is set in this node by the previous node in the list
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
			//tell the previous node that it can be empty now
			if(previous.GetComponent<lineNodeScript>() == null){
				previous.GetComponent<lineStartScript>().isEmpty = true;
			}
			//next node is another middle node
			else{
				previous.GetComponent<lineNodeScript>().isEmpty = true;
			}
			other.gameObject.transform.position = transform.position;
			currentAgent = other.gameObject;
			updatePreviousNodes();
			updateNode ();
		}
	}

	public void updateNode(){
		//if this node is empty, pass the update to the next node and return
		if(isEmpty){
			updatePreviousNodes();
			return;
		}

		//if the next node is empty, reroute the agent to the next node
		//the case where the next node is the finish node
		if(next.GetComponent<lineNodeScript>() == null){
			//check to see if the next node is empty
			if(next.GetComponent<lineFinishScript>().isEmpty){
				currentAgent.GetComponent<NavMeshAgent>().destination = next.transform.position;
				currentAgent.GetComponent<simpleAgentScript>().setState ("walking");
				updatePreviousNodes ();
				return;
			}
		}
		//the case where the next node is another middle node
		else{
			//check to see if the next node is empty
			if(next.GetComponent<lineNodeScript>().isEmpty){
				currentAgent.GetComponent<NavMeshAgent>().destination = next.transform.position;
				currentAgent.GetComponent<simpleAgentScript>().setState ("walking");
				updatePreviousNodes ();
				return;
			}
		}

		//if this node has an agent and the next node is not empty, keep the agent at this node
		//if the next node is the finish node
		if (next.GetComponent<lineNodeScript> () == null) {
			if (!next.GetComponent<lineFinishScript> ().isEmpty) {
				currentAgent.GetComponent<simpleAgentScript> ().setState ("waiting");
				updatePreviousNodes ();
				return;
			}
		}else{
			if(!next.GetComponent<lineNodeScript> ().isEmpty) {
				currentAgent.GetComponent<simpleAgentScript>().setState ("waiting");
				updatePreviousNodes ();
				return;
			}
		}
	}

	void updatePreviousNodes(){
		//update the previous nodes
		//if the next node is the finish node
		if(previous.GetComponent<lineNodeScript>() == null){
			previous.GetComponent<lineStartScript>().updateNode ();
		}
		//next node is another middle node
		else{
			previous.GetComponent<lineNodeScript>().updateNode();
		}
	}
}