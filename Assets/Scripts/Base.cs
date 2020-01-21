using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField]
    private int HP;

    [SerializeField]
    private int walletBalanse;
    public int WalletBalanse
    {
        get
        {
            return walletBalanse;
        }
    }
     

    public static Base instance { get; private set;}

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        Enemy.OnDestroy += CalculateEnemyReward;

        UpdateUI();
    }

    private void CalculateEnemyReward(Enemy enemy)
    {
        int reward = Random.Range(enemy.enemyData.LowerReward, enemy.enemyData.UpperReward);
        ReplenishmentRequest(reward);
    }

    public void WithdrawRequest(int count)
    {
        walletBalanse -= count;
        UpdateUI();
    }

    public void ReplenishmentRequest(int count)
    {
        walletBalanse += count;
        UpdateUI();
    }

    private void UpdateUI()
    {
        UIController.instance.SetCoins(walletBalanse);
        UIController.instance.SetHealth(HP);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            HP -= other.GetComponent<Enemy>().enemyData.Damage;
            UpdateUI();           
        }
    }
}
