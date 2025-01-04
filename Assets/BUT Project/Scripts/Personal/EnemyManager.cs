using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieManager : MonoBehaviour
{
    GameObject player;
    Entity playerEntity;
    Entity actualEntity;


    [Header("Annimation")]
    [SerializeField]
    Animator EnemyAnnimator;
    [Header("Parameters")]
    public float detectionRange = 10f;
    public float attackRange = 1.5f;
    public float attackCooldown = 4f;
    public float attackDelay = 1.5f;
    public float moveSpeed = 2.5f;

    private float nextAttackTime = 0f;

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerEntity = player.GetComponent<Entity>();
        actualEntity = GetComponent<Entity>();
    }

    void Update()
    {
        if(player == null || actualEntity.isDead) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < detectionRange)
        {
            
            if (distance > attackRange)
            {
                EnemyAnnimator?.SetBool("isMoving", true);
                MoveToPlayer();
            }
            else
            {
                EnemyAnnimator?.SetBool("isMoving", false);
                if (Time.time >= nextAttackTime)
                {
                    nextAttackTime = Time.time + attackCooldown;
                    StartCoroutine(DelayedAttack());
                }
            }
        }
        else
        {
            EnemyAnnimator?.SetBool("isMoving", false);
        }

    }

    public void MoveToPlayer()
    {

        // On fait en sorte de garder le Y de l'ennemie pour ne pas qu'il vole
        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        Vector3 direction = (targetPosition - transform.position).normalized;

        transform.position += direction * moveSpeed * Time.deltaTime;

        transform.LookAt(targetPosition);
    }


    private IEnumerator DelayedAttack()
    {
        if (playerEntity != null)
        {
            EnemyAnnimator.Play("Zombie Attack");

            AnimatorStateInfo stateInfo = EnemyAnnimator.GetCurrentAnimatorStateInfo(0);
            yield return new WaitForSeconds(stateInfo.length / 2);

            playerEntity.attacked(actualEntity);
        }
    }
}