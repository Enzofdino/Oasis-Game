using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovimento : MonoBehaviour
{
    public Biomasecasas tabuleiro;

    // Índice deste jogador (0, 1, 2 ou 3)
    public int indiceJogador;

    // Array para armazenar as posições físicas das casas no tabuleiro
    private Vector3[] posicoesTabuleiro;

    // Flag para controlar se o jogador já se moveu no turno atual
    private bool podeMover = true;

    private void Start()
    {
        // Inicializa as posições no tabuleiro, assumindo que há 20 casas
        posicoesTabuleiro = new Vector3[20];

        // Definindo posições físicas para cada casa no tabuleiro
        for (int i = 0; i < posicoesTabuleiro.Length; i++)
        {
            posicoesTabuleiro[i] = new Vector3(i * 2.0f, 0, 0); // Exemplo: posicionando em linha reta
        }

        // Inicializa o jogador na posição inicial
        AtualizarPosicaoVisual(tabuleiro.posicoesJogadores[indiceJogador]);
    }

    private void Update()
    {
        // Verifica se o jogador pressiona a tecla "Espaço" e se pode se mover
        if (Input.GetKeyDown(KeyCode.Space) && podeMover)
        {
            // Simula um turno do jogador ao pressionar "Espaço"
            Turno();
            podeMover = false; // Desativa o movimento até o próximo turno
        }

        // Exemplo: para resetar o movimento para testes, pressiona "R"
        if (Input.GetKeyDown(KeyCode.R))
        {
            podeMover = true; // Permite o jogador se mover novamente
        }
    }

    // Método para mover o jogador no tabuleiro
    public void Mover(int passos)
    {
        // Mover o jogador logicamente no tabuleiro
        tabuleiro.MoverJogador(indiceJogador, passos);

        // Atualiza a posição visual do jogador
        AtualizarPosicaoVisual(tabuleiro.posicoesJogadores[indiceJogador]);
    }

    // Atualiza a posição visual do jogador no jogo
    private void AtualizarPosicaoVisual(int novaPosicao)
    {
        // Verifica se a nova posição é válida
        if (novaPosicao >= 0 && novaPosicao < posicoesTabuleiro.Length)
        {
            // Define a posição do objeto do jogador no espaço do jogo
            transform.position = posicoesTabuleiro[novaPosicao];
        }
    }

    // Método para simular o turno do jogador
    public void Turno()
    {
        // Gera um número aleatório entre 1 e 6 para simular um dado
        int passos = Random.Range(1, 7);
        Debug.Log($"Jogador {indiceJogador + 1} rolou {passos} passos.");

        // Move o jogador de acordo com o número de passos
        Mover(passos);
    }
}