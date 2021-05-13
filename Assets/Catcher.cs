using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour
{
    public GameObject spawnPoint;
    
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Catcher: Item Caught!");
        other.transform.position = spawnPoint.transform.position;
    }
}
