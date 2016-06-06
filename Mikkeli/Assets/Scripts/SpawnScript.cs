using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject toSpawn;
	private Transform spawnPoint;
	public float minTime = 2;
	public float maxTime = 10;
	private Object target;

	private float waitTime;
	private float timeWaited;

	// Use this for initialization
	void Start () {
		waitTime = Random.Range(minTime, maxTime);
		timeWaited = 0;
		spawnPoint = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (!target) {
			if (timeWaited >= waitTime) {
				waitTime = Random.Range (minTime, maxTime);
				timeWaited = 0;
				target = Instantiate (toSpawn, spawnPoint.position, Quaternion.identity);
			} else {
				timeWaited = timeWaited + Time.deltaTime;
			}
		}
	}
}
