using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public bool walking;
	// Use this for initialization
	void Start () {
		walking = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			walking = !walking;
		}

		if (walking) {
			transform.position = transform.position + Camera.main.transform.forward * 1.5f * Time.deltaTime;
		}
	}
}
