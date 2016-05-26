using UnityEngine;
using System.Collections;

public class TestPlayerScript : MonoBehaviour {

	public float turnSpeed = 2;
	private float rotateTo;

	// Use this for initialization
	void Start () {
		rotateTo = 0;
	}
	
	// Update is called once per frame
	void Update () {
		float change = -Input.GetAxisRaw ("Mouse X") * turnSpeed;
		if (Input.GetMouseButton(0) && change != 0) {
			rotateTo = change + rotateTo;
		}while (rotateTo > 90)
			rotateTo = rotateTo - 90;
		while (rotateTo < 0)
			rotateTo = + 90;
		transform.rotation = Quaternion.Euler(0, 0, rotateTo);
	}
}
