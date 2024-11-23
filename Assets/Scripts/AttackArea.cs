using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 3;
    PlayerAttack playerAttack;

    private void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (playerAttack.attacking = true && collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
    }

}
