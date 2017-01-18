using UnityEngine;
using System.Collections;

public class MouseClickMovement : MonoBehaviour {
	void Start() {
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Z)) {
			RaycastHit hit;

			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
				if (hit.collider.gameObject.name == "Floor") {
					transform.position = hit.point;
					transform.Translate(Vector3.up * 1, Space.World); 
				}
			}
		}
	}
}
