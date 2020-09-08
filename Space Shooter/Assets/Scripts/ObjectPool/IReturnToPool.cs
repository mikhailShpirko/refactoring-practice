using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReturnToPool
{
    void ReturnToPool(PoolObjectType type,
                    GameObject gameObject);
}
