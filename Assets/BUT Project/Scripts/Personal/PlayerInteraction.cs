using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    GameObject startTeleporteur ;
    GameObject player;

    void Awake()
    {
        startTeleporteur = GameObject.Find("StartTeleporteur");
        player = GameObject.Find("character");

    }

    public void teleport()
    {
        float distance = Vector3.Distance(startTeleporteur.transform.position, player.transform.position);
        Debug.Log(distance);
    }
}
