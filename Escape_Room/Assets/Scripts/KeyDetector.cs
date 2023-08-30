using System;
using TMPro;
using UnityEngine;

//source : https://www.youtube.com/watch?v=tXhW3OoMjMY&t=235s

public class KeyDetector : MonoBehaviour
{
    private TextMeshPro display;
    private KeyPadControl keyPadControl;

    void Start()
    {
        display = GameObject.FindGameObjectWithTag("Display").GetComponentInChildren<TextMeshPro>();
        display.text = "";

        keyPadControl = GameObject.FindGameObjectWithTag("Keypad").GetComponent<KeyPadControl>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KeypadButton"))
        {
            var key = other.GetComponentInChildren<TextMeshPro>();
            if (key != null)
            {
                var keyFeedBack = other.gameObject.GetComponent<KeyFeedBack>();

                if (key.text == "Back")
                {
                    if (display.text.Length > 0)
                    {
                        display.text = display.text.Substring(0, display.text.Length - 1);
                    }
                }
                else if (key.text == "Enter")
                {
                    var accessGranted = false;

                    bool onlyNumbers = int.TryParse(display.text, out int value);

                    if (onlyNumbers == true && display.text.Length > 0)
                    {
                        accessGranted = keyPadControl.CheckIfCorrect(Convert.ToInt32(display.text));
                    }

                    if (accessGranted == true)
                    {
                        display.text = "Start";
                    }
                    else
                    {
                        display.text = "Retry";
                    }
                }
                else if (key.text == "Cancel")
                {
                    display.text = "";
                }
                else
                {
                    bool onlyNumbers = int.TryParse(display.text, out int value);

                    if (onlyNumbers == false)
                    {
                        display.text = "";
                    }

                    if (display.text.Length < 4)
                    {
                        display.text += key.text;
                    }

                    
                }
                keyFeedBack.keyHit = true;
            }
        }
    }
}
