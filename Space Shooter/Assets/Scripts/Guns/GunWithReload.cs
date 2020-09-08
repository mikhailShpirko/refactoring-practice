using System.Collections;
using System;
using UnityEngine;

public class GunWithReload : Gun
{
    [SerializeField]
    private int _reloadTimeSeconds;
    private bool _isReloading;

    private IEnumerator Reload()
    {
        _isReloading = true;
        yield return new WaitForSeconds(_reloadTimeSeconds);
        _isReloading = false;
    }

    public override void Shoot()
    {
        if(_isReloading)
        {
            return;
        } 

        base.Shoot();
        StartCoroutine(Reload());          
    }
}
