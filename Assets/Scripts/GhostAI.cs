using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GhostAI : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private float distance;

    private void OnTriggerStay2D(Collider2D collision)
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Stop Ghost from moving towards player for a small amount of time

    }
}
