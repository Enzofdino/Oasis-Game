using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turnos : MonoBehaviour
{
    // Referência ao script do movimento dos jogadores
    public Playermovimento[] jogadores;

    // Índice do jogador atual
    private int jogadorAtualIndex = 0;

    // Referência ao script de dados para o controle de escolha de passos
    private DadosJogador dadosJogador;

    private void Start()
    {
        // Inicializa a referência ao script de dados (assumindo que está no mesmo GameObject)
        dadosJogador = GetComponent<DadosJogador>();

        // Configura o primeiro jogador como ativo
        AtualizarJogadorAtivo();
    }

    private void Update()
    {
        // Verifica se o jogador atual terminou sua rodada e passa o turno
        if (!dadosJogador.podeEscolher)
        {
            PassarTurno();
        }
    }

    // Atualiza o jogador ativo
    private void AtualizarJogadorAtivo()
    {
        for (int i = 0; i < jogadores.Length; i++)
        {
            jogadores[i].gameObject.SetActive(i == jogadorAtualIndex);
        }

        // Permite que o jogador atual escolha o número de passos
        dadosJogador.PermitirNovaEscolha();
    }

    // Passa o turno para o próximo jogador
    public void PassarTurno()
    {
        // Avança para o próximo jogador
        jogadorAtualIndex = (jogadorAtualIndex + 1) % jogadores.Length;

        // Atualiza o jogador ativo e reinicia a escolha
        AtualizarJogadorAtivo();
    }
}
