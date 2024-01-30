using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int startHealth;
    public int currentHealth;

    [SerializeField] private int damage;

    void Start()
    {
        currentHealth = startHealth;
    }

    public void HealthReduce(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth = currentHealth - damage;
            if (currentHealth <= 0)
            {
                Debug.Log("You Dead!");
            }
        }
    }
}
