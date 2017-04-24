using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject Player;
    private Vector3 camPos;
    public GameObject canvasRend;
    public GameObject titleRend;

    void Update() { 
        if (!PlayerController.started) {
            camPos = new Vector3(-10, 3, -10);
            canvasRend.SetActive(PlayerController.started);
            titleRend.SetActive(!PlayerController.started);
        } else {
            camPos = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);
            gameObject.transform.position = Vector3.MoveTowards(transform.position, camPos, .15f);
            canvasRend.SetActive(PlayerController.started);
            titleRend.SetActive(!PlayerController.started);
        }
    }
}
