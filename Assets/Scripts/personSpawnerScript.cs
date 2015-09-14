using UnityEngine;
using System.Collections;

public class personSpawnerScript : MonoBehaviour {
	public GameObject personPrefab;
	public GameObject lineStart;

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

		if (lineStart.GetComponent<lineStartScript> ().isEmpty) {
			spawnPerson ();
			lineStart.GetComponent<lineStartScript> ().isEmpty = false;
		}
	}

	public void spawnPerson(){
		GameObject tempPerson = (GameObject)Instantiate (personPrefab, transform.position, Quaternion.identity);
		tempPerson.GetComponent<NavMeshAgent> ().destination = lineStart.transform.position;
	}
}