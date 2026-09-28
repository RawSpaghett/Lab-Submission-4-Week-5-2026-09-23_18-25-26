using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [Header("Orbit Settings")]
    [SerializeField] private float radius = 5f;
    [SerializeField] private float orbitSpeed = 2f;

    private float orbitAngle;

    void Start()
    {
        Vector2 offset = transform.position - player.transform.position; 
        orbitAngle = Mathf.Atan2(offset.y, offset.x);

        radius = Random.Range(2f, 6f);
        orbitSpeed = Random.Range(1f, 2f);
    }

    void FixedUpdate()
    {
        LookAt();
        Circle();
    }

    private void LookAt()
    {
        Vector2 direction = player.transform.position - transform.position; //Step 1: gets direction

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; //Step 2: Calculate angle in radians via rise-over-run with Atan, and calculate back to degrees for actual transformation, subtract 90 degrees for the sprite

        transform.rotation = Quaternion.Euler(0f, 0f, angle); //Step 3:  Apply transformation
    }

    private void Circle()
    {
        float x = Mathf.Cos(orbitAngle) * radius;
        float y = Mathf.Sin(orbitAngle) * radius;

        transform.position = player.transform.position + new Vector3(x, y, 0f); // center orbit center on player at all times

        orbitAngle += orbitSpeed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser")) // destroy enemy and laser upon contact with each other
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}