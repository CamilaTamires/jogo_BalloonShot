using System.Collections; // Importa o namespace para usar cole��es como IEnumerator.
using System.Collections.Generic; // Importa o namespace para usar cole��es gen�ricas.
using UnityEngine; // Importa o namespace do Unity, que cont�m classes fundamentais.

public class Shoot : MonoBehaviour // Define a classe Shoot que herda de MonoBehaviour.
{
    [SerializeField] // Permite que o campo seja editado no Inspector do Unity.
    private GameObject smoke; // Refer�ncia ao prefab de fuma�a que ser� instanciado.

    private AudioSource audioSource; // Refer�ncia para o componente AudioSource.

    // Start � chamado antes do primeiro frame update.
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Obt�m o componente AudioSource do objeto atual.
    }

    // Update � chamado uma vez por frame.
    void Update()
    {
        TouchShoot(); // Chama a fun��o que verifica o toque na tela.
    }

    // M�todo para detectar toques e executar a��es.
    public void TouchShoot()
    {
        
        if (Input.touchCount == 0 || GameManager.start == false) return; 
        // Se n�o houver toques, sai do m�todo.

        RaycastHit hit; // Estrutura para armazenar informa��es sobre o objeto atingido pelo raio.

        // Verifica se o usu�rio tocou a tela.
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Lan�a um raio a partir da posi��o da c�mera, na dire��o em que est� olhando.
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                // Verifica se o objeto atingido tem a tag "Balloon".
                if (hit.transform.tag == "Balloon")
                {
                    audioSource.Play(); // Toca o som.
                    Destroy(hit.transform.gameObject); // Destroi o bal�o atingido.
                    // Instancia o efeito de fuma�a na posi��o de impacto, orientado pela normal do objeto.
                    Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));

                    //atualizo o score
                    GameManager.IncScore(10);
                    GameManager.IncTimer(10);

                }
            }
        }
    }
}