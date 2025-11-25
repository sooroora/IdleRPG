using System.Collections.Generic;
using UnityEngine;

public class SimplePool : MonoBehaviour
{
    // active 된애랑 안 된 애 분리해놓으면 좋음
    List<GameObject> pool;
    
    
    [SerializeField] private GameObject prefab;
    [SerializeField] private int defaultPoolSize = 50;

    void Awake()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < defaultPoolSize; i++)
        {
            GameObject newObject = CreateGameObject();
            newObject.transform.SetParent(this.gameObject.transform,true);
            newObject.SetActive(false);
        }
    }


    private GameObject CreateGameObject()
    {
        GameObject newGameObject = Instantiate(prefab);
        pool.Add(newGameObject);
        return newGameObject;
    }

    private GameObject GetGameObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                return pool[i];
            }
        }
        
        return CreateGameObject();
    }


}