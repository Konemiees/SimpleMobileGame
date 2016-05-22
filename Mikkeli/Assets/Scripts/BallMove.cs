using UnityEngine;
using System.Collections;



public class BallMove : MonoBehaviour {

	public float Speed = 3.0f;
	private float rotation;


	// Use this for initialization
	void Start () {
		rotation = 0.001f * Random.Range (-3, 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
