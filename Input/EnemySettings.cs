using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Settings")]
public class EnemySettings : ScriptableObject
{
    public float movementSpeed;
    public float attackDistance;
    public float currentEnemyHealth;
    public float attackSpeed;
    public float damage;

    private float maxEnemyHealth;


}
