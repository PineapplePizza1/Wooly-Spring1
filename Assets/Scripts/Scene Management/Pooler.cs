using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//LastUpdate: 3/8/21, D-Lynn Z
//Attach to scene obj
public class Pooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        //contains nametag, prefab to fill, and size.
        public string tag;
        public GameObject prefab;
        public int size;

    }

    public struct PoolPair
    {
        public GameObject body;
        public IPooledObj IPool;
    }
    public List<Pool> LoadPools;
    public Dictionary<string, Queue<GameObject>> poolDict;

    public bool loaded {private set; get;}

    // Start is called before the first frame update
    private void Awake() 
    {   
        loaded = false;

        poolDict = new Dictionary<string, Queue<GameObject>>();

        //load Pools
        foreach(Pool pool in LoadPools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i< pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                obj.transform.SetParent(this.transform, true);
                objectPool.Enqueue(obj);
            }

            poolDict.Add(pool.tag, objectPool);
        }

        loaded = true;
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDict.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }

        GameObject objToSpawn =poolDict[tag].Dequeue();

        objToSpawn.SetActive(true);
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;

        IPooledObj IPool = objToSpawn.GetComponent<IPooledObj>();

        if (IPool!=null)
        {
            IPool.OnObjectSpawn();
        }

        poolDict[tag].Enqueue(objToSpawn);

        return objToSpawn;

    }

    

}