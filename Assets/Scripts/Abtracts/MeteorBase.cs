using UnityEngine;

public abstract class MeteorBase: MonoBehaviour
{
    protected int hitCount = 0;
    protected abstract int health {get;}
    protected abstract int speed {get;}
    protected GameManager gameManager;

    protected  virtual void awake()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().meteorCount++;
    }
    
    protected virtual void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 2f);

        if (transform.position.y < -11f)
        {
            Destroy(this.gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            gameManager.gameOver = true;
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        } else if (whatIHit.tag == "Laser")
        {
            hitCount++;
            Destroy(whatIHit.gameObject);
        }
        if (hitCount >= health)
        {
            Destroy(this.gameObject);
            gameManager.meteorCount++;
        }
    }
}
