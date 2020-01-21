using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyTower : MonoBehaviour
{
    [SerializeField]
    private TowerData towerData;
    [SerializeField]
    private TextMeshProUGUI price;
    private Button button;

    public static System.Action<TowerData> BuyRequest;

    void Start()
    {
        GetComponent<Image>().sprite = towerData.Sprite;
        price.text = towerData.BuildPrice.ToString();
        button = GetComponent<Button>();
        button.onClick.AddListener(() => BuyRequest(towerData));
    }
    private void Update()
    {
        if (gameObject.activeSelf)
            if (towerData.BuildPrice < Base.instance.WalletBalanse)//check button availability
                button.interactable = true;
            else
                button.interactable = false;
    }
}
