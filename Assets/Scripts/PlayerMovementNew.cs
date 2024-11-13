using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementNew : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    public float sprintSpeedIncrease;

    public bool playerInLight;
    public bool playerIsSprinting;

    public float stamina, maxStamina, sRegen;
    public float runCost;
    public Image staminaBar;

    public Vector2 speedOMeter;


    // Start is called before the first frame update
    void Start()
    {
        playerInLight = false;
        playerIsSprinting = false;
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


        if (Input.GetButton("Sprint") && (Input.GetButton("Horizontal") || Input.GetButton("Vertical")))
        {
            playerIsSprinting = true;
        }
        else if (Input.GetButtonUp("Sprint") || Input.GetButton("Sprint"))
        {
            playerIsSprinting = false;
        }

        if (playerIsSprinting == true && stamina > 0)
        {
            rb2d.velocity = moveInput * moveSpeed * sprintSpeedIncrease;

            stamina -= runCost * Time.deltaTime;
            staminaBar.fillAmount = stamina / maxStamina;
            if (stamina < 0)
                stamina = 0;
        }
        else if (playerIsSprinting == false && stamina < maxStamina)
        {
            stamina += sRegen * Time.deltaTime;
            staminaBar.fillAmount = stamina / maxStamina;
            rb2d.velocity = moveInput * moveSpeed;
        }

        speedOMeter = rb2d.velocity;
    }
}
