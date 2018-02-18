using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Rigidbody rb;
    public float force = 500f;
    public float rotationSpeed = 0.5f;
    public Rigidbody bulletPrefab;
    public float bulletSpeed = 10;
    float timer;
    GameManager gameManager;
    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        Rigidbody bullet = Instantiate(
            bulletPrefab,
            transform.position,
            transform.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        // Destroy the bullet after 2 seconds
        Destroy(bullet.gameObject, 2.0f);
    }
    // Use this for initialization
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        timer = Time.time + 0.5f;
    }

    void Update()
    {
        if (!gameManager.IsGamePaused())
        {
           // Debug.Log("x = " + transform.position.x + ", z = " + transform.position.z);
            if (transform.position.x >= 26.0f || transform.position.z >= 26.0f || transform.position.x <= -26.0f || transform.position.z <= -26.0f)
            {
                gameManager.GameOver();
            }
            if (rb.IsSleeping())
                rb.WakeUp();
            if (Input.GetKey(KeyCode.Space))
            {
                if (timer < Time.time)
                {
                    Fire();
                    timer = Time.time + 1;
                }
            }
        }
        else
        {
            if (!rb.IsSleeping())
                rb.Sleep();
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        //Debug.Log(gameManager.gameOver.ToString());
        if (!gameManager.IsGamePaused() && !gameManager.IsGameOver())
        {
            if (Input.GetKey("d"))
            {
                rb.AddForce(force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            if (Input.GetKey("a"))
            {
                rb.AddForce(-force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            if (Input.GetKey("w"))
            {
                rb.AddForce(0, 0, force * Time.deltaTime, ForceMode.VelocityChange);
            }
            if (Input.GetKey("s"))
            {
                rb.AddForce(0, 0, -force * Time.deltaTime, ForceMode.VelocityChange);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

            if (Input.GetKey(KeyCode.RightArrow))
                transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);
            //if (rb.position.y < 1f)
            //    FindObjectOfType<GameManager>().EndGame();
        }
        else if (gameManager.IsGameOver())
            rb.Sleep();
    }
}
