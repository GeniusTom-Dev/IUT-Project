using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    [Header("Annimation")]
    [SerializeField]
    Animator chestAnnimator;

    GameObject startTeleporteur;
    GameObject endTeleporteur;
    GameObject chest;
    GameObject player;


    void Awake()
    {
        startTeleporteur = GameObject.Find("StartTeleporteur");
        endTeleporteur = GameObject.Find("EndTeleporteur");
        chest = GameObject.Find("Chest");
        player = GameObject.Find("character");

    }

    public void teleport()
    {
        float distance = Vector3.Distance(startTeleporteur.transform.position, player.transform.position);
        if(distance < 0.5)
        {
            player.transform.position = endTeleporteur.transform.position;
        }
    }
    public void openChest()
    {
        if (chestAnnimator?.GetBool("isOpen") == true) return;

        float distance = Vector3.Distance(chest.transform.position, player.transform.position);
        
        if (distance < 2)
        {
            chestAnnimator?.SetBool("isOpen", true);
        }
    }
}
