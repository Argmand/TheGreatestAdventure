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

    //If player is in light
    public bool playerInLight;
    public bool playerIsSprinting;

    //stamina test
    public float stamina, maxStamina, sRegen;
    public float runCost;
    public Image staminaBar;

    public Vector2 speedOMeter;

    [SerializeField]
    GameObject inventoryCanvas;

    //player animation
    public Animator _animator;
    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";
    private const string _lastHorizontal = "LastHorizontal";
    private const string _lastVertical = "LastVertical";
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }



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
            //Debug.Log("lanternlight");
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
        //Basic player movement
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb2d.velocity = moveInput * moveSpeed;

        //Stamina test
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

        //Not sure what this does. I think it's just for devs to see the players speed
        speedOMeter = rb2d.velocity;


        //player animation
        _animator.SetFloat(_horizontal, moveInput.x);
        _animator.SetFloat(_vertical, moveInput.y);
        if (moveInput != Vector2.zero)
        {
            _animator.SetFloat(_lastHorizontal, moveInput.x);
            _animator.SetFloat(_lastVertical, moveInput.y);
        }
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Touch lanterhn");
        if (collision.gameObject.tag == "LanternLight" && offHandItem.lampOilLeft < offHandItem.maxLampOil)
        {
            Debug.Log("ReFill");
            offHandItem.lampOilLeft += offHandItem.oilRefill * Time.deltaTime;
        }
    }*/
}
