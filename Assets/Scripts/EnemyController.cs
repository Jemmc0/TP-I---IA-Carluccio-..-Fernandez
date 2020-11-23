using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float viewRange;
    public float viewAlngle;
    public Transform target;
    public LayerMask mask;


    EnemyView _view;

    void Start()
    {
        _view = GetComponent<EnemyView>();
    }
    void Update()
    {
        if (_view.TargetInCamera(target, viewRange, viewAlngle, mask))
        {
            Debug.Log("te veo");
        }
        else
        {
            Debug.Log("no te veo");
        }
    }
}
