using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

	public float lifetime;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifetime);	// 延迟 lifetime 的时间执行销毁，两个爆炸效果的 lifetime 都是设置为 2
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
