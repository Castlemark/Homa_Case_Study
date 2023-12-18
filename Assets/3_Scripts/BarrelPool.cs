using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelPool
{
    static BarrelPool m_instance;
    public static BarrelPool Instance
    {
        get {
            if (m_instance == null)
                m_instance = new BarrelPool();
            return m_instance;
        }
    }

    Dictionary<TowerTile, List<TowerTile>> poolDict;
    BarrelPool()
    {
        poolDict = new Dictionary<TowerTile, List<TowerTile>>();
    }

    public void EnsureQuantity(TowerTile prototype, int count)
    {
        if (!poolDict.ContainsKey(prototype)) {
            poolDict.Add(prototype, new List<TowerTile>());
        }
        int prevCount = poolDict[prototype].Count;
        for (int i = 0; i < count - prevCount; i++) {
            TowerTile newObj = Object.Instantiate(prototype);
            newObj.gameObject.SetActive(false);
            Object.DontDestroyOnLoad(newObj);
            poolDict[prototype].Add(newObj);
        }
    }

    public TowerTile GetPooled(TowerTile prototype, Vector3 position, Quaternion rotation, Transform parent = null)
    {
        if (!poolDict.ContainsKey(prototype)) {
            poolDict.Add(prototype, new List<TowerTile>());
        }
        TowerTile unused = poolDict[prototype].Find(x => !x.gameObject.activeSelf);
        if (!unused) {
            unused = Object.Instantiate(prototype, position, rotation, parent);
            poolDict[prototype].Add(unused);
            Object.DontDestroyOnLoad(unused);
        } else {
            unused.transform.position = position;
            unused.transform.rotation = rotation;
            if (unused.transform.parent != parent)
                unused.transform.parent = parent;
            unused.gameObject.SetActive(true);
        }
        return unused;
    }

    public void ReturnToPool(TowerTile tileToReturn)
    {
        tileToReturn.gameObject.SetActive(false);
        tileToReturn.transform.SetParent(null);
        tileToReturn.transform.position = Vector3.zero;
        tileToReturn.transform.rotation = Quaternion.identity;
    }
}
