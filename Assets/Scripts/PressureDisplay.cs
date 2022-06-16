using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PressureDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text pressureText;

    PlayerController player;
    // Update is called once per frame

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        pressureText.text = ($"Pressure: {player.currentPressure.ToString("F1")} ATA");
    }

    void Update()
    {
        pressureText.text = ($"Pressure: {player.currentPressure.ToString("F1")} ATA");
    }
}
