using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject laserPrefab;

    //take in references to payer input actions
    public InputActionReference moveAction;
    public InputActionReference fireAction;

    private float speed = 6f;
    private bool canShoot = true;


    // Update is called once per frame
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        //replace old input value check with new input system 
        transform.Translate((Vector3)moveAction.action.ReadValue<Vector2>() * Time.deltaTime * speed);
        if (transform.position.x > GameManager.Instance.horizontalScreenLimit || transform.position.x <= -GameManager.Instance.horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1f, transform.position.y, 0);
        }
        if (transform.position.y > GameManager.Instance.verticalScreenLimit || transform.position.y <= -GameManager.Instance.verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }
    }

    void Shooting()
    {
        //replace old input Input.GetKey with new input check for if an action was fired
        if (fireAction.action.WasPressedThisFrame() && canShoot)
        {
            Instantiate(laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            canShoot = false;
            StartCoroutine(Cooldown());
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(0.25f);
        canShoot = true;
    }
}