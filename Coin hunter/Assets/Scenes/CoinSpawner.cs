using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject plane;
    public float spawnRateMin, spawnRateMax;
    public float spawnTimer;
    public float interval = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var newCoin = Instantiate(coinPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        // interval = Random.Range(spawnRateMin, spawnRateMax);
        spawnTimer += Time.deltaTime;
        if (spawnTimer > interval)
        {
            Vector3 planeSize = plane.transform.localScale * 10f;
            float x = Random.Range(-planeSize.x / 2f, planeSize.x / 2f);
            float z = Random.Range(-planeSize.z / 2f, planeSize.z / 2f);
            Vector3 spawnPos = plane.transform.position + new Vector3(x, 0f, z);

            Instantiate(coinPrefab, spawnPos, Quaternion.identity);
            spawnTimer = 0;
        }
    }
}
