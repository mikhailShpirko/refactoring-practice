using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitDestroyable : MonoBehaviour
{
    [SerializeField]
    private int _allowedNumberOfHits;
    private int _numberOfHits;
    private bool _shouldDestroy => _numberOfHits >= _allowedNumberOfHits;

    private void OnCollisionEnter2D(Collision2D col)
    {
        _numberOfHits++;
        if(_shouldDestroy)
        {
            Destroy(gameObject);
        }
    }

}
