using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtmosphereGenController : MonoBehaviour {

    public GameObject Fuel;
    public GameObject Atmosphere;

    public float atmosLvl = 0;

    public float time = 2f;

    void Start() {
        Fuel = GameObject.FindGameObjectWithTag("Text1");
        Atmosphere = GameObject.FindGameObjectWithTag("Text2");

        PlayerController.fuelCount += 50;
    }

	void Update () {
        time -= Time.deltaTime;

        Fuel.GetComponent<Text>().text = PlayerController.fuelCount.ToString();
        Atmosphere.GetComponent<Text>().text = atmosLvl.ToString() + "%";

        if(time < 0) {
            if (PlayerController.fuelCount > 0) {
                PlayerController.fuelCount -= 1;
                if (atmosLvl < 100.5) {
                    atmosLvl += .5f;
                }
                
            }
            time = 2f;
        }

	}
}
