using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour {

    GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        //Debug.Log("TAG : " + collisionInfo.collider.tag);
        if(collisionInfo.collider.tag == "Enemy")
        {
            gameManager.enemyCount = gameManager.enemyCount-1;
            //Debug.Log(gameManager.enemyCount);
            Destroy(collisionInfo.collider.gameObject);
            Destroy(gameObject);
        }else if(collisionInfo.collider.tag == "Player")
        {
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), collisionInfo.collider);
        }
    }

    void Update()
    {
        if(transform.position.x >= 50.0f || transform.position.z >= 50.0f || transform.position.x <= -50.0f || transform.position.z <= -50.0f)
        {
            gameManager.enemyCount = gameManager.enemyCount - 1;
            Destroy(gameObject);
        }
    }
}
