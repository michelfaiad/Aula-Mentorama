using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetornaMaiorNumero : MonoBehaviour
{
    [SerializeField] float numeroA, numeroB, numeroC;
    
    void Start()
    {
        if(numeroA > numeroB && numeroA > numeroC)
        {
            Debug.Log($"O maior n�mero � {numeroA}");
        }
        else if (numeroB > numeroC)
        {
            Debug.Log($"O maior n�mero � {numeroB}");
        }
        else
        {
            Debug.Log($"O maior n�mero � {numeroC}");
        }
    }
       
}
