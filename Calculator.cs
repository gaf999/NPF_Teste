using NPF_Teste.Objectos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPF_Teste
{
    public class Calculator
    {
        /// <summary>
        /// Para uma dada lista de Numeros, verifica se é multiplo de 11 e 
        /// devolve uma lista de valores, numero(string)/isMultiple(bool)
        /// Este calculo parte desta premissa:
        /// 
        /// 
        /// Um número é divisível por 11, 
        /// caso a soma dos algarismos de ordem par subtraídos da soma dos algarismos de ordem ímpar, 
        /// resultar em um número divisível por 11. 
        /// Caso o resultado seja igual a 0, pode-se afirmar também que é divisível por 11.
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static List<Result> IsMultipleOf11(List<string> numbers)
        {
            List<Result> result = new List<Result>(); // result list

            foreach (string n in numbers) // para cada item na lista de entrada
            {
                Result itemResult = new Result() { number = n, isMultiple = false }; // by default
                
                string numero = n.Trim(); // trim dos espaços
                int size = numero.ToString().Length; //tamanho da string
                int sums = 0;

                try
                {
                    /******* para numeros pequenos (dois digitos) devolve por este metedo ***********/
                    if (size <= 2) 
                    {
                        itemResult.isMultiple = (int.Parse(numero) % 11) == 0;
                        result.Add(itemResult);
                        continue;
                    }

                    /******* para numeros maiores devolve por este metedo ***********/
                    for (int i = 0; i < size; i++)
                    {
                        int val = int.Parse(numero[i].ToString());

                        // soma e substrai respectivamente os digitos na posicao par e impar
                        sums += ((i + 1) % 2 == 0) ? val : -val; 
                    }

                    int resto = sums % 11; //resto das somas e subtraccoes por 11

                    itemResult.isMultiple = (resto == 0); //se o resto da divisao for igual a zero, entao é multiplo de 11
                    result.Add(itemResult); 
                }
                catch
                {
                    result.Add(itemResult); // possivelmente este item não é um valor numerico, dai a excepção
                }
            }

            return result; // retorna a lista completa
        }
    }
}