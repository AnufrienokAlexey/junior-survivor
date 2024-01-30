using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemySettings EnemySettings;
    private Transform Player;

    public void Initialize(EnemySettings settings, Transform player)
    {
        EnemySettings = settings;
        Player = player;
    }

    void Update()
    {
        if (Player != null)
        {
            Movement();
        }
    }

    private void Movement()
    {
        transform.LookAt(Player);

        if (!PlayerIsClose())
        {
            transform.Translate(0f, 0f, EnemySettings.movementSpeed * Time.deltaTime);
        }
    }

    private bool PlayerIsClose()
    {
        float distance = Vector3.Distance(transform.position, Player.position);

        return distance <= EnemySettings.attackDistance;
    }
}
