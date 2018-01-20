using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This only rotates and makes sprite closer to the center
/// </summary>
public class EnemyPowerUpMovement : MonoBehaviour {

	public float rotationSpeed;
	public float minMovementSpeed;
	public float maxMovementSpeed;

	private bool hasEnteredScreen;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().AddRelativeForce(
			(Vector3.zero - transform.position) * Random.Range(minMovementSpeed, maxMovementSpeed));
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, Time.deltaTime * rotationSpeed);
	}

	void OnBecameVisible(){
		hasEnteredScreen = true;
	}

	void OnBecameInvisible(){
		if(hasEnteredScreen){
			Destroy(gameObject);
		}
	}
}
