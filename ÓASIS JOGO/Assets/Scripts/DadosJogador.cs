using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadosJogador : MonoBehaviour
{
    // Refer�ncia ao script do movimento do jogador
    public Playermovimento movimentoJogador;

    // Flag para controlar se o jogador pode escolher o movimento
    public bool podeEscolher = true;

    private void Update()
    {
        // Verifica se o jogador pode escolher quantas casas andar
        if (podeEscolher)
        {
            EscolherPassos();
        }
    }

    // M�todo para o jogador escolher quantas casas quer andar
    private void EscolherPassos()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MoverJogador(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MoverJogador(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MoverJogador(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            MoverJogador(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            MoverJogador(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            MoverJogador(6);
        }
    }

    // M�todo para mover o jogador baseado na escolha
    private void MoverJogador(int passos)
    {
        // Move o jogador o n�mero de casas escolhido
        movimentoJogador.Mover(passos);

        // Log para depura��o
        Debug.Log($"Jogador escolheu andar {passos} passos.");

        // Desativa a escolha para passar o turno
        FindObjectOfType<Turnos>().PassarTurno(); // Passa o turno para o pr�ximo jogador
        podeEscolher = false; // Desativa a escolha at� o pr�ximo turno
    }

    // M�todo para permitir uma nova escolha (pode ser chamado externamente)
    public void PermitirNovaEscolha()
    {
        podeEscolher = true;
    }
}
