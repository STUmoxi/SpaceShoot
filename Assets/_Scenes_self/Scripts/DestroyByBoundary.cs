using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other){
		// 出边界时自动消除，子弹、陨石等等。
		Debug.Log ("消除陨石"+other.gameObject.tag);
		Destroy (other.gameObject);
	}

	void Start () {
		Debug.Log ("消除陨石初始化");
	}
	
	void Update () {
		
	}
}
