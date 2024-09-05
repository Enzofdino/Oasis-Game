using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadosJogador : MonoBehaviour
{
    // Referência ao script do movimento do jogador
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

    // Método para o jogador escolher quantas casas quer andar
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

    // Método para mover o jogador baseado na escolha
    private void MoverJogador(int passos)
    {
        // Move o jogador o número de casas escolhido
        movimentoJogador.Mover(passos);

        // Log para depuração
        Debug.Log($"Jogador escolheu andar {passos} passos.");

        // Desativa a escolha para passar o turno
        FindObjectOfType<Turnos>().PassarTurno(); // Passa o turno para o próximo jogador
        podeEscolher = false; // Desativa a escolha até o próximo turno
    }

    // Método para permitir uma nova escolha (pode ser chamado externamente)
    public void PermitirNovaEscolha()
    {
        podeEscolher = true;
    }
}
