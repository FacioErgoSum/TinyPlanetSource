using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FertController : MonoBehaviour {

    public GameObject Fertilizer;

    public float fertLvl = 0;

    public float time = 2f; 

    public static Color lerpedColor = Color.white;

    void Start() {
        Fertilizer = GameObject.FindGameObjectWithTag("Text4");
        PlayerController.fuelCount += 50;
    }

    void Update() {
        time -= Time.deltaTime;

        lerpedColor = Color.Lerp(new Color(.953f, .651f, .333f, 1f), new Color(.451f, .722f, .553f, 1f), fertLvl / 100f);

        Fertilizer.GetComponent<Text>().text = fertLvl.ToString() + "%";

        if (time < 0) {
            if (PlayerController.fuelCount > 0) {
                PlayerController.fuelCount -= 1;
                if (fertLvl < 100.5) {
                    fertLvl += .5f;
                }
                
            }
            time = 2f;
        }

    }
}
