using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoots : MonoBehaviour {

	private Renderer [] renderers;

	public GameObject projectilePrefab;
	public float timeBetweenShoots;
	public float projectileSpeed;
	public float dissapearFireTime;

	private float nextFireDissapearTime = 0;

	// Use this for initialization
	void Start () {
		renderers = gameObject.GetComponentsInChildren<Renderer>();
		foreach(Renderer renderer in renderers){
			renderer.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space") || Input.GetButtonDown("Fire1")) {
			startFiring();
		}
		if (Input.GetKeyUp("space") || Input.GetButtonUp("Fire1")) {
			stopFiring();
		}

		if (Time.time > nextFireDissapearTime){
			turnOffFire();
		}

	}

	/// <summary>
	/// This Method invoques the shooting every timeBetweenShoots seconds
	/// </summary>
	void startFiring(){
		InvokeRepeating("fire", 0, timeBetweenShoots);
	}
	
	/// <summary>
	/// Stops firing the bullets
	/// </summary>
	void stopFiring(){
		CancelInvoke("fire");
		turnOffFire();
	}

	/// <summary>
	/// Stop rendering the fires
	/// </summary>
	void turnOffFire(){
		foreach(Renderer renderer in renderers){
			renderer.enabled = false;
		}
	}

	/// <summary>
	/// This method is supossed to be called every timeBetweenShoots seconds
	/// Makes the fires to appear and create a bullet for every cannon
	/// </summary>
	void fire(){
		foreach(Renderer renderer in renderers){
			renderer.enabled = true;
			nextFireDissapearTime = Time.time + dissapearFireTime;
			if(renderer.enabled) {
				// shoot bullets
				GameObject bullet = (GameObject)Instantiate(
					projectilePrefab,
					renderer.transform.position, renderer.transform.rotation
				);
				Renderer bulletRenderer = bullet.GetComponent<Renderer>();
				bulletRenderer.sortingLayerName = renderer.sortingLayerName;
				bulletRenderer.sortingOrder = 0;
				bullet.GetComponent<Rigidbody2D>().AddForce(
					renderer.transform.position * projectileSpeed);
			}
		}
		
	}
}
