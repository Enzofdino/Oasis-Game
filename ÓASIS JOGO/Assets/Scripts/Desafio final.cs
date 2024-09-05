using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desafiofinal : MonoBehaviour
{
    private bool[] jogadoresConcluidos = new bool[4]; // Inicia todos como falsos

    // Método para verificar o desafio final para um jogador
    public void VerificarDesafioFinal(int indiceJogador)
    {
        // Marca o jogador como concluído
        jogadoresConcluidos[indiceJogador] = true;

        // Verifica se todos os jogadores já chegaram ao final do bioma
        foreach (bool concluido in jogadoresConcluidos)
        {
            // Se algum jogador ainda não concluiu, exibe mensagem e espera
            if (!concluido)
            {
                Debug.Log($"Jogador {indiceJogador + 1} deve esperar pelos outros!");
                return; // Sai do método sem avançar para o próximo bioma
            }
        }

        // Todos os jogadores concluíram, pode avançar para o próximo bioma
        Debug.Log("Todos os jogadores completaram o desafio final! Avançando para o próximo bioma.");
        // Implementar a lógica para transição ao próximo bioma aqui
    }
}
