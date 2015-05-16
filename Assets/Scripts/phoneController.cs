using UnityEngine;
using System.Collections;

public class phoneController : MonoBehaviour {

	public Animation anim;
	private bool isOn = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		handleKeyPress();
	}

	void handleKeyPress() {
		print ("Handle Key Press");
		if(Input.GetKey(KeyCode.F)) {
			print("F key pressed");
			if(isOn) {
				anim.Play("phoneDown");
			}
			else {
				anim.Play("phoneUp");
			}
			isOn = !isOn;
		}
	}
}
