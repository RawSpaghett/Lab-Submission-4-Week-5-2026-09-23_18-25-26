using UnityEngine;

public abstract class MeteorBase: MonoBehaviour
{
    protected int hitCount = 0;
    protected abstract int health {get;}
    protected abstract int speed {get;}
    protected GameManager gameManager;
    protected ObjectManager objectManager;

    protected virtual void Awake()
    {
        objectManager = GameObject.Find("GameManager").GetComponent<ObjectManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    protected virtual void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (transform.position.y < -11f)
        {
            Destroy(this.gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.CompareTag("Player"))
        {
            Debug.Log($"Player Destroyed!");
            gameManager.gameOver = true;
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        } else if (whatIHit.CompareTag("Laser"))
        {
            hitCount++;
            Debug.Log($"Hit! Laser {hitCount}");
            Destroy(whatIHit.gameObject);
        }
        if (hitCount >= health)
        {
            Destroy(this.gameObject);
            Debug.Log($"Meteor Destroyed!");
            objectManager.meteorCount++;
        }
    }
}
