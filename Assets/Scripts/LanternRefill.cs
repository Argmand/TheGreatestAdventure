using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternRefill : MonoBehaviour
{
    OffHandItem offHandItem;

    

    private void Start()
    {
        offHandItem = GetComponent<OffHandItem>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("HIt lantern");
        if (collision.gameObject.layer == LayerMask.NameToLayer("StoneLantern"))
        {
            offHandItem.lampOilLeft += offHandItem.oilRefill * Time.deltaTime;
        }
    }
}
