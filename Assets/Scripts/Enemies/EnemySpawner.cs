using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject Gfx;


    //in the future, take twists.
    public GameObject SpawnEnemy(SceneInjector inject, RoomManager _in)
    {
        Gfx.SetActive(false);
        
        GameObject nuMeat = Instantiate(EnemyPrefab, this.transform.position, this.transform.rotation);
        BaseEnemy EnScript = nuMeat.GetComponent<BaseEnemy>();

        EnScript.AddInject(inject);
        EnScript.AttachManager(_in);
        //Debug.Log("EnemSpawn: Spawnered: " + nuMeat.name);

        nuMeat.transform.SetParent(_in.gameObject.transform);

        return nuMeat;
    }
}
