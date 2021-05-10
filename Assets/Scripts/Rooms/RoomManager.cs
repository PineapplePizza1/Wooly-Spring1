using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
   //Scene INjector
   [SerializeField] private SceneInjector sceneject;

   public List<BaseEnemy> enemies;


   //main thing, to pass in injections. Otherwise, track # of enemies in area, and rewards.

   //box collider

    //rewards

    public void AttachSceneject(SceneInjector _sceneject)
    {
        sceneject = _sceneject;
    }

    //attach to enemies. get list of enemies?

    public void InjectEnemies()
    {
        foreach(BaseEnemy _enem in enemies)
        {
            _enem.AddInject(sceneject);
            //_enem.gameObject.SetActive(true);

            //remember to replace inject with requests.
        }
    }
}
