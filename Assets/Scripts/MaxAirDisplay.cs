using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MaxAirDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text maxAirText;

    PlayerLevelManager player;
    // Update is called once per frame

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLevelManager>();
        maxAirText.text = ($"Max Air Capacity: {player.oxygenMaxCapacity.ToString("F0")}");
    }

    void Update()
    {
        maxAirText.text = ($"Max Air Capacity: {player.oxygenMaxCapacity.ToString("F0")}");
    }
}
