using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion; // 装陨石爆破动画

	public GameObject playerExplosion; // 装飞船爆破动画

	public int scoreValue;
	public GameController gameController; // 

	void OnTriggerEnter(Collider other){
		if (other.tag == "Boundary" || other.tag == "Enemy") // 把boundary排除掉哦
			return;

		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}

		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}

		gameController.AddScore(scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}

//	void OnTriggerExit(Collider other){
//		if (other.tag == "Boundary") {
//			Destroy (gameObject);
//		}
//	}

	void Start () {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	void Update () {
		
	}
}
