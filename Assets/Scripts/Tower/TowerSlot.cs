using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerSlot : MonoBehaviour, IPointerDownHandler
{
    private SpriteRenderer spriteRenderer;
    private bool isTowerHere;

    [SerializeField]
    private Tower tower;

    public static System.Action<TowerSlot> TowerSelectionRequest;
    public static System.Action<TowerSlot> TowerMenuRequest;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        isTowerHere = false;
    }

    public void CreateTower(TowerData data)
    {
        isTowerHere = true;
        spriteRenderer.enabled = false;
        tower.Create(data);
    }

    public int DeleteTower()
    {
        var price = tower.Sell();

        spriteRenderer.enabled = true;
        isTowerHere = false;
        return price;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isTowerHere)
            TowerSelectionRequest(this);
        else
            TowerMenuRequest(this);
    }
}
