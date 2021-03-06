﻿/* SceneHandler.cs*/
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
    public Animator[] transitionAnims;
    private Animator buttonAnim;

    void Start()
    {
        StartCoroutine(Active(-1));
    }

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        buttonAnim = e.target.transform.gameObject.GetComponent<Animator>();

        if (e.target.name == "LivingRoomButton") {
            StartCoroutine(Active(0));
            Debug.Log("LivingRoomButton was clicked");
        } else if (e.target.name == "CantinaButton") {
            StartCoroutine(Active(1));
            Debug.Log("CantinaButton was clicked");
        } else if (e.target.name == "CubeButton") {
            StartCoroutine(Active(2));
            Debug.Log("CubeButton was clicked");
        } else if (e.target.name == "MezzanineButton") {
            StartCoroutine(Active(3));
            Debug.Log("MezzanineButton was clicked");
        } else if (e.target.name == "InfoButton") {
            GameObject textBox = e.target.gameObject.transform.GetChild(0).gameObject;

            if (textBox.activeSelf == true) {
                buttonAnim.SetBool("open", false);
                textBox.SetActive(false);
            } else {
                buttonAnim.SetBool("open", true);
                textBox.SetActive(true);
            }
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        buttonAnim = e.target.transform.gameObject.GetComponent<Animator>();
        buttonAnim.SetBool("hover", true);

        if (e.target.name == "LivingRoomButton") {
            Debug.Log("LivingRoomButton was entered");
        } else if (e.target.name == "CantinaButton") {
            Debug.Log("CantinaButton was entered");
        } else if (e.target.name == "CubeButton") {
            Debug.Log("CubeButton was entered");
        } else if (e.target.name == "MezzanineButton") {
            Debug.Log("MezzanineButton was entered");
        } else if (e.target.name == "LivingInfoButton") {
            Debug.Log("InfoButton was entered");
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        buttonAnim = e.target.transform.gameObject.GetComponent<Animator>();
        buttonAnim.SetBool("hover", false);

        if (e.target.name == "LivingRoomButton") {
            Debug.Log("LivingRoomButton was exited");
        } else if (e.target.name == "CantinaButton") {
            Debug.Log("CantinaButton was exited");
        } else if (e.target.name == "CubeButton") {
            Debug.Log("CubeButton was exited");
        } else if (e.target.name == "MezzanineButton") {
            Debug.Log("MezzanineButton was exited");
        } else if (e.target.name == "InfoButton") {
            Debug.Log("InfoButton was exited");
        }
    }

    public IEnumerator Active(int i)
    {
        if (i >= 0) {
            transitionAnims[0].SetTrigger("Fade");
            transitionAnims[1].SetTrigger("Fade");
            yield return new WaitForSeconds(1.25f);
            Reset();
        } else {
            i = 0;
        }

        spheres[i].SetActive(true);
        canvases[i].SetActive(true);
        RenderSettings.skybox = skyboxes[i];
        yield break;
    }

    public void Reset()
    {
        for (int i = 0; i < 4; i++)
        {
            spheres[i].SetActive(false);
            canvases[i].SetActive(false);
        }
    }
}
