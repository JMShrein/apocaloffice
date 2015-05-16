using UnityEngine;
using System.Collections;

public class texAnimation : MonoBehaviour {

	public GameObject screen;
	public Texture2D texture1;
	public Texture2D texture2;
	private bool textureToggle;
	public Shader unlitShader;
	public Renderer renderer;
	public float timer;

	// Use this for initialization
	void Start () {
		textureToggle = true;
		unlitShader = Shader.Find("Unlit/Texture");
		renderer = screen.GetComponent<Renderer>();
		renderer.material.shader = unlitShader;
		timer = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine("SwapTex");
	}

	void LateUpdate() {

	}

	IEnumerator SwapTex() {
	
		timer -= Time.deltaTime;

		if(timer < 0)
		{
			if(textureToggle)
			{
				renderer.material.mainTexture = texture1;
				textureToggle = !textureToggle;

			}
			else
			{
				renderer.material.mainTexture = texture2;
				textureToggle = !textureToggle;
			}
			timer = 0.5f;
		}

		yield return new WaitForSeconds(0.5f);
	}
}
