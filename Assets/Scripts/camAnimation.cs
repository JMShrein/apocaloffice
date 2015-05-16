using UnityEngine;
using System.Collections;

public class camAnimation : MonoBehaviour {

	public CharacterController playerController;
	public Animation anim;
	private bool isMoving;
	public bool isRunning;
	public GameObject player;

	private bool left;
	private bool right;
	private bool isBeginning;
	private ScriptableObject lookScript;

	void CamAnimations() {

		if(isBeginning) {
			anim.Play("zoomOut");
			isBeginning = false;
		}

		if(!anim.IsPlaying("zoomOut")) {
			player.GetComponent<PlayerMovement>().enabled = true;
		}

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
		isBeginning = true;

		player.GetComponent<PlayerMovement>().enabled = false;
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
