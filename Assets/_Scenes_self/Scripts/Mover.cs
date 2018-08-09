using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float speed; // Unity界面上 Inspector 中，子弹 Bolt 的速度 20，
	                    // 陨石 Asteroid 的速度 -5，使其向着 Player 飞来。
	void Start () {
		GetComponent<Rigidbody> ().velocity = transform.forward * speed;
	}
	

	void Update () {
		
	}
}
