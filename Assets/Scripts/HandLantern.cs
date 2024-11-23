using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLantern : MonoBehaviour
{
    [SerializeField]
    GameObject lanternLightPrefab;



    public bool lantenernIsLit;
    GameObject lanternLightInstance;




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (lantenernIsLit == false)
            {
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
