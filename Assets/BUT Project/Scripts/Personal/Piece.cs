using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public AudioSource audioSource;
    public float speedRotation;

    void Update()
    {
        transform.Rotate(0, speedRotation * Time.deltaTime, 0);
        transform.Translate(Vector3.up * 1 * Time.deltaTime);
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
        Destroy(this.gameObject);
    }


}
