// https://leetcode.com/problems/shortest-path-visiting-all-nodes/description/

using System;
using System.Collections.Generic;

public class Solution {
    public int ShortestPathLength(int[][] graph) {
        int n = graph.Length;
        int estadoFinal = (1 << n) - 1;  
        Queue<(int noAtual, int estadoAtual, int distanciaAtual)> fila = new Queue<(int, int, int)>();
        HashSet<(int, int)> visitado = new HashSet<(int, int)>();

        for (int i = 0; i < n; i++) {
            fila.Enqueue((i, 1 << i, 0));
            visitado.Add((i, 1 << i));
        }

        while (fila.Count > 0) {
            var (noAtual, estadoAtual, distanciaAtual) = fila.Dequeue();

            if (estadoAtual == estadoFinal)
                return distanciaAtual;

            foreach (int vizinho in graph[noAtual]) {
                int novoEstado = estadoAtual | (1 << vizinho);

                if (!visitado.Contains((vizinho, novoEstado))) {
                    fila.Enqueue((vizinho, novoEstado, distanciaAtual + 1));
                    visitado.Add((vizinho, novoEstado));
                }
            }
        }

        return -1;  
    }
}