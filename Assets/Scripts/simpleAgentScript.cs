using UnityEngine;
using System.Collections;

public class simpleAgentScript : MonoBehaviour {
	NavMeshAgent agent;

	public Material maleMaterial;
	public Material femaleMaterial;

	string state;

	public static float eatingDuration;

	public static int noodleRefills;
	// Use this for initialization
	void Start () {
		//default to male material
		if (Random.value > .5) {
			transform.GetChild (0).GetChild (0).GetComponent<Renderer> ().material = maleMaterial;
		} else {
			transform.GetChild (0).GetChild (0).GetComponent<Renderer> ().material = femaleMaterial;
		}

		agent = GetComponent<NavMeshAgent> ();
		//default to walking state
		setState ("walking");
	}

	public void setState(string input){
		state = input;
		if (state == "walking") {
			transform.GetChild (0).GetComponent<Animation> () ["Jump"].speed = .3f;
			transform.GetChild (0).GetComponent<Animation> ().Play ();
			agent.speed = 1;
		}
		if (state == "waiting") {
			//setting the agent destination to the next node is handled by lineNodeScript
			transform.GetChild(0).GetComponent<Animation>().Stop ();
			agent.speed = 0;
		}
		if (state == "eating") {
			transform.GetChild(0).GetComponent<Animation>().Stop ();
		}
		if (state == "leaving") {
			transform.GetChild(0).GetComponent<Animation>().Play ();
		}
	}

	public string getState(){
		return state;
	}
}