using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desafiofinal : MonoBehaviour
{
    private bool[] jogadoresConcluidos = new bool[4]; // Inicia todos como falsos

    // M�todo para verificar o desafio final para um jogador
    public void VerificarDesafioFinal(int indiceJogador)
    {
        // Marca o jogador como conclu�do
        jogadoresConcluidos[indiceJogador] = true;

        // Verifica se todos os jogadores j� chegaram ao final do bioma
        foreach (bool concluido in jogadoresConcluidos)
        {
            // Se algum jogador ainda n�o concluiu, exibe mensagem e espera
            if (!concluido)
            {
                Debug.Log($"Jogador {indiceJogador + 1} deve esperar pelos outros!");
                return; // Sai do m�todo sem avan�ar para o pr�ximo bioma
            }
        }

        // Todos os jogadores conclu�ram, pode avan�ar para o pr�ximo bioma
        Debug.Log("Todos os jogadores completaram o desafio final! Avan�ando para o pr�ximo bioma.");
        // Implementar a l�gica para transi��o ao pr�ximo bioma aqui
    }
}
