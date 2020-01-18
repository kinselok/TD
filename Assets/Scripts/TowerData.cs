using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "Tower", order = 1)]
public class TowerData : ScriptableObject
{
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
    private int range;
    public int Range
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
