using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTowerData", menuName = "Tower", order = 1)]
public class TowerData : ScriptableObject
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
    private Sprite gunShellSprite;
    public Sprite GunShellSprite
    {
        get
        {
            return gunShellSprite;
        }
    }

    [SerializeField]
    private int buildPrice;
    public int BuildPrice
    {
        get
        {
            return buildPrice;
        }
    }

    [SerializeField]
    private float range;
    public float Range
    {
        get
        {
            return range;
        }
    }

    [SerializeField]
    private int recoil;
    public int Recoil
    {
        get
        {
            return recoil;
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
