using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//LastUpdate: 3/8/21, D-Lynn Z
//A temporary Spawner, before doing proper procgen
//Spawns randomly, reuse for spawn methods


public class Spawner : MonoBehaviour
{
    public Pooler SpawnPools;

    //public SceneManagement sceneManagement;

    float minx, maxx, minz, maxz, centY;

    public GameObject keys;
    public List<GameObject> WepPickups;

    public List<spawnpair> spawntypes;
    [System.Serializable]
    public struct spawnpair{
        public string name;
        public int count;
    }
    public bool spawngarbo;

    

    void Start() 
    {
        Bounds tb = GetComponent<Collider>().bounds;
        Vector3 max = tb.max;
        Vector3 min = tb.min;
        minx = min.x;
        maxx = max.x;
        minz = min.z;
        maxz = max.z;
        centY = tb.center.y;


        
        
    }
    public void beginSpawn()
    {
        spawngarbo=false;
        GameObject ret = spawnValuable(keys);
        //ret.GetComponent<Keys>().setManager(sceneManagement);
        foreach(GameObject spawny in WepPickups)
        {
            spawnValuable(spawny);
        }

        StartCoroutine(WaitToGarbo());
    }

    public void respawn(GameObject insty)
    {
        Debug.Log("Respawned: " + insty.name);
        float randx = Random.Range(minx, maxx);
        float randz = Random.Range(minz, maxz);
        Vector3 randPos = new Vector3(randx, centY, randz);
        insty.transform.position = randPos;
        insty.transform.rotation = Quaternion.identity;
    }

    IEnumerator WaitToGarbo()
    {
        if (spawngarbo)
        {
            spawngarbo= true;
            yield return new WaitForSeconds(2);
            
        }

        foreach(spawnpair spair in spawntypes)
        {
            StartCoroutine(StartSpawnGarbo(spair.name, spair.count));
        }

    }

    IEnumerator StartSpawnGarbo(string garby, int count)
    {

        Debug.Log("Spawn running");
        if(!SpawnPools.loaded)
            yield return new WaitForSeconds(4);


        
        for(int i = 0; i< count; i++)
        {
            float randx = Random.Range(minx, maxx);
            float randz = Random.Range(minz, maxz);
            Vector3 randPos = new Vector3(randx, centY, randz);
            SpawnPools.SpawnFromPool(garby, randPos, Quaternion.identity);
        }

        yield break;
    }
    
    GameObject spawnValuable(GameObject insty)
    {
        float randx = Random.Range(minx, maxx);
        float randz = Random.Range(minz, maxz);
        Vector3 randPos = new Vector3(randx, centY, randz);
        GameObject ret = Instantiate(insty, randPos, Quaternion.identity);
        return ret;
    }
    
}
