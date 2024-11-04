using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{
    [SerializeField] GameObject offHandEquipmentPrefab;
    [SerializeField] Transform EquipmentOrgin;
    private bool lantenernIsLit;
    GameObject lanternLightInstance;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (lantenernIsLit == false)
            {
                lanternLightInstance = Instantiate(offHandEquipmentPrefab, EquipmentOrgin.position, Quaternion.identity);
                lantenernIsLit = true;
            }
            else if (lanternLightInstance == true)
            {
                Destroy(lanternLightInstance);
                lantenernIsLit = false;
            }
        }

        //lanternLightInstance.AddComponent
    }
}
