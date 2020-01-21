using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    public Transform[] path;
    public static EnemyPath instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
