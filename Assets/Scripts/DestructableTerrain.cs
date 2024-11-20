using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableTerrain : MonoBehaviour
{
    [SerializeField]
    GameObject treePrefab;
    GameObject woodedLogInstance;
    EquipmentSlot eqSlot;

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.M))
        {
            Debug.Log("Chop chop");
            Destroy(gameObject);
            woodedLogInstance = Instantiate(treePrefab, collision.transform.position, Quaternion.identity);
        }
    }
}
