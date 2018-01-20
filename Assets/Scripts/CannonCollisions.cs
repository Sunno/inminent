using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class CannonCollisions : MonoBehaviour {

	public SimpleHealthBar healthBar;
	public GameObject gameOverPanel;

	public float blinkTime;

	public int maxHealth;
	public int damageByEnemyHit;
	public int recoverHealthByHit;

	private int health;


	// Use this for initialization
	void Start () {
		health = maxHealth;
		gameOverPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D collision){

		if(collision.gameObject.tag == "Enemy"){
			damage();
			Destroy(collision.gameObject);
		}
		else if(collision.gameObject.tag == "PowerUp"){
			heal();
			Destroy(collision.gameObject);
		}
	}

	void damage(){
		health -= damageByEnemyHit;
		healthBar.UpdateBar(health, maxHealth);
		StartCoroutine(Blink(new Color(1, 0, 0)));
		if (health == 0){
			// Game Over
			Destroy(gameObject);
			gameOverPanel.SetActive(true);
		}
	}

	void heal(){
		if (health < maxHealth){
			health += recoverHealthByHit;
			StartCoroutine(Blink(new Color(0.3529411764705882f, 1, 1)));
			healthBar.UpdateBar(health, maxHealth);
		}
	}

	IEnumerator Blink(Color color){
		healthBar.UpdateColor(color);
		yield return new WaitForSeconds(blinkTime);
		healthBar.UpdateColor(new Color(0.3254901960784314f, 1, 0, 1));
		yield return new WaitForSeconds(blinkTime);
		healthBar.UpdateColor(color);
		yield return new WaitForSeconds(blinkTime);
		healthBar.UpdateColor(new Color(0.3254901960784314f, 1, 0, 1));
	}
}
