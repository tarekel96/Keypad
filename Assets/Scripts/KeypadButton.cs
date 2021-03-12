using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadButton : MonoBehaviour
{
    public int ButtonValue;
    public Keypad Keypad; 

    // tell key pad that the button was clicked, then tell it the button's value
    public void OnClick()
    {
        Keypad.RegisterButtonClick(ButtonValue);   
    }
}
