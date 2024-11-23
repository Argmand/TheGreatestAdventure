using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public GameObject attackArea = default;

    public bool attacking = false;

    public float timeToAttack = 0.25f;
    public float timer = 0.0f;


    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0.0f;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }

    }
    void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }
}
