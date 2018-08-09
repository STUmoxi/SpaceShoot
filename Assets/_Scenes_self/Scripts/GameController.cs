using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 实现随机产生一个陨石
public class GameController : MonoBehaviour {

//	public GameObject hazard; // 陨石参照对象 // 多个陨石改为级数
	public GameObject[] hazards; // 陨石数组
	public Vector3 spawnValues; //   Vector3类型对象
	public int hazardCount;	// 一波陨石的数量
	public float startWait;	//// 开始准备时间，准备产生陨石

	public float spawnWait;	// 每个陨石产生的间隔时间
	public float waveWait;	// 每一波陨石产生的间隔时间

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}

	void Start () {
		gameOver = false;
		restart = false;
		score = 0;
		restartText.text = "";
		gameOverText.text = "";
		UpdateScore ();
		// 想让当前代码暂停执行而不暂停当前游戏需要协同程序
		StartCoroutine(SpawnWaves ());
	}
	void Update(){

		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}

	// 协同函数要加 IEnumerator
	IEnumerator SpawnWaves (){
		// 调用函数暂停要加 yield return new ，yield return new(暂停多少秒);
		yield return new WaitForSeconds (startWait);	// 开始准备时间

		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);	// 每个陨石生成间隔
			}
			yield return new WaitForSeconds (waveWait);

			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
		// 产生陨石的随机位置与旋转角度identity，若有角度就不能保证它撞向Player了。
//		Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
//		Quaternion spawnRotation = Quaternion.identity;
//		Instantiate (hazard, spawnPosition, spawnRotation);
	}

	void UpdateScore(){
		scoreText.text = "Score: " + score;
	}


}
