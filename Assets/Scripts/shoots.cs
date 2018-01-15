using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoots : MonoBehaviour {

	private Renderer [] renderers;
	public float timeBetweenShoots;
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
			InvokeRepeating("fire", 0, timeBetweenShoots);
		}
		if (Input.GetKeyUp("space") || Input.GetButtonUp("Fire1")) {
			foreach(Renderer renderer in renderers){
				CancelInvoke("fire");
				renderer.enabled = false;
			}
		}
	}

	void fire(){
		foreach(Renderer renderer in renderers){
			renderer.enabled = !renderer.enabled;
		}
	}
}
