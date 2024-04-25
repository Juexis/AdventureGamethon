using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    public int enemyCount;
    public int killCount;
    public GameObject[] enemyList;
    public bool levelClear;
    float randomx = 5.8f;
    float randomy = 4f;
    Vector3 spawnPos;

    void Start()
    {
        StartCoroutine(TimedSpawn(enemyCount));
        textBox.text = "Enemies remaining: " + enemyCount;
    }

    void Update()
    {
        Debug.Log(killCount);

        if (enemyCount <= 0)
        {
            levelClear = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void SpawnEnemy()
    {
        if (enemyCount > 0)
        {
            spawnPos = new Vector3(Random.Range(-randomx, randomx), Random.Range(-randomy, randomy), 0);
            Instantiate(enemyList[0], spawnPos, enemyList[0].transform.rotation);
        }
    }

    IEnumerator TimedSpawn(int count)
    {
        int i = count;
        while (i > count - count)
        {
            SpawnEnemy();
            yield return 0;
            yield return new WaitForSeconds(3.0f);
            i--;
            enemyCount--;
            textBox.text = "Enemies remaining: " + i;
        }
    }
}
