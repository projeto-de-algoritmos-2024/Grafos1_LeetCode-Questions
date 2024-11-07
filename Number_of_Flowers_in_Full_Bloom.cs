// https://leetcode.com/problems/number-of-flowers-in-full-bloom/description/

using System;
using System.Linq;

public class Solution {
    private int ContarMenorOuIgual(int[] arr, int x) {
        int esquerda = 0, direita = arr.Length - 1;
        
        while (esquerda <= direita) {
            int meio = esquerda + (direita - esquerda) / 2;
            if (arr[meio] <= x) {
                esquerda = meio + 1;
            } else {
                direita = meio - 1;
            }
        }
        return esquerda;
    }

    private int[] ExtrairEOrdenarTempos(int[][] flowers, bool isInicio) {
        int[] tempos = flowers.Select(f => f[isInicio ? 0 : 1]).ToArray();
        Array.Sort(tempos);
        return tempos;
    }

    private int CalcularFloresEmBloom(int tempoPessoa, int[] tempoInicio, int[] tempoFinal) {
        int comecaram = ContarMenorOuIgual(tempoInicio, tempoPessoa);
        int terminaram = ContarMenorOuIgual(tempoFinal, tempoPessoa - 1);
        return comecaram - terminaram;
    }

    public int[] FullBloomFlowers(int[][] flowers, int[] people) {
        int[] tempoInicio = ExtrairEOrdenarTempos(flowers, true);
        int[] tempoFinal = ExtrairEOrdenarTempos(flowers, false);
        int[] respostas = new int[people.Length];
        
        for (int i = 0; i < people.Length; i++) {
            respostas[i] = CalcularFloresEmBloom(people[i], tempoInicio, tempoFinal);
        }
        
        return respostas;
    }
}