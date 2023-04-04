using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Toggle>().isOn)
        {
            Screen.fullScreen = true;
        }
    }

    public void OnValueChange()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
