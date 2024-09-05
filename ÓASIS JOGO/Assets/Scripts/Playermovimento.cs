using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovimento : MonoBehaviour
{
    public Biomasecasas tabuleiro;

    // �ndice deste jogador (0, 1, 2 ou 3)
    public int indiceJogador;

    // Array para armazenar as posi��es f�sicas das casas no tabuleiro
    private Vector3[] posicoesTabuleiro;

    // Flag para controlar se o jogador j� se moveu no turno atual
    private bool podeMover = true;

    private void Start()
    {
        // Inicializa as posi��es no tabuleiro, assumindo que h� 20 casas
        posicoesTabuleiro = new Vector3[20];

        // Definindo posi��es f�sicas para cada casa no tabuleiro
        for (int i = 0; i < posicoesTabuleiro.Length; i++)
        {
            posicoesTabuleiro[i] = new Vector3(i * 2.0f, 0, 0); // Exemplo: posicionando em linha reta
        }

        // Inicializa o jogador na posi��o inicial
        AtualizarPosicaoVisual(tabuleiro.posicoesJogadores[indiceJogador]);
    }

    private void Update()
    {
        // Verifica se o jogador pressiona a tecla "Espa�o" e se pode se mover
        if (Input.GetKeyDown(KeyCode.Space) && podeMover)
        {
            // Simula um turno do jogador ao pressionar "Espa�o"
            Turno();
            podeMover = false; // Desativa o movimento at� o pr�ximo turno
        }

        // Exemplo: para resetar o movimento para testes, pressiona "R"
        if (Input.GetKeyDown(KeyCode.R))
        {
            podeMover = true; // Permite o jogador se mover novamente
        }
    }

    // M�todo para mover o jogador no tabuleiro
    public void Mover(int passos)
    {
        // Mover o jogador logicamente no tabuleiro
        tabuleiro.MoverJogador(indiceJogador, passos);

        // Atualiza a posi��o visual do jogador
        AtualizarPosicaoVisual(tabuleiro.posicoesJogadores[indiceJogador]);
    }

    // Atualiza a posi��o visual do jogador no jogo
    private void AtualizarPosicaoVisual(int novaPosicao)
    {
        // Verifica se a nova posi��o � v�lida
        if (novaPosicao >= 0 && novaPosicao < posicoesTabuleiro.Length)
        {
            // Define a posi��o do objeto do jogador no espa�o do jogo
            transform.position = posicoesTabuleiro[novaPosicao];
        }
    }

    // M�todo para simular o turno do jogador
    public void Turno()
    {
        // Gera um n�mero aleat�rio entre 1 e 6 para simular um dado
        int passos = Random.Range(1, 7);
        Debug.Log($"Jogador {indiceJogador + 1} rolou {passos} passos.");

        // Move o jogador de acordo com o n�mero de passos
        Mover(passos);
    }
}