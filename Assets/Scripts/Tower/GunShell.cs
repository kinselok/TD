using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GunShell : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float speed = 6;

    private Vector3 startPos;
    private Transform target;


    public int damage;
    public System.Action<GunShell> OnDestroy;

    private void Awake()
    {
        startPos = transform.position;
    }

    public void Init(Transform target, int damage, Sprite gunShell)
    {
        transform.position = startPos;
        this.target = target;
        this.damage = damage;
        spriteRenderer.sprite = gunShell;
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if ((transform.position - target.position).magnitude < 0.1)//if gun shell has reached the enemy's position, but he's dead already
            Disable();
    }

    private void Disable()
    {
        if(gameObject.activeSelf)
            OnDestroy(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
            OnDestroy(this);
    }
}
