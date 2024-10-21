using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Biblioteca para manipula��o de texto com o TextMeshPro
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Vari�veis est�ticas para controlar o estado do jogo
    static float score = 0; // Armazena a pontua��o do jogador
    static float timer = 0; // Armazena o tempo restante
    public static bool start = false; // Indica se o jogo est� em andamento

    // M�todo para incrementar a pontua��o
    public static void IncScore(int points)
    {
        GameManager.score += points; // Adiciona pontos � pontua��o total
    }

    // M�todo para incrementar o timer
    public static void IncTimer(int time)
    {
        GameManager.timer += time; // Adiciona tempo ao timer total
    }

    // M�todo para verificar se o jogo come�ou (apenas para demonstra��o)
    public static bool GameStart()
    {
        return GameManager.start; // Retorna o estado do jogo (iniciado ou n�o)
    }

    // Refer�ncias para o HUD (Heads-Up Display)
    public TextMeshProUGUI scoreText, scoreTextGO, timerText;
    public GameObject GameMenu, GameOverMenu, StartMenu;

    // M�todo chamado ao iniciar o jogo
    void Start()
    {
        //StartGame(); // Inicia o jogo chamando o m�todo StartGame
    }

    // M�todo chamado a cada frame
    void Update()
    {
        // Se o jogo n�o tiver come�ado, n�o faz nada
        if (GameManager.start == false) { return; }

        // Atualiza o timer e o HUD
        GameManager.timer -= Time.deltaTime; // Decrementa o timer baseado no tempo decorrido desde o �ltimo frame
        timerText.text = "TIMER: " + ((int)GameManager.timer).ToString(); // Atualiza o texto do timer na tela
        scoreText.text = "SCORE: " + GameManager.score.ToString(); // Atualiza o texto da pontua��o na tela

        // Verifica se o timer chegou a zero e para o jogo
        if (GameManager.timer <= 0)
        {
            GameManager.start = false; // Para o jogo
            GameManager.timer = 0; // Garante que o timer n�o fique negativo
            GameMenu.SetActive(false);
            GameOverMenu.SetActive(true);
            scoreTextGO.text = "SCORE: " + GameManager.score.ToString(); // Atualiza o texto da pontua��o na tela
            Invoke ("restartGame", 5f);
        }
    }
     public void restartGame()
    {
        SceneManager.LoadScene(0);
    }


    // M�todo para iniciar o jogo
    public void StartGame()
    {
        GameManager.score = 0; // Reseta a pontua��o
        GameManager.timer = 10; // Define o tempo inicial
        GameManager.start = true; // Indica que o jogo come�ou
        StartMenu.SetActive(false);
        GameMenu.SetActive(true);
        GameObject.Find("SpawnManager").GetComponent<SpawnManager>().StartSpawn();


    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
