using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoistGenController : MonoBehaviour {

    public GameObject Moisture;

    public float moistLvl = 0;

    public float time = 2f;

    void Start() {
        Moisture = GameObject.FindGameObjectWithTag("Text3");
        PlayerController.fuelCount += 50;
    }

    void Update() {
        time -= Time.deltaTime;

        Moisture.GetComponent<Text>().text = moistLvl.ToString() + "%";

        if (time < 0) {
            if (PlayerController.fuelCount > 0) {
                PlayerController.fuelCount -= 1;
                if (moistLvl < 100.5) {
                    moistLvl += .5f;
                }
                
            }
            time = 2f;
        }

    }
}
