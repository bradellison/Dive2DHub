using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ShellDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text shellText;

    PlayerLevelManager player;
    // Update is called once per frame

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLevelManager>();
        shellText.text = ($"Shells: {player.currentShellCount.ToString()}");
    }

    void Update()
    {
        shellText.text = ($"Shells: {player.currentShellCount.ToString()}");
    }
}
