using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private TowerSlot selectedTower;//tower which requests menu or tower selector


    void Start()
    {
        BuyTower.BuyRequest += buyTower;
        TowerSlot.TowerSelectionRequest += ShowTowerSelector;
        TowerSlot.TowerMenuRequest += ShowTowerMenu;
    }

    public void SellTower()
    {
        int profit = selectedTower.DeleteTower() / 2;
        selectedTower = null;
        Base.instance.ReplenishmentRequest(profit);
        UIController.instance.HideMenu();
    }

    void buyTower(TowerData data)
    {
        Base.instance.WithdrawRequest(data.BuildPrice);
        selectedTower.CreateTower(data);
        selectedTower = null;
        UIController.instance.HideMenu();
    }

    void ShowTowerSelector(TowerSlot tower)
    {
        selectedTower = tower;
        UIController.instance.ShowTowerSelector(selectedTower.transform.position);
    }

    void ShowTowerMenu(TowerSlot tower)
    {
        selectedTower = tower;
        UIController.instance.ShowTowerMenu(selectedTower.transform.position);
    }
}
