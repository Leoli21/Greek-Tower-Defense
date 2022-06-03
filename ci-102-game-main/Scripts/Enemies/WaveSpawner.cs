using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour {

    public static int EnemiesAlive = 0;

    public Transform enemyPrefab;

    public Transform enemy2Prefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public Text waveCountdownText;

    private int waveNumber = 0;

    void Update ()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(countdown).ToString();

    }

    IEnumerator SpawnWave ()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            if (i % 5 == 0 && i != 0)
            {
                SpawnBoss();
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }
            if (waveNumber == 10)
            {
                GameOver();
            }
        }
    }

    void SpawnEnemy ()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive ++;
    }
    void SpawnBoss ()
    {
        Instantiate(enemy2Prefab, spawnPoint.position, spawnPoint.rotation);
    }
    void GameOver()
    {
        SceneManager.LoadScene("EndScreen");
    }

}