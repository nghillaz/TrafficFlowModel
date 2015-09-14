using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		simpleAgentScript.noodleRefills = 4;
		Time.timeScale = 0;
		simpleAgentScript.eatingDuration = 25;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void timeScaleSlider(GameObject slider){
		Time.timeScale = slider.GetComponent<Slider> ().value;
	}

	public void noodleRefillSlider(GameObject slider){
		simpleAgentScript.noodleRefills = (int) slider.GetComponent<Slider> ().value;
	}

	public void eatingDurationSlider(GameObject slider){
		simpleAgentScript.eatingDuration = (int)slider.GetComponent<Slider> ().value;
	}

	public void loadLevel(string level){
		Application.LoadLevel (level);
	}
}
