using System.Collections; // Importa o namespace para usar coleções como IEnumerator.
using System.Collections.Generic; // Importa o namespace para usar coleções genéricas.
using UnityEngine; // Importa o namespace do Unity, que contém classes fundamentais.

public class SpawnManager : MonoBehaviour // Define a classe SpawnManager que herda de MonoBehaviour.
{
    [SerializeField] // Permite que o campo seja editado no Inspector do Unity.
    private GameObject[] spawnObjects; // Array para armazenar os objetos que serão gerados.

    [SerializeField] // Permite que o campo seja editado no Inspector do Unity.
    public GameObject arCamera; // Referência à câmera AR (Realidade Aumentada).

    // Start é chamado antes do primeiro frame update.
    void Start()
    {
       // StartCoroutine(SpawnObjects()); // Inicia a coroutine que gera os objetos.
    }
    public void StartSpawn()
    {
        StartCoroutine(SpawnObjects());
    }

    // Coroutine que gera objetos no cenário.
    IEnumerator SpawnObjects()
    {
        GameObject balloon; // Variável para armazenar a referência ao balão gerado.

        // Calcula uma posição aleatória à frente da câmera principal.
        Vector3 pos = Camera.main.transform.position + Camera.main.transform.forward * Random.Range(4, 8);
        pos.y -= 1; // Ajusta a altura da posição para ser um pouco mais baixa.

        yield return new WaitForSeconds(4); // Espera 4 segundos antes de gerar os balões.

        // Gera o balão central.
        balloon = Instantiate(spawnObjects[0], pos, Quaternion.identity);

        // Gera o balão à esquerda do central.
        balloon = Instantiate(spawnObjects[1], pos, Quaternion.identity);
        balloon.transform.Translate(Camera.main.transform.right * -2); // Move para a esquerda.

        // Gera o balão à direita do central.
        balloon = Instantiate(spawnObjects[2], pos, Quaternion.identity);
        balloon.transform.Translate(Camera.main.transform.right * 2); // Move para a direita.

        if (GameManager.start) StartCoroutine(SpawnObjects()); // Reinicia a coroutine para gerar mais balões.
    }
}