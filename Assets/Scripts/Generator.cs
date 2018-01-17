using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	public float minTime;
	public float maxTime;

	public GameObject prefab;

	private float currentTime;
	private bool locked = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!locked){
			StartCoroutine(Generate());
		}
	}

	IEnumerator Generate(){
		float randomWait = Random.Range(minTime, maxTime);
		locked = true;
		yield return new WaitForSeconds(randomWait);
		Instantiate(prefab, transform.position, Quaternion.identity);
		locked = false;
	}
}
