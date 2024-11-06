// https://leetcode.com/problems/longest-increasing-path-in-a-matrix/description/

using System;
public class Solution {
    private int[,] direcoes = new int[,] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };

    private int DFS(int[][] matrix, int linha, int coluna, int[,] memo) {
        if (memo[linha, coluna] != 0)
            return memo[linha, coluna];

        int caminhoMaximo = 1;

        for (int i = 0; i < 4; i++) {
            int novaLinha = linha + direcoes[i, 0];
            int novaColuna = coluna + direcoes[i, 1];

            if (novaLinha >= 0 && novaLinha < matrix.Length && 
                novaColuna >= 0 && novaColuna < matrix[0].Length && 
                matrix[novaLinha][novaColuna] > matrix[linha][coluna]) {
                caminhoMaximo = Math.Max(caminhoMaximo, 1 + DFS(matrix, novaLinha, novaColuna, memo));
            }
        }

        memo[linha, coluna] = caminhoMaximo;
        return caminhoMaximo;
    }

    public int LongestIncreasingPath(int[][] matrix) {
        if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0) 
            return 0;

        int linhas = matrix.Length;
        int colunas = matrix[0].Length;
        int[,] memo = new int[linhas, colunas];
        int caminhoMaisLongo = 0;

        for (int i = 0; i < linhas; i++) {
            for (int j = 0; j < colunas; j++) {
                caminhoMaisLongo = Math.Max(caminhoMaisLongo, DFS(matrix, i, j, memo));
            }
        }
        return caminhoMaisLongo;
    }
}