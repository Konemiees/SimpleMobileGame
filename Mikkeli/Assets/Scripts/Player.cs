using UnityEngine;
using System.Collections;

public class Player : Entity {


	public int dir = 0;

	
	// Update is called once per frame
	void Update () {

		angle = FindObjectOfType<TestPlayerScript>().rotateTo;
	}
}
