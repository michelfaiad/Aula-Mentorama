using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownBehaviour : MonoBehaviour
{

    Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {

        dropdown = GetComponent<Dropdown>();

        if (dropdown != null)
        {
            Resolution[] resolutions = Screen.resolutions;

            // Print the resolutions
            foreach (var res in resolutions)
            {
                dropdown.options.Add(new Dropdown.OptionData(res.width + "x" + res.height));                
            }
        }
    }

    public void OnValueSelect()
    {
        //Recupera o valor selecionado e quebra em largura e altura
        string option = dropdown.options[dropdown.value].text;               
        string[] values = option.Split("x");

        //muda a resolução da tela para a selecionada
        int resWidth, resHeight;
        if (Int32.TryParse(values[0], out resWidth) && Int32.TryParse(values[1], out resHeight))        {
            Screen.SetResolution(resWidth, resHeight, Screen.fullScreen);
        }
         
    }
}
