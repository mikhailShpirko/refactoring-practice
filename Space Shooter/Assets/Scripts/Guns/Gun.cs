using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IGun
{
    [SerializeField]
    private Transform _bulletSpawn;

    [SerializeField]
    private BulletType _bulletType;

    private IGetFromPool _pool;

    private void Awake() 
    {
        _pool = GameObject.FindObjectOfType<ObjectPool>();
    }

    public virtual void Shoot()
    {
        _pool.GetFromPool<Bullet>((PoolObjectType)_bulletType, _bulletSpawn.position, _bulletSpawn.rotation.eulerAngles);
    }
}
