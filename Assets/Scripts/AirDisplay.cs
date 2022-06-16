using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class AirDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text airText;

    PlayerController player;
    // Update is called once per frame

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        airText.text = ($"Air: {player.oxygenCurrentCapacity.ToString("F0")}");
    }

    void Update()
    {
        airText.text = ($"Air: {player.oxygenCurrentCapacity.ToString("F0")}");
    }
}
