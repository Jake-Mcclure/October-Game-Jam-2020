using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// © 2017 TheFlyingKeyboard and released under MIT License
// theflyingkeyboard.net

public class CameraMovement : MonoBehaviour
{
    public float offset;
    public float speed;
    public bool isDragging;

    private GameObject player;
    private GameObject background;

    //x - min y - max
    public Vector2 minMaxXPosition;
    public Vector2 minMaxYPosition;

    private float screenWidth;
    private float screenHeight;
    private Vector3 cameraMove;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        background = GameObject.Find("Background");
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        cameraMove.x = transform.position.x;
        cameraMove.y = transform.position.y;
        cameraMove.z = transform.position.z;
        if (isDragging)
        {
            //Move camera
            if ((Input.mousePosition.x > screenWidth - offset) && transform.position.x < minMaxXPosition.y)
            {
                cameraMove.x += MoveSpeed();
            }

            if ((Input.mousePosition.x < offset) && transform.position.x > minMaxXPosition.x)
            {
                cameraMove.x -= MoveSpeed();
            }

            if ((Input.mousePosition.y > screenHeight - offset) && transform.position.y < minMaxYPosition.y)
            {
                cameraMove.y += MoveSpeed();
            }

            if ((Input.mousePosition.y < offset) && transform.position.y > minMaxYPosition.x)
            {
                cameraMove.y -= MoveSpeed();
            }

            transform.position = cameraMove;
        }
        if (!isDragging)
        {
            Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, -10), 100);
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        }
        background.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    float MoveSpeed()
    {
        return speed * Time.deltaTime;
    }
}