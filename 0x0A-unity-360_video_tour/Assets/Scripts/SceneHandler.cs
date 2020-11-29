/* SceneHandler.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class SceneHandler : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    public Material[] skyboxes;
    public GameObject[] spheres;
    public GameObject[] canvases;
    public Animator currAnim;

    void Start()
    {
        Active(0);
    }

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "LivingRoomButton")
        {
            Active(0);
            Debug.Log("LivingRoomButton was clicked");
        }
        else if (e.target.name == "CantinaButton")
        {
            Active(1);
            Debug.Log("CantinaButton was clicked");
        }
        else if (e.target.name == "CubeButton")
        {
            Active(2);
            Debug.Log("CubeButton was clicked");
        }
        else if (e.target.name == "MezzanineButton")
        {
            Active(3);
            Debug.Log("MezzanineButton was clicked");
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "LivingRoomButton")
        {
            Debug.Log("LivingRoomButton was entered");
        }
        else if (e.target.name == "CantinaButton")
        {
            Debug.Log("CantinaButton was entered");
        }
        else if (e.target.name == "CubeButton")
        {
            Debug.Log("CubeButton was entered");
        }
        else if (e.target.name == "MezzanineButton")
        {
            Debug.Log("MezzanineButton was entered");
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "LivingRoomButton")
        {
            Debug.Log("LivingRoomButton was exited");
        }
        else if (e.target.name == "CantinaButton")
        {
            Debug.Log("CantinaButton was exited");
        }
        else if (e.target.name == "CubeButton")
        {
            Debug.Log("CubeButton was exited");
        }
        else if (e.target.name == "MezzanineButton")
        {
            Debug.Log("MezzanineButton was exited");
        }
    }

    public void Active(int i)
    {
        currAnim.SetTrigger("Fade");
        Reset();

        spheres[i].SetActive(true);
        canvases[i].SetActive(true);
        RenderSettings.skybox = skyboxes[i];
    }

    public void Reset()
    {
        for (int i = 0; i < 4; i++)
        {
        //  spheres[i].GetComponent<UnityEngine.Video.VideoPlayer>().Pause(); Trying to pause to not have that video jump
            spheres[i].SetActive(false);
            canvases[i].SetActive(false);
        }
    }
}
