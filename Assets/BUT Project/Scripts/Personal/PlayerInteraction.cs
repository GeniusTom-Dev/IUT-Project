using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BUT;
using UnityEngine.SceneManagement;
using UnityEditor.SearchService;

public class PlayerInteraction : MonoBehaviour
{

    [Header("Annimation")]
    [SerializeField]
    Animator playerAnnimator;

    Animator chestAnnimator;


    [Header("Object")]
    [SerializeField]
    GameObject sword;
    [SerializeField]
    GameObject key;
    [SerializeField]
    GameObject startTeleporteur;
    [SerializeField]
    GameObject endTeleporteur;
    [SerializeField]
    GameObject trophy;
    [SerializeField]
    GameObject chest;



    GameObject player;
    GameObject[] enemies;

    Entity playerEntity;

    [Header("Parameters")]
    public float attackRange = 1.5f;
    public float attackCooldown = 4f;
    public int pieceCount = 0;

    [Header("Parameters")]
    [SerializeField]
    public TextMeshProUGUI coinText;

    private bool canAttackDueDelay = true;
    private bool canMoveTrophy = false;
    private bool teleporterLock = true;
    private Vector3 trophyTargetPosition;

    private MenuManager menuManager;
    private SoundManager soundManager;


    void Awake()
    {
        player = GameObject.Find("Player");
        playerEntity = GetComponent<Entity>();

        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        chestAnnimator = chest?.GetComponent<Animator>();

        menuManager = GameObject.Find("Map").GetComponent<MenuManager>();


        soundManager = player.GetComponent<SoundManager>();

    }

    void Update()
    {
        if (canMoveTrophy)
        {
            canMoveTrophy = MoveTrophy();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (SceneManager.GetSceneByName("PauseMenu").isLoaded == false)
            {
                menuManager.LoadSceneAdditively("PauseMenu");
            }
            else
            {
                menuManager.UnloadScene("PauseMenu");
            }

        }
    }

    public void Teleport()
    {

        if(GameObject.Find("StartTeleporteur") == null) return;

        if(teleporterLock && pieceCount >= 3)
        {
            teleporterLock = false;
        }

        if (teleporterLock) return;


        float distanceBossTeleporter = Vector3.Distance(startTeleporteur.transform.position, player.transform.position);
        float distanceWinTeleporter = Vector3.Distance(endTeleporteur.transform.position, player.transform.position);
        
        if (distanceBossTeleporter < 1)
        {
            player.transform.position = endTeleporteur.transform.position;
            soundManager.PlayOneTime("teleport");
        }
        else if(distanceWinTeleporter < 1)
        {
            player.transform.position = startTeleporteur.transform.position;
            soundManager.PlayOneTime("teleport");

        }
    }
    public void OpenChest()
    {
        if (chestAnnimator?.GetBool("isOpen") == true) return;

        float distance = Vector3.Distance(chest.transform.position, player.transform.position);
        if (distance < 2)
        {
            GameObject swordInterface = GameObject.Find("itemSlot2");

            if (swordInterface.transform.Find("Selected")?.gameObject.activeSelf == true)
            {
                chestAnnimator?.SetBool("isOpen", true);
                trophyTargetPosition = new Vector3(trophy.transform.position.x, trophy.transform.position.y + 1, trophy.transform.position.z + 1);
                StartCoroutine(AnimateTrophyAfterAnnim(3));
            }
        }
    }

    public void SwitchSwordState()
    {
        GameObject swordInterface = GameObject.Find("itemSlot1");

        if(swordInterface?.transform.Find("Image")?.gameObject.activeSelf == true)
        {
            playerAnnimator.Play("Withdrawing Sword");
            soundManager.PlayOneTime("SwordState");
            sword.SetActive(!sword.activeSelf);

            if (key.activeSelf)
            {
                key.SetActive(false);
                GameObject keyInterface = GameObject.Find("itemSlot2");
                GameObject selectedChildKey = keyInterface.transform.Find("Selected")?.gameObject;
                selectedChildKey?.SetActive(false);
            }

            GameObject selectedChild = swordInterface.transform.Find("Selected")?.gameObject;
            selectedChild?.SetActive(sword.activeSelf);
        }
        
    }

    public void SwitchKeyState()
    {
        GameObject keyInterface = GameObject.Find("itemSlot2");

        if(keyInterface?.transform.Find("Image")?.gameObject.activeSelf == true)
        {
            playerAnnimator.Play("Withdrawing Sword");
            key.SetActive(!key.activeSelf);

            if (sword.activeSelf)
            {
                sword.SetActive(false);
                GameObject swordInterface = GameObject.Find("itemSlot1");
                GameObject selectedChildSword = swordInterface.transform.Find("Selected")?.gameObject;
                selectedChildSword?.SetActive(false);
            }

            GameObject selectedChild = keyInterface.transform.Find("Selected")?.gameObject;
            selectedChild?.SetActive(key.activeSelf);
        }
        
    }

    public void Attack()
    {
        if (sword.activeSelf == false || canAttackDueDelay == false) return;

        Vector3 playerPos = player.transform.position;

        canAttackDueDelay = false;
        playerAnnimator.Play("Standing Melee Attack Horizontal");
        StartCoroutine(PlayerSoundAttackDelay(.8f));

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, playerPos);

            Entity enemyEntity = enemy.GetComponent<Entity>();

            if (enemyEntity != null && distance < attackRange)
            {
                enemyEntity.Attacked(playerEntity);
            }
        }

        StartCoroutine(ResetAllowAttackDelay());
    }

    private IEnumerator ResetAllowAttackDelay()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttackDueDelay = true;
    }

    private IEnumerator AnimateTrophyAfterAnnim(float animationDuration)
    {
        yield return new WaitForSeconds(animationDuration);
        canMoveTrophy = true;
    }

    private IEnumerator PlayerSoundAttackDelay(float delayDuration)
    {
        yield return new WaitForSeconds(delayDuration);
        soundManager.PlayOneTime("SwordSlash");
    }

    private bool MoveTrophy()
    {

        if (trophy == null) return false;

        Vector3 direction = (trophyTargetPosition - trophy.transform.position).normalized;

        trophy.transform.position += direction * Time.deltaTime;

        if(trophy.transform.position == trophyTargetPosition)
        {
            return false;
        }
        
        return true;
    }

    public void AddPiece()
    {
        pieceCount++;
        coinText.text = pieceCount.ToString();
    }
}
