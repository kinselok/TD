using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class UIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI health;
    [SerializeField]
    private TextMeshProUGUI coins;
    [SerializeField]
    private TextMeshProUGUI wave;
    [SerializeField]
    private GameObject towerSelector;
    [SerializeField]
    private GameObject towerMenu;
    [SerializeField]
    private GameObject closingArea;
    [SerializeField]
    private GameObject restartWindow;

    public static UIController instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Debug.Log(gameObject.name);
            Destroy(this);
        }
    }

    public void HideMenu()
    {
        towerSelector.SetActive(false);
        towerMenu.SetActive(false);
        closingArea.SetActive(false);
    }

    public void SetHealth(int count)
    {
        health.text = count.ToString();
    }

    public void SetCoins(int count)
    {
        coins.text = count.ToString();
    }

    public void SetWave(int current, int total)
    {
        wave.text = string.Format("{0}/{1}", current, total);
    }

    public void ShowTowerMenu(Vector3 position)
    {
        towerMenu.transform.position = position;
        towerMenu.SetActive(true);
        closingArea.SetActive(true);
    }

    public void ShowTowerSelector(Vector3 position)
    {
        towerSelector.transform.position = position;
        towerSelector.SetActive(true);
        closingArea.SetActive(true);
    }
}
