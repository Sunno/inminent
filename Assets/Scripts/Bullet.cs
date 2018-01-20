using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {

	public int scoreByEnemy;
	static private int score = 0;

	private GameObject scoreGameObject;
	private Text scoreText;


	// Use this for initialization
	void Start () {
		scoreGameObject = GameObject.Find("Score");
		scoreText = scoreGameObject.GetComponent<Text>();
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

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Enemy"){
			score += scoreByEnemy;
			scoreText.text = "Score: " + score;
		}
		if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "PowerUp"){
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}
}
