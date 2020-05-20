using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadMovement : MonoBehaviour
{
    Vector3 mousePosition;
    Rigidbody2D rb;
    Vector2 direction;
    [SerializeField]
    [Tooltip("Speed")]
    float speed;
    float xOffset;
    [SerializeField]
    GameManager gm;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xOffset = 2f;
    }

    void Update()
    {
        if (gm.GetIsGameOver()) return;

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        direction = (mousePosition - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * speed, 0);
    }
}
