using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 8f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if (transform.position.y > GameManager.Instance.verticalScreenLimit)
        {
            Destroy(this.gameObject);
        }
    }
}
