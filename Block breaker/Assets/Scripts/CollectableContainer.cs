using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableContainer : MonoBehaviour
{
    [SerializeField]
    private Collectable _collectable;

    private void OnDestroy()
    {
        _collectable.Activate();
    }
}
