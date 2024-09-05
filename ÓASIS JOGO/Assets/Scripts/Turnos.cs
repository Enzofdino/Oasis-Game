using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turnos : MonoBehaviour
{
    // Refer�ncia ao script do movimento dos jogadores
    public Playermovimento[] jogadores;

    // �ndice do jogador atual
    private int jogadorAtualIndex = 0;

    // Refer�ncia ao script de dados para o controle de escolha de passos
    private DadosJogador dadosJogador;

    private void Start()
    {
        // Inicializa a refer�ncia ao script de dados (assumindo que est� no mesmo GameObject)
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

        // Permite que o jogador atual escolha o n�mero de passos
        dadosJogador.PermitirNovaEscolha();
    }

    // Passa o turno para o pr�ximo jogador
    public void PassarTurno()
    {
        // Avan�a para o pr�ximo jogador
        jogadorAtualIndex = (jogadorAtualIndex + 1) % jogadores.Length;

        // Atualiza o jogador ativo e reinicia a escolha
        AtualizarJogadorAtivo();
    }
}
