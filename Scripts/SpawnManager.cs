using System.Collections; // Importa o namespace para usar cole��es como IEnumerator.
using System.Collections.Generic; // Importa o namespace para usar cole��es gen�ricas.
using UnityEngine; // Importa o namespace do Unity, que cont�m classes fundamentais.

public class SpawnManager : MonoBehaviour // Define a classe SpawnManager que herda de MonoBehaviour.
{
    [SerializeField] // Permite que o campo seja editado no Inspector do Unity.
    private GameObject[] spawnObjects; // Array para armazenar os objetos que ser�o gerados.

    [SerializeField] // Permite que o campo seja editado no Inspector do Unity.
    public GameObject arCamera; // Refer�ncia � c�mera AR (Realidade Aumentada).

    // Start � chamado antes do primeiro frame update.
    void Start()
    {
       // StartCoroutine(SpawnObjects()); // Inicia a coroutine que gera os objetos.
    }
    public void StartSpawn()
    {
        StartCoroutine(SpawnObjects());
    }

    // Coroutine que gera objetos no cen�rio.
    IEnumerator SpawnObjects()
    {
        GameObject balloon; // Vari�vel para armazenar a refer�ncia ao bal�o gerado.

        // Calcula uma posi��o aleat�ria � frente da c�mera principal.
        Vector3 pos = Camera.main.transform.position + Camera.main.transform.forward * Random.Range(4, 8);
        pos.y -= 1; // Ajusta a altura da posi��o para ser um pouco mais baixa.

        yield return new WaitForSeconds(4); // Espera 4 segundos antes de gerar os bal�es.

        // Gera o bal�o central.
        balloon = Instantiate(spawnObjects[0], pos, Quaternion.identity);

        // Gera o bal�o � esquerda do central.
        balloon = Instantiate(spawnObjects[1], pos, Quaternion.identity);
        balloon.transform.Translate(Camera.main.transform.right * -2); // Move para a esquerda.

        // Gera o bal�o � direita do central.
        balloon = Instantiate(spawnObjects[2], pos, Quaternion.identity);
        balloon.transform.Translate(Camera.main.transform.right * 2); // Move para a direita.

        if (GameManager.start) StartCoroutine(SpawnObjects()); // Reinicia a coroutine para gerar mais bal�es.
    }
}