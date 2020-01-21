using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Tower : MonoBehaviour
{  
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private CircleCollider2D attackRange;
    [SerializeField]
    private GameObject GunShellPrefab;
    [SerializeField]
    private Transform towerPosition;

    private TowerData towerData;
    private List<Transform> reachableEnemies; //enemies in attack range
    private Queue<GunShell> availableGunShells; //to avoid the regular creation and deletion of instances
    private float rotationSpeed = 5;

    void Start()
    {
        reachableEnemies = new List<Transform>();
        availableGunShells = new Queue<GunShell>();
    }

    void SetGunShellAvailible(GunShell gunShell)
    {
        gunShell.gameObject.SetActive(false);
        availableGunShells.Enqueue(gunShell);
    }

    void Update()
    {
        if (reachableEnemies.Count > 0)
        {
            //rotate tower towards the enemy which it is attacking
            Vector3 vectorToTarget = reachableEnemies[0].position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
        }
    }

    public void Create(TowerData data)
    {
        towerData = data;
        spriteRenderer.sprite = towerData.Sprite;
        attackRange.radius = towerData.Range;
        gameObject.SetActive(true);
    }

    /// <summary>
    /// returns build price
    /// </summary>
    public int Sell()
    {
        gameObject.SetActive(false);
        return towerData.BuildPrice;
    }

    private IEnumerator Shoot()
    {
        while (reachableEnemies.Count > 0)
        {
            if (availableGunShells.Count > 0)
            {
                var gunShell = availableGunShells.Dequeue();
                gunShell.gameObject.SetActive(true);
                gunShell.Init(reachableEnemies[0], towerData.Damage, towerData.GunShellSprite);
            }
            else
            {
                var obj = Instantiate(GunShellPrefab, towerPosition.position, Quaternion.identity);
                var script = obj.GetComponent<GunShell>();
                script.OnDestroy += SetGunShellAvailible;
                script.Init(reachableEnemies[0], towerData.Damage, towerData.GunShellSprite);
            }
            yield return new WaitForSeconds(towerData.Recoil);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if (reachableEnemies.Count < 1)
            {
                reachableEnemies.Add(other.transform);
                StopAllCoroutines();
                StartCoroutine("Shoot");
            }
            else
                reachableEnemies.Add(other.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
            reachableEnemies.Remove(other.transform);
    }
}
