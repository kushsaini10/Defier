using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public Rigidbody rb;
    public Transform player;
    public float enemyMovementOffset = 0.2f;
    public float speed = 0.2f;
    public float Damping = 6.0f;
    GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Move()
    {
        if (rb.IsSleeping())
        {
            rb.WakeUp();
        }
        if (transform.position != player.position)
        {
            Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!gameManager.IsGamePaused())
        {
            if (transform.position.x >= 25.1f || transform.position.z >= 25.1f || transform.position.x <= -25.1f || transform.position.z <= -25.1f){
                gameManager.enemyCount = gameManager.enemyCount - 1;
                Destroy(gameObject);
            }
            else
                Move();
        }
        else
        {
            if (!rb.IsSleeping())
            {
                rb.Sleep();
            }
        }
    }
}
