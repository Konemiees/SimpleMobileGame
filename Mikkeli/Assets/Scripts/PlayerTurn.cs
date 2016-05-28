using UnityEngine;
using System.Collections;

public class PlayerTurn : MonoBehaviour {

	public float turnSpeed = 2;
	public float rotateTo;
	
	// Use this for initialization
	void Start () {
		rotateTo = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			float change = -Input.GetTouch (0).deltaPosition.x * turnSpeed;
			rotateTo = change + rotateTo;
		}if (rotateTo < 0)
			rotateTo = + 360;
		if (rotateTo > 360)
			rotateTo = rotateTo - 360;
		if (180 > rotateTo && rotateTo > 45)
			rotateTo = rotateTo + 270;
		if (180<rotateTo && rotateTo < 315)
			rotateTo = rotateTo - 270;
		transform.rotation = Quaternion.Euler(0, 0, rotateTo);
	}
	

}
