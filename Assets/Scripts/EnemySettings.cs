using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Settings")]
public class EnemySettings : MonoBehaviour
{
    public float movementSpeed;
    public float attackDistance;
    public float currentEnemyHealth;
    public float attackSpeed;
    public int damage;

    private float maxEnemyHealth;


}
