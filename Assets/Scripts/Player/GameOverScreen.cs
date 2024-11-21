using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    GameObject gameoverScreen, inventoryCanvas;

    PlayerMovementNew playerMoveRef;

    //public float stamina, maxStamina;
    public float ghostDmg;
    public Image staminaBar;

    // Start is called before the first frame update
    void Start()
    {
        playerMoveRef = GetComponent<PlayerMovementNew>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ghost") && playerMoveRef.stamina > -1)
        {
            playerMoveRef.stamina -= ghostDmg * Time.deltaTime;
            staminaBar.fillAmount = playerMoveRef.stamina / playerMoveRef.maxStamina;
        }
        else if (playerMoveRef.stamina <= -1)
        {
            Time.timeScale = 0;
            inventoryCanvas.SetActive(false);
            gameoverScreen.SetActive(true);
        }
    }
}
