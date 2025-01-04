using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarFill;
    [Range(0, 100)] public float health = 100f;

    public void SetHealth(float value)
    {
        health = Mathf.Clamp(value, 0, 100);  
        healthBarFill.fillAmount = health / 100f;
    }
}
