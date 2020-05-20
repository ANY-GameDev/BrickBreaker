using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    [Tooltip("Speed")]
    float speed;
    [SerializeField]
    [Tooltip("Number of lives to decrease after the ball is falling")]
    int cost;
    [SerializeField]
    GameManager gm;
    Vector3 offset;
    bool isInPlay;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        offset = new Vector3(0, 0.5f, 0);
        isInPlay = false;
    }

    void Update()
    {
        if (gm.GetIsGameOver()) return;

        if (!isInPlay)
        {
            transform.position = GameObject.FindGameObjectWithTag("player").transform.position + offset;
            if (Input.GetMouseButtonDown(0))
            {
                isInPlay = true;
                rb.AddForce(Vector2.up);
            }
        }
    }

    void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ground"))
        {
            gm.UpdateLives(cost);
            rb.velocity = Vector2.zero;
            isInPlay = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("brick"))
        {
            BrickScript bs = other.gameObject.GetComponent<BrickScript>();
            if (bs.GetHitsToBreak() > 1)
            {
                bs.BrickBreak();
            }
            else
            {
                gm.UpdateScore(bs.GetPoints());
                Destroy(other.gameObject);
            }
        }
        if (other.transform.CompareTag("player"))
        {
            Vector3 vec = transform.position - other.transform.position;
            rb.velocity = vec.normalized * speed;
        }
    }
}
