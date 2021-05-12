using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
   //Scene INjector
   [SerializeField] private SceneInjector sceneject;
   public ChallengeNeedle needle;
   public List<EnemySpawner> eneSpawns;

   //Bounding Collider
   public BoxCollider roomBox;

   private int EnemyCount;

    private void Awake() {
        EnemyCount = 999999; //Debug: prevents needle from activating prematurely.

        roomBox = GetComponent<BoxCollider>();
    }

   //main thing, to pass in injections. Otherwise, track # of enemies in area, and rewards.

   //box collider

    //rewards

    public void StartRoom(SceneInjector _in)
    {
        AttachSceneject(_in);
        InjectEnemies();
    }

    private void AttachSceneject(SceneInjector _sceneject)
    {
        sceneject = _sceneject;
    }

    //attach to enemies. get list of enemies?

    private void InjectEnemies()
    {
        Debug.Log("RoomM: I injected!");

        int tempCount = 0;

        foreach(EnemySpawner _enem in eneSpawns)
        {
            _enem.PrepEnemy(sceneject,this);
            //_enem.gameObject.SetActive(true);
            tempCount +=1;
            //remember to replace inject with requests.
        }
        EnemyCount = tempCount;

    }
    
    public void EnemyDefeat()
    {
        EnemyCount -=1;
        if(EnemyCount <= 0 )
        {
            Debug.Log("RoomM: I needled");
            needle.CompleteNeedle();
        }
    }
}