using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodLogPlayerCatcher : MonoBehaviour
{
    [SerializeField]
    GameObject woodLogPrefab, 
               woodLogRBodyPrefab;

    /*[SerializeField]
    GameObject player;*/

    [SerializeField]
    Transform playerMounting;

    GameObject woodLogInstance, woodLogRBodyInstance;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WoodLog")) 
        {
            Destroy(collision.gameObject);
            woodLogInstance = Instantiate(woodLogPrefab, playerMounting.position, Quaternion.identity, playerMounting);
        }
    }
}
