using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMover : MonoBehaviour
{
    [SerializeField]
    private Transform _targetTransfrom;//speeds up performances if assigned in inspector and chached
    
    [SerializeField]
    private float _speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _targetTransfrom.Translate(new Vector3(0f, _speed, 0));
    }
}
