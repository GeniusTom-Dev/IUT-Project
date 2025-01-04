using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    [Header("Animator")]
    [SerializeField]
    Animator m_Animator;

    public int health = 100;
    public int damage = 10;
    public bool isDead = false;

    public void attacked(Entity opponent)
    {
        if (opponent == null) return;

        health -= opponent.damage;

        if(health < 0 ) health = 0;

        if (this.name == "Player")
        {
            GameObject.Find("healthBar").GetComponent<HealthBar>().SetHealth(health);
        }

            Debug.Log(gameObject.name + " : vie restante: " + health + " pv");

        if (health == 0)
        {
            die();
        }
    }

    public void die()
    {
        isDead = true;
        m_Animator.Play("Falling Back Death");

        if(this.name == "Player")
        {
            AnimatorStateInfo stateInfo = m_Animator.GetCurrentAnimatorStateInfo(0);
            StartCoroutine(ChangeSceneAfterDeath(stateInfo.length));
        }


    }

    private IEnumerator ChangeSceneAfterDeath(float attackCooldown)
    {
        yield return new WaitForSeconds(attackCooldown);
        MenuManager menuManager = new MenuManager();
        menuManager.ChangeScene("deathMenu");
    }
}
