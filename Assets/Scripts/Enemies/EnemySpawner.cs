using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;


    //in the future, take twists.
    public GameObject PrepEnemy(SceneInjector inject, RoomManager _in)
    {
        GameObject nuMeat = Instantiate(EnemyPrefab, this.transform.position, this.transform.rotation);
        BaseEnemy EnScript = nuMeat.GetComponent<BaseEnemy>();

        EnScript.AddInject(inject);
        EnScript.AttachManager(_in);

        
        nuMeat.transform.SetParent(_in.gameObject.transform);

        return nuMeat;
    }
}
