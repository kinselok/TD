using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private WaveData[] wavesData;

    private Queue<Enemy> availableEnemies;//to avoid the regular creation and deletion of instances


    void Start()
    {
        availableEnemies = new Queue<Enemy>();
        Enemy.OnDestroy += SetEnemyAvailable;
        if (EnemyPath.instance.path.Length > 1)
            StartCoroutine("Spawn");
    }


    private IEnumerator Spawn()
    {
        for (int waveNumber = 0; waveNumber < wavesData.Length; waveNumber++)
        {
            UIController.instance.SetWave(waveNumber + 1, wavesData.Length);

            var wave = wavesData[waveNumber];
            float spawnRate = wave.Duration / wave.GetEnemyCount();

            for (int enemyTypeNumber = 0; enemyTypeNumber < wave.Enemies.Count; enemyTypeNumber++)
                for (int i = 0; i < wave.EnemiesCount[enemyTypeNumber]; i++)
                {
                    if (availableEnemies.Count < 1)
                    {
                        var enemy = Instantiate(enemyPrefab);
                        enemy.GetComponent<Enemy>().Init(wave.Enemies[enemyTypeNumber]);
                    }
                    else
                    {
                        var enemy = availableEnemies.Dequeue();
                        enemy.Init(wave.Enemies[enemyTypeNumber]);
                    }
                    yield return new WaitForSeconds(spawnRate);
                }
        }
    }


    private void SetEnemyAvailable(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        availableEnemies.Enqueue(enemy);
    }
}
