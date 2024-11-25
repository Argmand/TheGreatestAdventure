using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GhostAI : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float wanderSpeed;
    [SerializeField] private float maxSpeed;
    public float distanceBetween;

    private Vector2 movement;
    public float timeLeft;
    public Rigidbody2D rb;

    public PlayerMovementNew playerLightRef;

    private float distance;

    private void Start()
    {
        
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < distanceBetween && !playerLightRef.playerInLight)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            rb.velocity = Vector3.zero;
        }

        else
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 1)
            {
            movement = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
            }
            if (timeLeft <= 0)
            {
                timeLeft = 2;
                rb.velocity = Vector3.zero;
            }
        }

        if (rb.velocity.magnitude > maxSpeed)
        {
            //rb.velocity = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * wanderSpeed);
    }


}
