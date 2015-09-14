using UnityEngine;
using System.Collections;

public class singletonControlScript : MonoBehaviour {
	public static singletonControlScript i;

	public static float timePassed;
	public static int peopleServed;
	// Use this for initialization
	void Start () {
	}
		
	void Awake () {
		if(!i) {
			i = this;
			DontDestroyOnLoad(gameObject);
		}else 
			Destroy(gameObject);
	}
}
