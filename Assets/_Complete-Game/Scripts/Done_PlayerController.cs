using UnityEngine;
using System.Collections;
// 序列化(储存并转移信息的一种方法)该类，unity才能显示出来
[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	 
	private float nextFire;
	
	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			// GameObject clone = 
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			// as GameObject; //（as GameObject 是告诉unity我们实例化了一个GameObject对象，
			//                //  新对象需要个参照对象才方便操作。但这里我们只让飞机发射，子弹并没有其他动作，所以用不到）
			GetComponent<AudioSource>().Play ();
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;

		// Mathf.Clamp(Val,Min,Max) 限制在边界内，value > Max，则返回 Max ，value < Min，则返回 Min，在边界内则返回 value （x,xMin,xMax）。
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}
