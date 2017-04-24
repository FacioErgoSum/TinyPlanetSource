using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidFunctions : MonoBehaviour {
    public SpriteRenderer planetRend;

    void Start() {
        planetRend = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (PlayerController.fertGen) {
            planetRend.color = FertController.lerpedColor;
        }
    }
}
