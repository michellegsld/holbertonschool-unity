using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    public void SpriteClick(string url)
    {
        Application.OpenURL(url);
        Debug.Log("is this working?");
    }

    public void CreateEmail()
    {
        string email = "michellegsld@gmail.com";
        Application.OpenURL("mailto:" + email);
        Debug.Log("Open the email app!");
    }
}
