using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    private Transform _transform; //performance optimization if assigned in inspector

    public Vector3 Position => _transform.position;
}
