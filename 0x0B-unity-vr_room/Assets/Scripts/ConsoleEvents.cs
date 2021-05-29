using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Valve.VR.InteractionSystem;

public class ConsoleEvents : MonoBehaviour
{
    // Individual materials for console screen
    public Material ScreenOnMat;
    public Material ScreenOffMat;
    public Material WrongCodeMat;
    public Material CorrectCodeMat;

    // Console game object
    public GameObject ConsoleGO;

    // Console Code Screen Game Object
    public GameObject CodeScreenGO;

    // Will contain the user input code
    private string code = "";

    // The individual code displays
    public TMP_Text[] CodeDigits = new TMP_Text[4];
    //public TMP_Text Num1;
    //public TMP_Text Num2;
    //public TMP_Text Num3;
    //public TMP_Text Num4;

    // The possible code display messages
    public GameObject InputCode;
    public GameObject IncompleteCode;
    public GameObject WrongCode;
    public GameObject Unlocking;

    // The Door Animator to set the unlocked boolean
    public Animator DoorAnim;

    // Changes the material of the console screen
    public void WakeUp() {
        Material[] matArray = ConsoleGO.GetComponent<Renderer>().materials;

        matArray[1] = ScreenOnMat;
        ConsoleGO.GetComponent<Renderer>().materials = matArray;
    }

    public void OnPress(Hand hand)
    {
        // Removes power on text from console screen
        ConsoleGO.transform.Find("PowerOnTMP").gameObject.SetActive(false);

        // Sets up screen for code input
        ConsoleGO.transform.Find("ParentCodeInput").gameObject.SetActive(true);

        WakeUp();
    }

    // Checks user input for correct code
    public void CodeInput(string num)
    {
        if (code.Length < 4 && num.Length == 1) {
            code += num;
            for (int i = 0; i < CodeDigits.Length; i++) {
                if (code.Length == i + 1)
                    CodeDigits[i].text = code[i].ToString();
            }
        } else if (num == "Clear") {
            code = "";
            // Remove text from code displays
            for (int i = 0; i < CodeDigits.Length; i++) {
                CodeDigits[i].text = "";
            }
        } else if (num == "Enter" ) {
            if (code == "0321") {
                ResetCodeMessage();
                Unlocking.SetActive(true);

                UnlockScreen();
            } else if (code.Length < 4) {
                ResetCodeMessage();
                IncompleteCode.SetActive(true);
                CodeScreenGO.GetComponent<Renderer>().material = WrongCodeMat;
            } else {
                ResetCodeMessage();
                WrongCode.SetActive(true);
                CodeScreenGO.GetComponent<Renderer>().material = WrongCodeMat;
            }
        }
    }

    // Resets all possible text options above code display
    public void ResetCodeMessage() {
        InputCode.SetActive(false);
        IncompleteCode.SetActive(false);
        WrongCode.SetActive(false);
    }

    // Completes everything to be done on Unlock
    public void UnlockScreen() {
        // Change screen color to green
        Material[] matArray = ConsoleGO.GetComponent<Renderer>().materials;

        matArray[1] = CorrectCodeMat;
        ConsoleGO.GetComponent<Renderer>().materials = matArray;

        // Sets animation "unlocked" bool to true
        DoorAnim.SetBool("unlocked", true);
        // Turns off screen display for code input
        ConsoleGO.transform.Find("ParentCodeInput").gameObject.SetActive(false);
    }
}
