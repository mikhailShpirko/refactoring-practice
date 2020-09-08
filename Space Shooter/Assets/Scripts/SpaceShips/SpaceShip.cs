using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip: MonoBehaviour, IDestroyable
{
    [SerializeField]
    private Animator _animator;

    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }

    public void Destroy()
    {
        _animator.SetBool("IsDestroyed", true);
        StartCoroutine(Disable());
    }
    
}
