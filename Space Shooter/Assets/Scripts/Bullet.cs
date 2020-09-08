using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        var destroyable = other.gameObject.GetComponent<IDestroyable>();
        if(destroyable != null)
        {
            destroyable.Destroy();
        }
        gameObject.SetActive(false);
    }
}
