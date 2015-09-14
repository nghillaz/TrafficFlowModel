using UnityEngine;
using System.Collections;

public class stoolHeadScript : MonoBehaviour {
	public GameObject[] nodes;
	public GameObject lineEnd;
	public GameObject exit;
	public GameObject waiterManager;

	// Use this for initialization
	void Start () {
		//make it invisible
		GetComponent<Renderer> ().enabled = false;

		//initialize the node as empty
		for (int i = 0; i < nodes.Length; i++) {
			nodes[i].GetComponent<stoolNodeScript>().head = gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
		}
	}
}