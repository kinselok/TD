using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Enemy", order = 2)]
public class EnemyData : ScriptableObject
{
    [SerializeField]
    private Sprite sprite;
    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
    }

    [SerializeField]
    private int hp;
    public int HP
    {
        get
        {
            return hp;
        }
    }

    [SerializeField]
    private float moveSpeed;
    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }
    }

    [SerializeField]
    private int lowerReward;
    public int LowerReward
    {
        get
        {
            return lowerReward;
        }
    }
    [SerializeField]
    private int upperReward;
    public int UpperReward
    {
        get
        {
            return upperReward;
        }
    }

    [SerializeField]
    private int damage;
    public int Damage
    {
        get
        {
            return damage;
        }
    }
}
