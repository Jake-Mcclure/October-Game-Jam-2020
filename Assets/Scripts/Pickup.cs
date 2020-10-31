using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Pickup : MonoBehaviour
{
    private float y0;
    public int score;
    [SerializeField] private float amplitude;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        y0 = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, y0 + amplitude * Mathf.Sin(speed * Time.time));
    }
}
