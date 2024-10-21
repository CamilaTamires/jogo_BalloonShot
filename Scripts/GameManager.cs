using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Biblioteca para manipulação de texto com o TextMeshPro
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variáveis estáticas para controlar o estado do jogo
    static float score = 0; // Armazena a pontuação do jogador
    static float timer = 0; // Armazena o tempo restante
    public static bool start = false; // Indica se o jogo está em andamento

    // Método para incrementar a pontuação
    public static void IncScore(int points)
    {
        GameManager.score += points; // Adiciona pontos à pontuação total
    }

    // Método para incrementar o timer
    public static void IncTimer(int time)
    {
        GameManager.timer += time; // Adiciona tempo ao timer total
    }

    // Método para verificar se o jogo começou (apenas para demonstração)
    public static bool GameStart()
    {
        return GameManager.start; // Retorna o estado do jogo (iniciado ou não)
    }

    // Referências para o HUD (Heads-Up Display)
    public TextMeshProUGUI scoreText, scoreTextGO, timerText;
    public GameObject GameMenu, GameOverMenu, StartMenu;

    // Método chamado ao iniciar o jogo
    void Start()
    {
        //StartGame(); // Inicia o jogo chamando o método StartGame
    }

    // Método chamado a cada frame
    void Update()
    {
        // Se o jogo não tiver começado, não faz nada
        if (GameManager.start == false) { return; }

        // Atualiza o timer e o HUD
        GameManager.timer -= Time.deltaTime; // Decrementa o timer baseado no tempo decorrido desde o último frame
        timerText.text = "TIMER: " + ((int)GameManager.timer).ToString(); // Atualiza o texto do timer na tela
        scoreText.text = "SCORE: " + GameManager.score.ToString(); // Atualiza o texto da pontuação na tela

        // Verifica se o timer chegou a zero e para o jogo
        if (GameManager.timer <= 0)
        {
            GameManager.start = false; // Para o jogo
            GameManager.timer = 0; // Garante que o timer não fique negativo
            GameMenu.SetActive(false);
            GameOverMenu.SetActive(true);
            scoreTextGO.text = "SCORE: " + GameManager.score.ToString(); // Atualiza o texto da pontuação na tela
            Invoke ("restartGame", 5f);
        }
    }
     public void restartGame()
    {
        SceneManager.LoadScene(0);
    }


    // Método para iniciar o jogo
    public void StartGame()
    {
        GameManager.score = 0; // Reseta a pontuação
        GameManager.timer = 10; // Define o tempo inicial
        GameManager.start = true; // Indica que o jogo começou
        StartMenu.SetActive(false);
        GameMenu.SetActive(true);
        GameObject.Find("SpawnManager").GetComponent<SpawnManager>().StartSpawn();


    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
