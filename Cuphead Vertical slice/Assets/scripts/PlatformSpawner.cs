using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab; // Prefab de la plataforma
    [SerializeField] private int platformsPerRound = 4; // Número de plataformas por ronda
    [SerializeField] private float spawnInterval = 2f; // Intervalo entre rondas
    [SerializeField] private Vector2 spawnRangeX = new Vector2(-5, 5); // Rango en X para el spawn
    [SerializeField] private Vector2 spawnRangeY = new Vector2(-3, 3); // Rango en Y para el spawn
    [SerializeField] private float minDistance = 2f; // Distancia mínima entre plataformas

    private List<GameObject> activePlatforms = new List<GameObject>(); // Lista de plataformas activas

    private void Start()
    {
        StartCoroutine(SpawnPlatforms());
    }

    private IEnumerator SpawnPlatforms()
    {
        while (true)
        {
            foreach (GameObject platform in activePlatforms)
            {
                if (platform != null)
                {
                    platform platformScript = platform.GetComponent<platform>();
                    if (platformScript != null)
                    {
                        platformScript.Die(); 
                    }
                }
            }

            // Limpiar la lista de plataformas activas
            activePlatforms.Clear();

            // Generar nuevas plataformas
            for (int i = 0; i < platformsPerRound; i++)
            {
                Vector2 spawnPosition;
                int attempts = 0;
                do
                {
                    // Intentar generar una posición válida
                    float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);
                    float randomY = Random.Range(spawnRangeY.x, spawnRangeY.y);
                    spawnPosition = new Vector2(randomX, randomY);
                    attempts++;
                } while (!IsPositionValid(spawnPosition) && attempts < 10); // Evitar bucles infinitos

                // Instanciar la plataforma si se encuentra una posición válida
                GameObject newPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
                activePlatforms.Add(newPlatform);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private bool IsPositionValid(Vector2 position)
    {
        foreach (GameObject platform in activePlatforms)
        {
            if (platform == null) continue; // Ignorar plataformas destruidas
            float distance = Vector2.Distance(position, platform.transform.position);
            if (distance < minDistance) return false; // Demasiado cerca de otra plataforma
        }
        return true;
    }
}
