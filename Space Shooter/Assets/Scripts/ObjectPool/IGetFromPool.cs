using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGetFromPool
{
    T GetFromPool<T>(PoolObjectType type, 
                    Vector3 position,
                    Vector3 rotation) where T : class;
}
