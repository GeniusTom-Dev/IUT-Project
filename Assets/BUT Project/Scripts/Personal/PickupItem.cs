using BUT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public float speedRotation = 150;
    public bool canRotate = true;

    private SoundManager soundManager;

    void Start()
    {
        soundManager = GameObject.Find("Player").GetComponent<SoundManager>();
    }

    void Update()
    {
        if (canRotate)
        {
            transform.Rotate(0, speedRotation * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Invoke("DestroyObj", 0);
        }
    }

    private void DestroyObj()
    {
        string tag = this.tag.ToLower();
        OnPickItemAction(tag);
        if(tag != "trophee")
        {
            Destroy(this.gameObject);
        }
        
    }

    private void OnPickItemAction(string itemTag)

    {
        Debug.Log(itemTag);
        if (string.IsNullOrEmpty(itemTag)) return; 

        GameObject selectedChild = null;
        string scene = "";

        switch (itemTag)
        {
            case "sword":
                selectedChild = GameObject.Find("itemSlot1")?.transform.Find("Image")?.gameObject;
                break;
            case "key":
                selectedChild = GameObject.Find("itemSlot2")?.transform.Find("Image")?.gameObject;
                break;
            case "coin":
                GameObject.Find("Player").GetComponent<PlayerInteraction>().AddPiece();
                soundManager.PlayOneTime("coin");
                break;
            case "trophee":
                soundManager.PlayOneTime("win");
                scene = "MenuWin";
                break;

        }

        if (selectedChild != null)
        {
            selectedChild.SetActive(true);
        }

        if (string.IsNullOrEmpty(scene) == false){
            StartCoroutine(ChangeSceneAfterDelay(5f, scene));
        }
    }

    private IEnumerator ChangeSceneAfterDelay(float delayDuration, string scene)
    {
        yield return new WaitForSeconds(delayDuration);
        MenuManager menuManager = GameObject.Find("Player").AddComponent<MenuManager>();
        menuManager.ChangeScene("WinMenu");
    }

    



}
