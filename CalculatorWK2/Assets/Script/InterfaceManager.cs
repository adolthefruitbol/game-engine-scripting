using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public TextMeshProUGUI label;
    private MathTypes mathtype = MathTypes.Divide;

    public void InputValue(int n)
    {
        label.text += n.ToString();
    }

    public void DoSomething()
    {
        if(mathtype == MathTypes.Divide)
        {
            //Divide our numbers...
        }
        Debug.Log("I did something");
    }

    public enum MathTypes
    {
        Muliply,
        Divide
    }
}
