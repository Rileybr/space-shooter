using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public Text scoreText;
	public Text restartText;
	public Text gameOverText;

	private bool restart;
	private bool gameOver;
	private int score;

	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	// lets you restart the game after you lose by pressing the "R" key
	void Update ()
	{
		if (restart) {
			if (Input.GetKey (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			// spawns hazards with some time inbewteen each hazard
			for (int i = 0; i < hazardCount; i ++) {
				GameObject hazard = hazards[Random.Range (0,hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			// lets you restart the game after you lose by pressing the "R" key
			yield return new WaitForSeconds (waveWait);
			if (gameOver) {
				restartText.text = "Press 'R' To Restart";
				restart = true;
				break;
			}
		}
	}
	public void AddScore (int newScoreValue)
	{
		// updates score
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		// shows your score
		scoreText.text = "score: " + score;
	}
	public void GameOver()
	{
		// writes game over text when player loses
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}