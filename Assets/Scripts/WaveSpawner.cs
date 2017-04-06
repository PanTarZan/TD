using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5;
    private float countdown = 2;
    private int waveNumber = 1;
    public Text waveCountdownText;
	
	// Update is called once per frame
	void Update () {
		if (countdown <=0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        waveCountdownText.text = "Next Wave: " + Mathf.Round(countdown).ToString();
	}

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        //Debug.Log("Wave Incoming!");
        waveNumber++;
    }

    void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
