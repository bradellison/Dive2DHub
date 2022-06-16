using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class AirLevelDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text airLevel;

    PlayerLevelManager player;
    // Update is called once per frame

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLevelManager>();
        airLevel.text = ($"Level {player.levelOxygenMaxCapacity.ToString("F0")}");
    }

    void Update()
    {
        airLevel.text = ($"Level {player.levelOxygenMaxCapacity.ToString("F0")}");
    }
}
