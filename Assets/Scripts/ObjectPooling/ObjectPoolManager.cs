using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance;

    public List<OBJPool> _poolList;

    Queue<GameObject> _objectPoolQueue;

    public Dictionary<string, Queue<GameObject>> _objectPoolDictionary;

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }

        _objectPoolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (OBJPool pool in _poolList)
        {
            _objectPoolQueue = new Queue<GameObject>();

            for (int i = 0; i < pool._NumOfObj; i++)
            {
                GameObject obj = Instantiate(pool._ObjPrefab);
                obj.SetActive(false);
                _objectPoolQueue.Enqueue(obj);
            }

            _objectPoolDictionary.Add(pool._PoolTag, _objectPoolQueue);
        }
    }

    private void Start()
    {
        
    }

    public GameObject SetActiveFromPool(string poolTag, Vector3 pos, Quaternion rot)
    {
        if (!_objectPoolDictionary.ContainsKey(poolTag))
        {
            Debug.LogWarning(poolTag + "Pool Doesn't Exist");
            return null;
        }

        GameObject objToActivate = _objectPoolDictionary[poolTag].Dequeue();

        objToActivate.SetActive(true);
        objToActivate.transform.position = pos;
        objToActivate.transform.rotation = rot;

        _objectPoolDictionary[poolTag].Enqueue(objToActivate);

        return objToActivate;
    }
}
