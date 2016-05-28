using UnityEngine;
using System.Collections;



public class BallMove : MonoBehaviour {


	public float Speed = 3.0f;
	public float minVar = -3;
	public float maxVar = 3;


	private float rotation;
	private float dirX;
	private float dirY;



	// Use this for initialization
	void Start () {
		rotation = 0.001f * Random.Range (minVar, maxVar);
		dirX = -Mathf.Sign (transform.position.x);
		dirY = -Mathf.Sign (transform.position.y);
		if (dirX > 0 && dirY > 0) {
			rotation = rotation + 45;
		} if (dirX > 0 && dirY < 0) {
			rotation = rotation + 135;
		} if (dirX < 0 && dirY > 0) {
			rotation = rotation + 225;
		} if (dirX < 0 && dirY < 0) {
			rotation = rotation + 315;
		} Quaternion.Euler(new Vector3(0, 0, rotation));
	}
	
	// Update is called once per frame
	void Update () {
		checkDir ();
		Quaternion.Euler(new Vector3(0, 0, rotation));
		float next = transform.position.x;
	}


	private void checkDir(){
		if (rotation < 0)
			rotation = + 360;
		if (rotation > 360)
			rotation = rotation - 360;
		if(rotation >= 0 && rotation < 90){
			dirX = 1;
			dirY = 1;
		} if(rotation >= 90 && rotation < 180){
			dirX = -1;
			dirY = 1;
		} if(rotation >= 180 && rotation < 270){
			dirX = -1;
			dirY = -1;
		} if(rotation >= 270 && rotation < 360){
			dirX = 1;
			dirY = -1;
		}
	}

	public void OnTriggerEnter(Collider other){
		if (other.tag == "Finish")
			Destroy (this.gameObject);
		if(other.tag == "Ball")
			int a = 0;
		if(other.tag == "Untagged"){
			Entity hit = other.GetComponent<Entity>;
			if(hit is Player){
			}else{
				EntityCollision(hit);
			}

		}
	}


	private void EntityCollision(Entity hit){
		if(hit.angle = 0 )
	}

}
