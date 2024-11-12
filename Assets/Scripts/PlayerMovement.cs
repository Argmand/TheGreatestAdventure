using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    public float sprintSpeed;

    public float stamina;

    public bool playerInLight;

    // Start is called before the first frame update
    void Start()
    {
        playerInLight = false;
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "LanternLight")
        {
            Debug.Log("lanternlight");
            playerInLight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerInLight = false;
    }



    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb2d.velocity = moveInput * moveSpeed;

        if (Input.GetButton("Sprint") && stamina > 0)
        {
            rb2d.velocity = moveInput * moveSpeed * sprintSpeed;
            stamina -= 1 * Time.deltaTime;
        }
        else stamina += 1 * Time.deltaTime;
    }
}