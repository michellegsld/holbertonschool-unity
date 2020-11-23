using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkybox : MonoBehaviour
{
    public Material[] skyboxes;
    public GameObject[] spheres;

    // Should change the skybox depending on which sphere is active at any time
    void Update()
    {
        for (int i = 0; i < spheres.Length; i++)
        {
            if (spheres[i].activeSelf == true)
            {
                RenderSettings.skybox = skyboxes[i];
                return;
            }
        }
    }
}
