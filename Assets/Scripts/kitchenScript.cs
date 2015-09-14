using UnityEngine;
using System.Collections;

public class kitchenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			GetComponent<Renderer> ().enabled = !GetComponent<Renderer> ().enabled;
		}
	}
}
