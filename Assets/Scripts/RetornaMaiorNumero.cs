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
            Debug.Log($"O maior número é {numeroA}");
        }
        else if (numeroB > numeroC)
        {
            Debug.Log($"O maior número é {numeroB}");
        }
        else
        {
            Debug.Log($"O maior número é {numeroC}");
        }
    }
       
}
