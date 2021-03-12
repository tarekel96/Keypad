using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Keypad : MonoBehaviour
{
    public KeypadBackground Background;
    private Combination combination;
    private List<int> buttonsEntered;
    
    // Start is called before the first frame update
    void Start()
    {
        combination = new Combination();
        buttonsEntered = new List<int>();
    }
    // called by Keypad buttons
    public void RegisterButtonClick(int buttonValue)
    {
        buttonsEntered.Add(buttonValue);
        print(String.Join(",",buttonsEntered));
    }
    //
    public void TryToUnlock()
    {
        if (IsCorrectCombination()) // if correct - unlock success
            Unlock();
        else // else - unlock fail
            FailedToUnlock();
        ResetButtonEntries();
    }
    private bool IsCorrectCombination()
    {
        // if have not clicked any buttons, then not the right combination
        if (HaveNoButtonsBeenClicked() == true)
            return false;
        // if clicked wrong number of buttons, then it is wrong combination
        if (HaveWrongNumberOfButtonsBeenClicked() == true)
            return false;
        // check user UI inputted combination
        return CheckCombination();

    }
    private bool HaveNoButtonsBeenClicked()
    {
        return (buttonsEntered.Count == 0);
    }
    private bool HaveWrongNumberOfButtonsBeenClicked()
    {
        return (buttonsEntered.Count != combination.GetCombinationLength());
    }
    private bool CheckCombination()
    {
        for(int i = 0; i < buttonsEntered.Count; ++i)
        {
            if(IsCorrectButton(i) == false)
            {
                return false;
            }
        }
        return true;
    }
    private bool IsCorrectButton(int buttonIndex)
    {
        if (IsWrongEntry(buttonIndex))
        {
            return false;
        }
        return true;
    }
    private bool IsWrongEntry(int buttonIndex)
    {
        if (buttonsEntered[buttonIndex] == combination.GetCombinationDigit(buttonIndex))
        {
            return false;
        }
        return true;
    }
    private void Unlock()
    {
        Background.HideUnlockButton();
        Background.ChangeToSuccessColor();
    }
    private void FailedToUnlock()
    {
        Background.ChangeToFailedColor();
        StartCoroutine(ResetBackgroundColor());
    }
    private IEnumerator ResetBackgroundColor()
    {
        yield return new WaitForSeconds(0.33f);

        Background.ChangeToDefaultColor();
    }
    private void ResetButtonEntries()
    {
        buttonsEntered = new List<int>();
    }
}
