using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;
    public GameObject objectToPool;
    public int amountToPool;
    public List<GameObject> PooledObject;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PooledObject = new List<GameObject>();
        GameObject temp;
        for(int i=0; i< amountToPool; i++)
        {
            temp = Instantiate(objectToPool);
            temp.SetActive(false);
            PooledObject.Add(temp);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i=0; i<amountToPool; i++)
        {
            if (!PooledObject[i].activeInHierarchy)
            {
                return PooledObject[i];
            }
        }
        return null;
    }


}
