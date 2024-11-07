using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float MovementSpeed;
    Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y += 1.0f;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection.x *= 1.5f;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y -= 1.0f;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection.x *= 1.5f;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x += 1.0f;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection.x *= 1.5f;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x -= 1.0f;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection.x *= 1.5f;
            }
        }
        

        Vector2 newVelocity = moveDirection;
        newVelocity.x *= MovementSpeed;
        newVelocity.y *= MovementSpeed;

        rBody.velocity = newVelocity;
    }
}
