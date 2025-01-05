using BUT;
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

    public GameObject item;
    private bool asAlreadyDropItem = false;
    public GameObject teleporter;
    private bool asAlreadyActiveTeleporter = false;

    public void Attacked(Entity opponent)
    {
        if (opponent == null) return;

        health -= opponent.damage;

        if(health < 0 ) health = 0;

        if (this.name == "Player")
        {
            GameObject.Find("healthBar").GetComponent<HealthBar>().SetHealth(health);
        }

        if (health == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        m_Animator.Play("Falling Back Death");
        SoundManager soundManager = GameObject.Find("Player").GetComponent<SoundManager>();
        soundManager.PlayOneTime("death");


        DropItem();
        ActiveTeleporter();

        if (this.name == "Player")
        {
            AnimatorStateInfo stateInfo = m_Animator.GetCurrentAnimatorStateInfo(0);
            StartCoroutine(ChangeSceneAfterDeath(2));
        }

    }

    private IEnumerator ChangeSceneAfterDeath(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        GameObject player = GameObject.Find("Player");
        MenuManager menuManager = player.AddComponent<MenuManager>();
        menuManager.ChangeScene("DeathMenu");
    }

    private void DropItem()
    {
        if (isDead == false || asAlreadyDropItem == true || item == null) return;

        GameObject droppedItem = Instantiate(
            item,
            new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z),
            Quaternion.identity);
        droppedItem.name = item.name;
        droppedItem.tag = item.tag;
        
        asAlreadyDropItem = true;
    }

    private void ActiveTeleporter()
    {
        if (isDead == false || asAlreadyActiveTeleporter == true || teleporter == null) return;

        if(teleporter.activeSelf == false)
        {
            teleporter.SetActive(true);
        }
    }
}
