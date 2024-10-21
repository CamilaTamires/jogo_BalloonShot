using System.Collections; // Importa o namespace para usar coleções como IEnumerator.
using System.Collections.Generic; // Importa o namespace para usar coleções genéricas.
using UnityEngine; // Importa o namespace do Unity, que contém classes fundamentais.

public class Shoot : MonoBehaviour // Define a classe Shoot que herda de MonoBehaviour.
{
    [SerializeField] // Permite que o campo seja editado no Inspector do Unity.
    private GameObject smoke; // Referência ao prefab de fumaça que será instanciado.

    private AudioSource audioSource; // Referência para o componente AudioSource.

    // Start é chamado antes do primeiro frame update.
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Obtém o componente AudioSource do objeto atual.
    }

    // Update é chamado uma vez por frame.
    void Update()
    {
        TouchShoot(); // Chama a função que verifica o toque na tela.
    }

    // Método para detectar toques e executar ações.
    public void TouchShoot()
    {
        
        if (Input.touchCount == 0 || GameManager.start == false) return; 
        // Se não houver toques, sai do método.

        RaycastHit hit; // Estrutura para armazenar informações sobre o objeto atingido pelo raio.

        // Verifica se o usuário tocou a tela.
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Lança um raio a partir da posição da câmera, na direção em que está olhando.
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                // Verifica se o objeto atingido tem a tag "Balloon".
                if (hit.transform.tag == "Balloon")
                {
                    audioSource.Play(); // Toca o som.
                    Destroy(hit.transform.gameObject); // Destroi o balão atingido.
                    // Instancia o efeito de fumaça na posição de impacto, orientado pela normal do objeto.
                    Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));

                    //atualizo o score
                    GameManager.IncScore(10);
                    GameManager.IncTimer(10);

                }
            }
        }
    }
}