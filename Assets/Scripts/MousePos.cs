using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePos : MonoBehaviour {

    public static int zPos = 0;
    public float xBoundary = 7.5f;
    public float speed = 10f;

    private LineRenderer lr;

    public GameObject Player;
    public GameObject Mouse;

    void Start() {
        lr = GetComponent<LineRenderer>();
    }

    void Update() {

        Player = GameObject.FindGameObjectWithTag("Player");

        Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zPos - Camera.main.transform.position.z);
        mouse = Camera.main.ScreenToWorldPoint(mouse);

        this.transform.position = new Vector3(mouse.x, mouse.y, zPos);

        Vector3[] positions = new Vector3[2];
        positions[0] = Player.transform.position;
        positions[1] = Mouse.transform.position;

        lr.numPositions = positions.Length;
        lr.SetPositions(positions);

        Vector2[] points = new Vector2[2];
        points[0] = positions[0];
        points[1] = positions[1];
    }
}

