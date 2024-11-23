using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GhostAINew : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distanceBetween;
    public PlayerMovementNew playerLightRef;
    private float distance;

    private Vector2 targetDirection;
    public Rigidbody2D rb;
    public float wanderSpeed = 3.0f;
    float timer = 0.0f;
    public float wanderTime = 1.0f;

    private void Start()
    {

    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < distanceBetween && !playerLightRef.playerInLight)
        {
            //rb.MovePosition( Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime)); //spöket föjer spelaren
            Vector2 moveDirection = player.transform.position - this.transform.position;
                moveDirection.Normalize();
                rb.velocity = moveDirection * speed;
        }
        
        else
        {
            timer += Time.deltaTime;
            if (timer >= wanderTime)
            {
                float randomX = Random.Range(-1f, 1f);
                float randomY = Random.Range(-1f, 1f);

                Vector2 randomDirection = new Vector2(randomX, randomY);
                randomDirection.Normalize();
                rb.velocity = randomDirection * wanderSpeed;

                timer = 0.0f;
            }

        }


    }


}
