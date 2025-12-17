using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public int coinCount = 120;
    public float groundOffset = 0.5f;

    private Terrain terrain;

    private void Start()
    {
        terrain = Terrain.activeTerrain;

        if (terrain == null)
        {
            Debug.LogError("No active Terrain found!");
            return;
        }

        SpawnCoins();
    }

    void SpawnCoins()
    {
        TerrainData data = terrain.terrainData;
        Vector3 terrainPos = terrain.transform.position;

        for (int i = 0; i < coinCount; i++)
        {
            float x = Random.Range(0f, data.size.x);
            float z = Random.Range(0f, data.size.z);

            float y = terrain.SampleHeight(new Vector3(x, 0f, z)) + terrainPos.y;

            Vector3 spawnPos = new Vector3(
                x + terrainPos.x,
                y + groundOffset,
                z + terrainPos.z
            );

            Instantiate(coinPrefab, spawnPos, Quaternion.identity);
        }
    }
}