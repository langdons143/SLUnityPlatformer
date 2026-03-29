using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private GameObject prefab;
    private List<GameObject> availableObjects;

    public ObjectPool(GameObject prefab, int initialSize)
    {
        this.prefab = prefab;
        availableObjects = new List<GameObject>();

        // Create initial pool
        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = GameObject.Instantiate(prefab);
            obj.SetActive(false);
            availableObjects.Add(obj);
        }
    }

    public GameObject Get()
    {
        foreach (GameObject obj in availableObjects)
        {
            if (!obj.activeInHierarchy)
            {
                Debug.Log("Reusing coin from pool");

                obj.SetActive(true);

                Collider2D col = obj.GetComponent<Collider2D>();
                if (col != null)
                {
                    col.enabled = true;
                }

                return obj;
            }
        }

        Debug.Log("Pool empty - instantiating new coin");
        GameObject newObj = GameObject.Instantiate(prefab);
        newObj.SetActive(true);

        Collider2D newCol = newObj.GetComponent<Collider2D>();
        if (newCol != null)
        {
            newCol.enabled = true;
        }

        availableObjects.Add(newObj);
        return newObj;
    }

    public void Return(GameObject obj)
    {
        obj.SetActive(false);
    }
}