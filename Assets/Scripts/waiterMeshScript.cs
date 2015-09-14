using UnityEngine;
using System.Collections;

public class waiterMeshScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			GetComponent<Renderer> ().enabled = !GetComponent<Renderer> ().enabled;
		}
	}
}
