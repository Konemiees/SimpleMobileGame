using UnityEngine;
using System.Collections;

public class PlayerTurn : MonoBehaviour {

	public float turnSpeed = 2;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float rotateTo = transform.rotation.z; 
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			rotateTo = -Input.GetTouch(0).deltaPosition.x * turnSpeed * Time.deltaTime + rotateTo;
		} transform.rotation = Quaternion.Euler(0, 0, rotateTo);
	}
}
