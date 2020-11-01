using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCollector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.TryGetComponent<Collectable>(out var collectable))
        {
            Destroy(collectable.gameObject);
        }
    }
}
