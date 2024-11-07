// https://leetcode.com/problems/keys-and-rooms/description/

using System.Collections.Generic;

public class Solution {
    private bool verificaTodasSalasVisitadas(bool[] visitado) {
        foreach (bool foiVisitado in visitado) {
            if (!foiVisitado) {
                return false;
            }
        }
        return true;
    }

    private void percorreSalas(IList<IList<int>> rooms, bool[] visitado) {
        Stack<int> pilha = new Stack<int>();
        pilha.Push(0);
        visitado[0] = true;
        
        while (pilha.Count > 0) {
            int sala = pilha.Pop();
            
            foreach (int chave in rooms[sala]) {
                if (!visitado[chave]) {
                    visitado[chave] = true;
                    pilha.Push(chave);
                }
            }
        }
    }

    public bool CanVisitAllRooms(IList<IList<int>> rooms) {
        int n = rooms.Count;
        bool[] visitado = new bool[n];
        
        percorreSalas(rooms, visitado);
        return verificaTodasSalasVisitadas(visitado);
    }
}