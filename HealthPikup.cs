using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPikup : MonoBehaviour
{
    PlayerHealth playerHealth;

    public float healthBonus = 15f;
    void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
    }
}
