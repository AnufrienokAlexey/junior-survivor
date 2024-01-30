using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using static UnityEngine.GraphicsBuffer;

public class MelleEnemy : EnemySettings
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private GameObject target;
    private bool isAttack = false;
    
    public IEnumerator StartAttack()
    {
        while (GetDistance() < attackDistance)
        {
            MelleAttack();
            yield return new WaitForSeconds(GetSpeedAttack());
        }
        isAttack = false;
        StopCoroutine(StartAttack());
    }

    private float GetSpeedAttack()
    {
        return (attackSpeed * Time.deltaTime) / 1f;
    }

    private void MelleAttack()
    {
        playerHealth.HealthReduce(damage);
    }

    private float GetDistance()
    {
        Vector3 heading = target.transform.position - this.transform.position;
        float distance = heading.magnitude;
        return distance;
    }

    private void Update()
    {
        if (!isAttack && (GetDistance() < attackDistance))
        {
            Debug.Log("Update()");
            isAttack = true;
            StartCoroutine(StartAttack());
        }

/*        if (GetDistance() > attackDistance)
        {
            isAttack = false;
            StopCoroutine(StartAttack());
        }*/
    }
}
