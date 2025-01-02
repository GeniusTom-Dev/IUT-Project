using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    GameObject startTeleporteur;
    GameObject endTeleporteur;
    GameObject player;

    void Awake()
    {
        startTeleporteur = GameObject.Find("StartTeleporteur");
        endTeleporteur = GameObject.Find("EndTeleporteur");
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
}
