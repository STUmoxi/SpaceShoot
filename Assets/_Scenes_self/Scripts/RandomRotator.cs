using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	public float tumble; // 翻滚值 5

	void Start () {
		// angularVelocity，旋转速率；insideUnitSphere 是vector3类型，会对x，y，z随机
		GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
