using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour, IObjectPool
{
    [SerializeField]
    private ObjectPoolItem[] _poolObjectsSetting;

    private Dictionary<PoolObjectType, List<GameObject>> _pool;

    private void Awake()
    {
        FillPool();
    }

    private void FillPool()
    {
        _pool = new Dictionary<PoolObjectType, List<GameObject>>();

        foreach(var poolObjectSetting in _poolObjectsSetting)
        {
            
            if(!_pool.ContainsKey(poolObjectSetting.Type))
            {
                _pool.Add(poolObjectSetting.Type, new List<GameObject>());
            }

            for(var i = 0; i < poolObjectSetting.NumberOfInstancesInPool; i++)
            {
                InstantiatePoolableObject(poolObjectSetting.Prefab);
            }

        }
    }

    private PoolableObject InstantiatePoolableObject(PoolableObject prefab)
    {
        return Instantiate(prefab).SetPool(this).Disable();
    }

    public T GetFromPool<T>(PoolObjectType type, Vector3 position, Vector3 rotation) where T : class
    {
        if(!_pool.ContainsKey(type))
        {
            return null;
        }

        GameObject gameObject;
        if(_pool[type].Count == 0)
        {
            var poolObjectSetting = _poolObjectsSetting.FirstOrDefault(p=> p.Type == type);
            gameObject = InstantiatePoolableObject(poolObjectSetting.Prefab).gameObject;
        }
        else
        {
            gameObject = _pool[type][0];
            _pool[type].RemoveAt(0);
        }
        gameObject.SetActive(true);
        gameObject.transform.position = position;
        gameObject.transform.parent = null;
        gameObject.transform.rotation = Quaternion.Euler(rotation);
        return gameObject.GetComponent<T>();
    }

    public void ReturnToPool(PoolObjectType type, GameObject gameObject)
    {
        if(!_pool.ContainsKey(type))
        {
            return;
        }
        _pool[type].Add(gameObject);
    }
  
}
