using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject toSpawn;
	public Transform spawnPoint;
	public float minTime = 2;
	public float maxTime = 10;

	private float waitTime;
	private float timeWaited;

	// Use this for initialization
	void Start () {
		waitTime = Random.Range(minTime, maxTime);
		timeWaited = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeWaited >= waitTime) {
			waitTime = Random.Range (minTime, maxTime);
			timeWaited = 0;
			Instantiate (toSpawn, spawnPoint.position, Quaternion.identity);
		} else {
			timeWaited = + Time.deltaTime;
		}
	}
}
