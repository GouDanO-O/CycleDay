using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    private GameObject player;

     private GameObject kunKun;

    private Vector3 direction;

    private float speed = 5f;

    private float lifeTime = 5f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        kunKun = GameObject.FindWithTag("KunKun");
    }
    private void Update()
    {
        direction = kunKun.transform.localScale;
        BallMove();
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void BallMove()
    {
        if (kunKun.transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(direction.x, direction.y, direction.z);
            transform.position += speed * transform.right * Time.deltaTime;
        }
        else if (kunKun.transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-direction.x, direction.y, direction.z);
            transform.position += speed * -transform.right * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag=="Player")
        {
            Destroy(gameObject);
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.transform.localScale.x, 0));
        }
        else if(collision.gameObject.layer==6)
        {
            Destroy(gameObject);
        }
    }
}
