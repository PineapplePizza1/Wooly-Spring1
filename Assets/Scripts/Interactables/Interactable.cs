using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    /*private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);    
    }
    */

    public void PlayerInteract()
    {
        //Default interact
    }

    private void OnTriggerEnter(Collider other) {
        string Taggy = other.tag;
        switch (Taggy)
        {
            case "Player":
                Player pscript = other.GetComponent<Player>();
                if (pscript!=null)
                {
                    pscript.NearInteract(this); Debug.Log("Inter: I hit Player!");
                }
                else Debug.Log("Interactable: Couldn't get Player Script");
                break;

        }      
    }

    private void OnTriggerExit(Collider other) {
        string Taggy = other.tag;
        switch (Taggy)
        {
            case "Player":
                Player pscript = other.GetComponent<Player>(); Debug.Log("Inter: I left Player!");
                if (pscript!=null)
                {
                    pscript.LeaveInteract(this);
                }
                else Debug.Log("Interactable: Couldn't get Player Script");
                break;

        }      
    }
}
