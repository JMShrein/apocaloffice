using UnityEngine;
using System.Collections;

public class camAnimation : MonoBehaviour {

	public CharacterController playerController;
	public Animation anim;
	private bool isMoving;
	public bool isRunning;

	private bool left;
	private bool right;

	void CamAnimations() {
		if(isRunning)
		{
			if(playerController.isGrounded == true) {
				if(isMoving == true) {
					if(left == true) {
						if(!anim.isPlaying){
							anim.Play ("runLeft");
							left = false;
							right = true;
						}
					}
					if(right == true)
					{
						if(!anim.isPlaying) {
							anim.Play ("runRight");
							right = false;
							left = true;
						}
					}
				}
			}
		}
		else
		{
			if(playerController.isGrounded == true) {
				if(isMoving == true) {
					if(left == true) {
						if(!anim.isPlaying){
							anim.Play ("walkLeft");
							left = false;
							right = true;
						}
					}
					if(right == true)
					{
						if(!anim.isPlaying) {
							anim.Play ("walkRight");
							right = false;
							left = true;
						}
					}
				}
			}
		}
	}

	// Use this for initialization
	void Start () {
		left = true;
		right = false;
	}
	
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		if(inputX != 0 || inputY != 0) {
			isMoving = true;
		}
		else if(inputX == 0 && inputY == 0) {
			isMoving = false;
		}

		CamAnimations();
	}
}
