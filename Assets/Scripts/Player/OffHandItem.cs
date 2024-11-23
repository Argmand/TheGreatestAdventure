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
    bool touchingStoneLantern;

    [SerializeField] 
    Transform parentGO;

    [SerializeField]
    public float lampOilLeft, maxLampOil, oilCost, intensityAmount, oilRefill;

    Light lanterLight;

    private void Start()
    {
        //lanterLight = lanternLightInstance.GetComponent<Light>();
    }

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
        if (lantenernIsLit == true)
        {
            lampOilLeft -= oilCost * Time.deltaTime;
            //lanterLight.intensity = Mathf.Lerp();
            

            if (lampOilLeft <= 0)
            {
                lampOilLeft = 0;
                lantenernIsLit = false;
                Destroy(lanternLightInstance);
            }
            
        }
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("StoneLantern") && lampOilLeft < maxLampOil)
        {
            lampOilLeft += oilRefill * Time.deltaTime; 
        }
    }
}
