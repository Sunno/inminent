using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour {

	public float speed = 200;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float rotation = -1 * Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		transform.Rotate(0, 0, rotation);
	}

}
