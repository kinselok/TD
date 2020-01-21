using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "Wave", order = 3)]
public class WaveData : ScriptableObject
{
    [SerializeField]
    private int duration;
    public int Duration
    {
        get
        {
            return duration;
        }
    }

    [SerializeField]
    private List<EnemyData> enemies;
    public List<EnemyData> Enemies
    {
        get
        {
            return enemies;
        }
    }

    [SerializeField]
    private List<int> enemiesCount;
    public List<int> EnemiesCount
    {
        get
        {
            return enemiesCount;
        }
    }

    public int GetEnemyCount()
    {
        int total = 0;
        foreach (var count in enemiesCount)
        {
            total += count;
        }
        return total;
    }
}
