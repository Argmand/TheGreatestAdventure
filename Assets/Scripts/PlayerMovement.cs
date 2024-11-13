using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    Rigidbody2D rBody;

    public Image staminaBar;
    public float stamina, maxStamina, staminaRegen;
    public float moveCost, runCost;
    public float chargeRate;

    

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    /*private void regenStamina() 
    {
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Debug.Log("Shift Key Up");
            for (int sRegen = 0; sRegen < maxStamina; sRegen++)
            {
                stamina += sRegen * Time.deltaTime;
                staminaBar.fillAmount = stamina / maxStamina;
            }
            if (stamina > maxStamina)
            {
                stamina = maxStamina;
            }
        }
    }*/

    // Update is called once per frame
    async void Update()
    {
        Vector2 moveDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y += 1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y -= 1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x += 1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x -= 1.0f;
            
        }

        

        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0 && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)))
        {
            moveDirection.x *= 1.5f;
            moveDirection.y *= 1.5f;
            stamina -= runCost * Time.deltaTime;
            staminaBar.fillAmount = stamina / maxStamina;

            
        }

        if (stamina < maxStamina && !Input.GetKey(KeyCode.LeftShift))
        {
            await regenStamina();
        }

        Vector2 newVelocity = moveDirection;
        newVelocity.x *= movementSpeed;
        newVelocity.y *= movementSpeed;

        rBody.velocity = newVelocity;
    }

    public async Task regenStamina() 
    {   
        while (stamina < maxStamina)
        {
            await Task.Delay(50);
            stamina += staminaRegen;
            staminaBar.fillAmount = stamina / maxStamina;

            if (stamina > maxStamina)
            {
                stamina = maxStamina;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Debug.Log("");
            }

        }
        await Task.Yield();
    }
}
