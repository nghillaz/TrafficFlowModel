using UnityEngine;
using System.Collections;

public class lineFinishScript : MonoBehaviour {
	public GameObject previous;
	public GameObject[] stoolHeadArray;

	public bool isEmpty;

	GameObject currentAgent;
	// Use this for initialization
	void Start () {
		//make it invisible
		GetComponent<Renderer> ().enabled = false;

		//initialize the node as empty
		isEmpty = true;

		currentAgent = null;

		//initialize it so that each head knows the line routed to it
		for (int i = 0; i < stoolHeadArray.Length; i++) {
			stoolHeadArray[i].GetComponent<stoolHeadScript>().lineEnd = gameObject;
		}

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
		//iterate through the various stool-sets you can pipe to
		for (int i = 0; i < stoolHeadArray.Length; i++) {
			//iterate through the various stools in each stool-set
			for(int j = 0; j < stoolHeadArray[i].GetComponent<stoolHeadScript>().nodes.Length; j++){
				if(stoolHeadArray[i].GetComponent<stoolHeadScript>().nodes[j].GetComponent<stoolNodeScript>().isEmpty){
					//make the agent go to his empty seat
					stoolHeadArray[i].GetComponent<stoolHeadScript>().nodes[j].GetComponent<stoolNodeScript>().isEmpty = false;
					currentAgent.GetComponent<simpleAgentScript>().setState ("walking");
					currentAgent.GetComponent<NavMeshAgent>().destination = stoolHeadArray[i].GetComponent<stoolHeadScript>().nodes[j].transform.position;
					isEmpty = true;
					updatePreviousNodes ();
					return;
				}
			}
		}
		//make him wait
		currentAgent.GetComponent<simpleAgentScript>().setState ("waiting");
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