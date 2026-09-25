using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool gameOver = false;
    public float horizontalScreenLimit {get; private set;} = 10f;
    public float verticalScreenLimit {get; private set;} = 6f;

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

    }

    void Update()
    {
        if (gameOver)
        {
            ObjectManager.Instance.CancelInvoke();
        }

        if (Input.GetKeyDown(KeyCode.R) && gameOver)
        {
            SceneManager.LoadScene("Week5Lab");
        }

    }

}
