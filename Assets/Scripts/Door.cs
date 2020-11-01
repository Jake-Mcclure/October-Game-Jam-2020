using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private GameObject thePlayer;
    [SerializeField] private Sprite open;
    private bool loadingNextLevel = false;

    // Use this for initialization
    void Start()
    {
        thePlayer = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Open();
    }

    private void Open()
    {
        if (gameObject.GetComponent<BoxCollider2D>().IsTouching(thePlayer.GetComponent<Collider2D>()))
        {
            if (!loadingNextLevel) {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = open;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                } 
            }
        }
    }
}
