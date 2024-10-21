using System.Collections; // Importa o namespace para usar cole��es como IEnumerator.
using System.Collections.Generic; // Importa o namespace para usar cole��es gen�ricas.
using UnityEngine; // Importa o namespace do Unity, que cont�m classes fundamentais.

public class MovieObject : MonoBehaviour // Define a classe MovieObject que herda de MonoBehaviour.
{
    [SerializeField] // Permite que o campo seja editado no Inspector do Unity.
    private float speed = 0.2f; // Velocidade com que o objeto se mover� para cima.

    // Start � chamado antes do primeiro frame update.
    void Start()
    {
        Destroy(gameObject, 20f); // Destroi o objeto ap�s 20 segundos.
    }

    // Update � chamado uma vez por frame.
    void Update()
    {
        // Move o objeto para cima (eixo Y) a uma velocidade determinada, com base no tempo do frame.
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}

