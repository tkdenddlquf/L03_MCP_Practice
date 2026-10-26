using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Rigidbody obstaclePrefab;
    [SerializeField] private float interval = 3f;
    [SerializeField] private Vector2 areaHalfSize = new Vector2(4.5f, 4.5f);
    [SerializeField] private Vector2 heightRange = new Vector2(8f, 12f);

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer < interval) return;
        timer -= interval;
        Vector3 position = new Vector3(Random.Range(-areaHalfSize.x, areaHalfSize.x), Random.Range(heightRange.x, heightRange.y), Random.Range(-areaHalfSize.y, areaHalfSize.y));
        Instantiate(obstaclePrefab, transform.position + position, Quaternion.identity);
    }
}
