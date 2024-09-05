using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Biomasecasas : MonoBehaviour
{
    private const int CASA_NORMAL = 0;       // Casa normal sem efeitos
    private const int CASA_AVANCA = 1;       // Casa que faz o jogador avançar
    private const int CASA_RETROCEDE = -1;   // Casa que faz o jogador retroceder
    private const int CASA_CARTA = 2;        // Casa que dá uma carta (atalho)
    private const int CASA_ARTEFATO = 3;     // Casa com artefato que dá pontos

    // Matriz representando os biomas (mapas) e suas casas
    private int[,] biomas = new int[4, 20]
    {
        { CASA_NORMAL, CASA_NORMAL, CASA_AVANCA, CASA_NORMAL, CASA_RETROCEDE, CASA_CARTA, CASA_NORMAL, CASA_ARTEFATO, CASA_NORMAL, CASA_RETROCEDE,
          CASA_NORMAL, CASA_CARTA, CASA_NORMAL, CASA_AVANCA, CASA_NORMAL, CASA_NORMAL, CASA_RETROCEDE, CASA_NORMAL, CASA_CARTA, CASA_ARTEFATO }, // Bioma 1

        { CASA_NORMAL, CASA_NORMAL, CASA_RETROCEDE, CASA_AVANCA, CASA_NORMAL, CASA_CARTA, CASA_ARTEFATO, CASA_NORMAL, CASA_RETROCEDE, CASA_AVANCA,
          CASA_NORMAL, CASA_NORMAL, CASA_CARTA, CASA_NORMAL, CASA_AVANCA, CASA_NORMAL, CASA_ARTEFATO, CASA_NORMAL, CASA_CARTA, CASA_RETROCEDE }, // Bioma 2

        { CASA_NORMAL, CASA_AVANCA, CASA_NORMAL, CASA_RETROCEDE, CASA_CARTA, CASA_NORMAL, CASA_NORMAL, CASA_ARTEFATO, CASA_NORMAL, CASA_AVANCA,
          CASA_RETROCEDE, CASA_NORMAL, CASA_CARTA, CASA_NORMAL, CASA_ARTEFATO, CASA_NORMAL, CASA_AVANCA, CASA_NORMAL, CASA_RETROCEDE, CASA_CARTA }, // Bioma 3

        { CASA_NORMAL, CASA_NORMAL, CASA_NORMAL, CASA_AVANCA, CASA_RETROCEDE, CASA_CARTA, CASA_ARTEFATO, CASA_NORMAL, CASA_NORMAL, CASA_RETROCEDE,
          CASA_AVANCA, CASA_NORMAL, CASA_CARTA, CASA_NORMAL, CASA_ARTEFATO, CASA_RETROCEDE, CASA_NORMAL, CASA_AVANCA, CASA_CARTA, CASA_NORMAL }  // Bioma 4
    };

    // Array para armazenar a posição atual de cada jogador (4 jogadores)
    public int[] posicoesJogadores = new int[4] { 0, 0, 0, 0 }; // Todos começam na posição 0

    // Método para mover o jogador
    public void MoverJogador(int indiceJogador, int passos)
    {
        // Calcula a nova posição do jogador com base nos passos
        int novaPosicao = posicoesJogadores[indiceJogador] + passos;

        // Verifica se a nova posição ultrapassa o limite do bioma atual (usando o primeiro bioma para exemplo)
        if (novaPosicao >= biomas.GetLength(1)) // GetLength(1) retorna o número de colunas (casas) na matriz
        {
            novaPosicao = biomas.GetLength(1) - 1; // Define a posição como a última casa se passar do limite
        }

        // Atualiza a posição do jogador para a nova posição calculada
        posicoesJogadores[indiceJogador] = novaPosicao;

        // Verifica o tipo de casa onde o jogador parou
        VerificarCasaAtual(indiceJogador);
    }

    // Método para verificar o tipo de casa onde o jogador parou
    private void VerificarCasaAtual(int indiceJogador)
    {
        // Obtém o tipo da casa na posição atual do jogador no bioma 0 (primeiro bioma)
        int casaAtual = biomas[0, posicoesJogadores[indiceJogador]];

        // Verifica o tipo de casa usando if-else
        if (casaAtual == CASA_AVANCA) // Casa que avança
        {
            MoverJogador(indiceJogador, 1); // Avança 1 casa
        }
        else if (casaAtual == CASA_RETROCEDE) // Casa que retrocede
        {
            MoverJogador(indiceJogador, -1); // Retrocede 1 casa
        }
        else if (casaAtual == CASA_CARTA) // Casa com carta (atalho)
        {
            MoverJogador(indiceJogador, 2); // Avança 2 casas (simulando uma carta que ajuda)
        }
        else if (casaAtual == CASA_ARTEFATO) // Casa com artefato
        {
            // Ação ao encontrar um artefato, como adicionar pontos
            Debug.Log($"Jogador {indiceJogador + 1} encontrou um artefato!"); // Exibe mensagem no console
        }
        // Casas normais (CASA_NORMAL) não causam nenhuma ação especial
    }

    // Método para simular o turno do jogador (rolando um dado)
    public void TurnoJogador(int indiceJogador)
    {
        int passos = Random.Range(1, 7); // Gera um número aleatório entre 1 e 6
        MoverJogador(indiceJogador, passos); // Move o jogador de acordo com o resultado do "dado"
    }
}
