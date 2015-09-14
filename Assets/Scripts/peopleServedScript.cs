using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class peopleServedScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Text> ().text = "People Served: " + singletonControlScript.peopleServed.ToString();
		string fileName = Application.dataPath + "output.txt";

		StreamWriter Sw = File.CreateText (fileName);
		Sw.WriteLine ("Count: " + singletonControlScript.peopleServed.ToString() + ", Time: " + singletonControlScript.timePassed);
		Sw.Close ();
	}
}
