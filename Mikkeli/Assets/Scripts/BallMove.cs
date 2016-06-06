using UnityEngine;
using System.Collections;



public class BallMove : MonoBehaviour {


	public float Speed = 3.0f;
	public float minVar = -3;
	public float maxVar = 3;
	public float changeTo;

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
	void LateUpdate () {
		checkDir ();
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
		changeTo = rotation;
		transform.Translate(new Vector3(Speed*Time.deltaTime, 0, 0));
		if (transform.position.y < -7 || transform.position.y > 7 || transform.position.x < -7 || transform.position.x > 7)
			Destroy (this.gameObject);
	}


	private void checkDir(){
		if (rotation < 0)
			rotation += 360;
		if (rotation > 360)
			rotation -= 360;
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
		float rota;
		if (other.tag == "Finish") {
			Destroy (this.gameObject);
		}
		if (other.tag == "Ball") {
			rotation = other.GetComponent<BallMove>().changeTo;
		}
		if(other.tag == "Untagged"){
			Entity hit = other.GetComponent<Entity>();
			if(hit is Player){
				Player hitter = (Player) hit;
				float dir;
				if (hitter.dir == 1 || hitter.dir == 3){
					dir = 0;
				} else{
					dir =90;
				}rotation -= hitter.angle;
				rotation = EntityCollision(dir);
				rotation += hitter.angle;
			}else{
				rotation = EntityCollision(hit.angle);
			}

		}
	}


	private float EntityCollision(float angle){
		float retVal = 0;
		if (angle == 0) {
			retVal = 0 - rotation;
		} if (angle == 90) {
			retVal = 180-rotation;
		} if (angle == 45){
			retVal = rotation-45;
			retVal = 0-retVal;
			retVal = retVal+45;
		} return retVal;
	}




}
