using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

    private Rigidbody2D RB;

    public GameObject Player;

    public GameObject oreChunk;

    private GameObject chunk;

    public GameObject explosion;

    public int speed = 6;

    void Start() {
        RB = GetComponent<Rigidbody2D>();
    }

    void Update() {

    }

    void OnTriggerStay2D(Collider2D col) {

        RB.AddForce((Player.transform.position - transform.position) * speed * Time.smoothDeltaTime);

        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Meteor") {
            chunk = Instantiate(oreChunk, transform.position, transform.rotation);
            chunk.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity + Vector2.left;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Border") {
            Destroy(gameObject);
        }
    }
}
