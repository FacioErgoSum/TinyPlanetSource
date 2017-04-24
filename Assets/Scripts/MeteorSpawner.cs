using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {

    public GameObject[] spawnPoints;

    public GameObject meteor;

    public GameObject instantiate;

    public float spawnTimer = 2f;

    public float direction = 1f;

    public float speed = 100f;

    public float randomSize;

    public int point;
	
	void Update () {
        spawnTimer -= Time.deltaTime;
        randomSize = Random.Range(.05f, .1f);
        if (spawnTimer < 0) {
            point = Random.Range(0, 2);
            instantiate = Instantiate(meteor, new Vector3(spawnPoints[point].transform.position.x, spawnPoints[point].transform.position.y, -5), Quaternion.identity);
            instantiate.transform.localScale = new Vector3(randomSize, randomSize, 1);
            instantiate.GetComponent<Rigidbody2D>().AddForce(Vector3.left * speed * direction);
            spawnTimer = Random.Range(2f, 4f);
        }
        
	}
}
