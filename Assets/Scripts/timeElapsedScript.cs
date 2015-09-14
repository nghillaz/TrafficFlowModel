using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class timeElapsedScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		GetComponent<Text> ().text = "Time Elapsed: " + singletonControlScript.timePassed.ToString ();
	}
}
