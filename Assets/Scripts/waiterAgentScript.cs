using UnityEngine;
using System.Collections;

public class waiterAgentScript : MonoBehaviour {
	public GameObject waiterManager;

	public bool alreadyServed;

	string state;

	public Material waiterMaterial;
	// Use this for initialization
	void Start () {
		transform.GetChild (0).GetComponent<Animation> () ["Jump"].speed = .3f;

		transform.GetChild (0).GetChild(0).GetComponent<Renderer> ().material = waiterMaterial;

		alreadyServed = false;
	}
}