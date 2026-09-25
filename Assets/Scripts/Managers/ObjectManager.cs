using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public int meteorCount = 0;
    public GameObject playerPrefab;
    public GameObject meteorPrefab;
    public GameObject bigMeteorPrefab;
    public static ObjectManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
    {
        Destroy(gameObject);
        return;
    }
    Instance = this;
    }

    void Start()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        InvokeRepeating("SpawnMeteor", 1f, 2f);
    }

    void Update()
    {
        if (meteorCount == 5)
        {
            BigMeteor();
        }
    }
    void SpawnMeteor()
    {
        Instantiate(meteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
    }

    void BigMeteor()
    {
        meteorCount = 0;
        Instantiate(bigMeteorPrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.identity);
    }
}
