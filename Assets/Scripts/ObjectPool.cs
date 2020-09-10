using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{
    public int amountToPool;
    public GameObject objectToPool;
}
public class ObjectPool : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    public List<ObjectPoolItem> itemsToPool;
    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        foreach(ObjectPoolItem item in itemsToPool)
        {
            for(int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    
    public GameObject GetPooledObject(string tag) 
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if(pooledObjects[i].activeInHierarchy == false && pooledObjects[i].tag == tag)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
