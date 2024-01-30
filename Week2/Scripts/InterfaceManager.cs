using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public TextMeshProUGUI label;
    public void InputValue(int n)
    {
        Debug.Log(n);
        label.text = n.ToString();
    }
}
    
