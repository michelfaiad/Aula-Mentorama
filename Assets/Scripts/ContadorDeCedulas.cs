using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ContadorDeCedulas : MonoBehaviour
{
    [Header("Insira a quantidade de dinheiro a ser considerada")]
    [SerializeField] float money;

    /*
     Cédulas Consideradas
       R$ 100, R$ 50, R$ 20, R$ 10, R$ 5 e R$ 1
    */
    int[,] quantidadeCedulas = new int[6, 2];

    /*
     Moedas Consideradas
       R$ 0,10, R$ 0,05 e R$ 0,01
     */
    int[,] quantidadeMoedas = new int[3, 2];
    
    int valorEmCedulas;
    int valorEmMoedas;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Iniciando a contagem de R$" + money);

        //Inicializando o Array de Cedulas
        //Pos 0 = tipo de cedula e Pos 1 = quantidade necessária
        quantidadeCedulas[0, 0] = 100;
        quantidadeCedulas[1, 0] = 50;
        quantidadeCedulas[2, 0] = 20;
        quantidadeCedulas[3, 0] = 10;
        quantidadeCedulas[4, 0] = 5;
        quantidadeCedulas[5, 0] = 1;

        //Inicializando o Array de Moedas
        //Pos 0 = tipo de cedula e Pos 1 = quantidade necessária
        quantidadeMoedas[0, 0] = 10;
        quantidadeMoedas[1, 0] = 5;
        quantidadeMoedas[2, 0] = 1;

        // A parte inteira do valor será dividida em cédulas
        valorEmCedulas = (int)money;
        Debug.Log("valor inteiro de money:  R$" + valorEmCedulas);

        // A parte decimal será dividida em moedas
        valorEmMoedas = Mathf.RoundToInt(100 * (money % valorEmCedulas));
        Debug.Log("valor decimal de money: " + valorEmMoedas + " centavos");

        //Calculo das cedulas
        Contagem(valorEmCedulas, quantidadeCedulas);
        Imprime("cédulas", quantidadeCedulas);

        //Calculo das Moedas
        Contagem(valorEmMoedas, quantidadeMoedas);
        Imprime("moedas", quantidadeMoedas);
    }

    private void Contagem(int valor, int[,] matriz)
    {

        int valorRestante = valor;

        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            matriz[i,1] = valorRestante / matriz[i,0];
            valorRestante = valorRestante % matriz[i, 0];
        }
        
    }

    private void Imprime(string nome, int[,] matriz)
    {
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            Debug.Log("Quantidade de "+ nome +" de " + matriz[i,0] +" : " + matriz[i,1]);
        }
    }
}
