using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    [Header("Annimation")]
    [SerializeField]
    Animator chestAnnimator;
    [SerializeField]
    Animator playerAnnimator;


    [Header("Object")]
    [SerializeField]
    GameObject sword;

    GameObject startTeleporteur;
    GameObject endTeleporteur;
    GameObject chest;
    GameObject player;
    GameObject[] enemies;

    Entity playerEntity;

    public float attackRange = 1.5f;
    public float attackCooldown = 4f;
    private bool canAttackDueDelay = true;


    void Awake()
    {
        startTeleporteur = GameObject.Find("StartTeleporteur");
        endTeleporteur = GameObject.Find("EndTeleporteur");
        chest = GameObject.Find("Chest");
        player = GameObject.Find("Player");
        playerEntity = GetComponent<Entity>();

        enemies = GameObject.FindGameObjectsWithTag("Enemy");

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

    public void switchSwordState()
    {
        playerAnnimator.Play("Withdrawing Sword");
        sword.SetActive(!sword.activeSelf);

        GameObject selectedChild = GameObject.Find("itemSlot1").transform.Find("Selected")?.gameObject;
        selectedChild?.SetActive(sword.activeSelf);
    }

    public void attack()
    {
        if (sword.activeSelf == false || canAttackDueDelay == false) return;

        Vector3 playerPos = player.transform.position;

        canAttackDueDelay = false;
        playerAnnimator.Play("Standing Melee Attack Horizontal");

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, playerPos);

            Entity enemyEntity = enemy.GetComponent<Entity>();

            if (enemyEntity != null && distance < attackRange)
            {
                enemyEntity.attacked(playerEntity);
            }
        }

        StartCoroutine(resetAllowAttackDelay());
    }

    private IEnumerator resetAllowAttackDelay()
    {
        yield return new WaitForSeconds(attackCooldown);
        Debug.Log("Auth reset");
        canAttackDueDelay = true;
    }
}
