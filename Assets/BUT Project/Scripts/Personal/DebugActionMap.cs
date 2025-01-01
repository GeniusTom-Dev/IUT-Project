using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DebugActionMap : MonoBehaviour
{
    Coroutine mouvingCoroutine;

    public void Move(InputAction.CallbackContext context)
    {
        Debug.Log("Init");
        if (mouvingCoroutine == null)
        {
            mouvingCoroutine = StartCoroutine(Moving(context));

        }
    }

    IEnumerator Moving(InputAction.CallbackContext context)
    {
        while (context.started)
        {
            Vector2 value = context.ReadValue<Vector2>();
            Debug.Log("coucou" + value);
            yield return null;
        }
        mouvingCoroutine = null;
    }
}