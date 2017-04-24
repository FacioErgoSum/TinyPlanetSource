using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private bool spawned = false;

    public int speed = 100;

    public GameObject MousePosition;

    public GameObject AtmosphereGenerator;

    public GameObject MoistureGenerator;

    public GameObject Fertilizer;

    private Rigidbody2D RB;

    public int chunkCount = 0;

    public static int fuelCount = 0;

    public Text oreCount;

    public Text lifeSupport;

    public float lifeLevel = 100;

    public float lifeTimer = 1f;

    public static bool atmoGen = false;

    public static bool moistGen = false;

    public static bool fertGen = false;

    public static bool started = false;

    public static bool ended = false;

    void Start() {
        RB = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (!started || ended) {
            RB.constraints = RigidbodyConstraints2D.FreezePositionX;
            RB.constraints = RigidbodyConstraints2D.FreezePositionY;
        } else {
            RB.constraints = RigidbodyConstraints2D.None;
        }
        lifeTimer -= Time.deltaTime;

        if (lifeTimer < 0) {
            if (lifeLevel > 0 && lifeLevel < 100.5) {
                if (atmoGen && moistGen && fertGen) {
                    lifeLevel += .5f;
                    lifeTimer = 5f;
                } else if (atmoGen && moistGen && !fertGen) {
                    lifeLevel += 0f;
                    lifeTimer = 3f;
                } else if (atmoGen && !moistGen && !fertGen) {
                    lifeLevel--;
                    lifeTimer = 2f;
                } else if (!atmoGen && !moistGen && !fertGen) {
                    lifeLevel--;
                    lifeTimer = 1f;
                }
            }
        }

        lifeSupport.text = lifeLevel.ToString() + "%";

        if (lifeLevel < 0) {
            lifeSupport.text = "0%";
        }

        oreCount.text = chunkCount.ToString();

        //Gun Controls
        if (Input.GetMouseButtonDown(0)) {
            if (!spawned) {
                Instantiate(MousePosition);
                spawned = true;
                Debug.Log("Spawned");
            }
        }

        if (Input.GetMouseButtonUp(0)) {
                Destroy(GameObject.FindGameObjectWithTag("Position"));
                spawned = false;
                Debug.Log("Despawned");
        }

        if (started) {
            //Movement Controls
            if (Input.GetKey(KeyCode.W)) {
                RB.AddForce(Vector3.up * 100 * Time.smoothDeltaTime);
            }

            if (Input.GetKey(KeyCode.A)) {
                RB.AddForce(Vector3.left * 100 * Time.smoothDeltaTime);
            }

            if (Input.GetKey(KeyCode.S)) {
                RB.AddForce(Vector3.down * 100 * Time.smoothDeltaTime);
            }

            if (Input.GetKey(KeyCode.D)) {
                RB.AddForce(Vector3.right * 100 * Time.smoothDeltaTime);
            }

        }

    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "oreChunk") {
            Destroy(col.gameObject);
            chunkCount++;
        }
    }

    void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.tag == "Workbench") {
            if (Input.GetKey(KeyCode.E)) {
                if (chunkCount > 19) {
                    if (!atmoGen) {
                        Instantiate(AtmosphereGenerator);
                        chunkCount -= 20;
                        atmoGen = true;
                    }
                }
                if (chunkCount > 39) {
                    if (atmoGen && !moistGen) {
                        Instantiate(MoistureGenerator);
                        chunkCount -= 40;
                        moistGen = true;
                    }
                }
                if (chunkCount > 79) {
                    if (atmoGen && moistGen && !fertGen) {
                        Instantiate(Fertilizer);
                        chunkCount -= 80;
                        fertGen = true;
                    }
                }

            }
            if (Input.GetKey(KeyCode.Space)) {
                fuelCount += chunkCount;
                chunkCount = 0;
            }
        }
    }
    public void StartGame() {
        started = true;
    }
}
