using UnityEngine;
using System.Collections;
using System;

public class MyLogHandler : ILogHandler
{
	public void LogFormat (LogType logType, UnityEngine.Object context, string format, params object[] args)
	{
		Debug.logger.logHandler.LogFormat (logType, context, format, args);
	}

	public void LogException (Exception exception, UnityEngine.Object context)
	{
		Debug.logger.LogException (exception, context);
	}
}

public class FrontTrigger : MonoBehaviour {
	public string roomTitle;
	Logger logger;

	private GameObject mainCamera;
	private GameObject textDisplay;

	private float maxDistance = 2;

	private bool numberDisplayed = false;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");

		logger = new Logger(new MyLogHandler());
		logger.Log ("Test");
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ViewportPointToRay(new Vector3 (.5f, .5f, 0));
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.gameObject == this.gameObject && checkCameraDistance()) {
				if (!numberDisplayed) {
					createNumberDisplay ();
				}
			} 
		}

		if (!checkCameraDistance () && numberDisplayed) {
			GameObject.Destroy (textDisplay);
			numberDisplayed = false;
		}
	}

	void logTitle () {
		logger.Log (roomTitle);
	}

	private bool checkCameraDistance () {
		float positionDifferenceX = mainCamera.transform.position.x - this.gameObject.transform.position.x;
		float positionDifferenceZ = mainCamera.transform.position.z - this.gameObject.transform.position.z;

		return positionDifferenceX < maxDistance
		&& positionDifferenceX > maxDistance * -1
		&& positionDifferenceZ < maxDistance
		&& positionDifferenceZ > maxDistance * -1;
	}

	private void createNumberDisplay() {
		numberDisplayed = true;
	
		textDisplay = new GameObject("textDisplay");
		textDisplay.transform.SetParent(this.transform.root.transform);
		textDisplay.transform.position = this.transform.position;
		textDisplay.transform.rotation = this.transform.rotation;

		logger.Log (this.transform.root.name);

		TextMesh myText = textDisplay.AddComponent<TextMesh>();
		myText.text = roomTitle;
		myText.alignment = TextAlignment.Center;
	}
}
