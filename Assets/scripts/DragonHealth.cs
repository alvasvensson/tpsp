using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragonHealth : MonoBehaviour
{
   [SerializeField]
   Slider healthBar;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

     public void SetInitHealth(int maxHealth)
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    public void UpdateHealth(int currentHealth)
    {
        healthBar.value = currentHealth;
    }

}
