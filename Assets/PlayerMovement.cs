using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float RegSpeed = 5.0f;
	public float sprintSpeed = 10.0f;
	public float endurance = 3.0f;

	public CharacterController cc;

	public float mouseSensitivity = 5.0f;
	float verticalRotation = 0;
	public float upDownRange = 60.0f;





	// Use this for initialization
	void Start () 
	{
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		print(endurance);
		float speed = RegSpeed;

		endurance = Mathf.Clamp(endurance,0.0f,5.0f);
	


		if (Input.GetKey(KeyCode.LeftShift))
		{
			speed = sprintSpeed;
			endurance -= Time.deltaTime;


				if (endurance <= 0)
			{
				speed = RegSpeed;
			}

		}
		else
		{
			endurance += Time.deltaTime;
		}
		
		

		float forward = Input.GetAxis("Horizontal") * speed;
		float sideways = Input.GetAxis("Vertical") * speed;

		Vector3 movement = new Vector3(forward, 0.0f, sideways);

		movement = transform.rotation * movement;

		cc = GetComponent<CharacterController>();

		cc.SimpleMove(movement);


		float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
		transform.Rotate(0, rotLeftRight, 0);


		verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
	



	}
}
