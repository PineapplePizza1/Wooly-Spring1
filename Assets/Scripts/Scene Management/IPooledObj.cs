using UnityEngine;

public interface IPooledObj 
{
    //For a future version, make this a class with a injected ref to it's parent queue/spawner,
    //So it knows to return on deactivate.
    //for now, spamming more garbo works.
    void OnObjectSpawn();
}
