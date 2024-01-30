using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<TComponent> where TComponent : Component
{
    private List<TComponent> pool;
    private TComponent prefab;

    //Создание пула
    public ObjectPool(TComponent prefab, int poolSize)
    {
        this.prefab = prefab;
        pool = new List<TComponent>();

        for (int i = 0; i < poolSize; i++)
        {
            CreateObject();
        }
    }

    public TComponent GetObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].gameObject.activeSelf)
            {
                pool[i].gameObject.SetActive(true);
                return pool[i];
            }
        }

        return CreateObject();
    }

    public void ReturnObject(TComponent obj)
    {
        obj.gameObject.SetActive(false);
    }

    //Создание врагов в пуле
    private TComponent CreateObject()
    {
        TComponent newObj = Object.Instantiate(prefab);
        newObj.gameObject.SetActive(false);
        pool.Add(newObj);
        return newObj;
    }
}
