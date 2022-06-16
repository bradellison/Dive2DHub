using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerController player;
    private PlayerLevelManager playerLevelManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = this.gameObject.GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerLevelManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLevelManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (player.isUnderwater) {
                if (player.isCollidingWithFish) { 
                    player.AddToInventory();
                }
            } else {
                gameManager.ToggleShopCanvas(); 
            }
        } 

        if (Input.GetKeyDown(KeyCode.M)) {
            playerLevelManager.currentShellCount += 100;
        }

    }
}
