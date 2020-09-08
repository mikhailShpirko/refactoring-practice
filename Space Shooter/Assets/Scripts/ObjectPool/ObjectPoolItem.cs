using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectPoolItem
{
    public int NumberOfInstancesInPool;
    public PoolableObject Prefab;
    public PoolObjectType Type => Prefab.Type;
}
