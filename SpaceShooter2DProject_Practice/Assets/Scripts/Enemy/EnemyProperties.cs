using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    [SerializeField] int enemyHealth = 3;
    [SerializeField] int givenEXP = 1;

    [SerializeField] Animator animator;
    [SerializeField] GameObject enemyDestroyVFX;

    int defaultEnemyHealth = 3;
    // Start is called before the first frame update
    void Start()
    {
        defaultEnemyHealth = enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Update_EnemyHealth(int amount)
    {
        enemyHealth += amount;

        if(enemyHealth > defaultEnemyHealth)
        {
            enemyHealth = defaultEnemyHealth;
        }

        if(enemyHealth <= 0)
        {
            GameObject destroyVFX = Instantiate(enemyDestroyVFX, transform.position, Quaternion.identity);
            
            Destroy(gameObject);
        }
        else
        {
            if(amount < 0)
            {
                if(animator != null)
                {
                    animator.SetTrigger("IsHit");
                }
            }
        }
    }
}
