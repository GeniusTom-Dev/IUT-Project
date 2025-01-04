using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField]
    GameObject inBossWall;

    private void OnTriggerEnter(Collider other)
    {
        if (inBossWall != null && inBossWall.activeSelf == false && other.tag == "Player")
        {
            inBossWall.SetActive(true);
        }
    }
}
