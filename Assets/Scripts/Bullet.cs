using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// Destroys the bullet when it's outside the window
	/// </summary>
	void OnBecameInvisible(){
		Destroy(gameObject);
	}
}
