using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableObject : MonoBehaviour
{
    [SerializeField]    
    private PoolObjectType _type;
    public  PoolObjectType Type => _type;

    private IReturnToPool _pool;


    private void OnDisable() 
    {
        _pool?.ReturnToPool(_type, gameObject);
    }


    public PoolableObject SetPool(IReturnToPool pool)
    {
        _pool = pool;
        return this;
    }

    public PoolableObject Disable()
    {
        gameObject.SetActive(false);
        return this;
    }

}
