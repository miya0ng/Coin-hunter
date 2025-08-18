using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject obstaclePrefab;
    public GameObject plane;
    public float spawnRateMin, spawnRateMax;
    public float spawnTimer;
    public float interval = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            Vector3 spawnPos = plane.transform.position + new Vector3(x, 80f, z);

            Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
            spawnTimer = 0;
        }
    }
}
