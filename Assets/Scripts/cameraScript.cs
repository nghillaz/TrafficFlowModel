using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {
	float zoom;
	float speed;
	float time;
	bool paused;
	// Use this for initialization
	void Start () {
		speed = 3;
		zoom = .4f;
		time = 0f;
		paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			paused = !paused;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			zoom += .01f;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			zoom -= .01f;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			time -= .05f;
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			time += .05f;
		} else if(!paused){
			time += .01f;
		}
		transform.position = new Vector3 (20 / zoom * Mathf.Cos (time/speed), 20 / zoom, 20 / zoom * Mathf.Sin (time/speed));


		transform.LookAt(new Vector3 (0, 0, 0));
	}
}
