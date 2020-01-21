using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    public EnemyData enemyData { get; private set; }
    private int damageTaken;
    private Sequence movementSequence;

    public static System.Action<Enemy> OnDestroy;

    private void Start()
    {
        transform.position = EnemyPath.instance.path[0].position;
    }

    public void Init(EnemyData data)
    {
        movementSequence = DOTween.Sequence();
        damageTaken = 0;
        enemyData = data;
        spriteRenderer.sprite = enemyData.Sprite;
        gameObject.SetActive(true);
        transform.position = new Vector3(EnemyPath.instance.path[0].position.x, EnemyPath.instance.path[0].position.y, 0);
        InitMovement();
    }

    private void InitMovement()
    {
        var path = EnemyPath.instance.path;

        for (int i = 1; i < path.Length; i++)
        {
            //movement
            var distance = Vector3.Distance(path[i].position, path[i - 1].position);
            var duration = distance / enemyData.MoveSpeed;
            movementSequence.Append(transform.DOMove(path[i].position, duration).SetEase(Ease.Linear));

            //rotation
            Vector3 vectorToTarget = path[i].position - path[i-1].position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            movementSequence.Join(transform.DORotateQuaternion(q, 0.5f));
        }
    }

    private void Kill()
    {
        movementSequence.Kill();
        OnDestroy(this);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "GunShell")
        {
            var dmg = other.gameObject.GetComponent<GunShell>().damage;

            if (damageTaken + dmg > enemyData.HP)
                Kill();
            else
                damageTaken += dmg;
        }
        else
            if (other.tag == "Base")              
                Kill();
    }
}
