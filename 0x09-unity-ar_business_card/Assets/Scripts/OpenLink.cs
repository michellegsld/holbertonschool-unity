using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    public void SpriteClick()
    {
        Application.OpenURL("https://www.linkedin.com/in/michelle-giraldo-759990193/");
        Debug.Log("is this working?");
    }
}
