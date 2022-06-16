using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DepthDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text depthText;

    PlayerController player;
    // Update is called once per frame

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        depthText.text = ($"Depth: {player.currentDepth.ToString("F1")}m");
    }

    void Update()
    {
        depthText.text = ($"Depth: {player.currentDepth.ToString("F1")}m");
    }
}
