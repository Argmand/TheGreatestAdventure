using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffHandItem : MonoBehaviour
{
    [SerializeField] 
    GameObject lanternLightPrefab;

    [SerializeField] 
    Transform EquipmentOrgin;

    private bool lantenernIsLit;
    GameObject lanternLightInstance;

    [SerializeField] 
    Transform parentGO;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (lantenernIsLit == false)
            {
                lanternLightInstance = Instantiate(lanternLightPrefab, EquipmentOrgin.position, Quaternion.identity, parentGO);
                lanternLightInstance.name = "Lantern Light";
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
