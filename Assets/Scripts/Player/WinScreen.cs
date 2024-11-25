using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField]
    GameObject winScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trying to open door");
        if (collision.gameObject.CompareTag("Player")) 
        {
            Debug.Log("DoorOpend");
            winScreen.SetActive(true);
        }
    }
}
