using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject GameplayCanvasPrefab;
    private GameObject GameplayCanvas;
    public GameObject ShopCanvasPrefab;
    private GameObject ShopCanvas;

    public GameObject FishInventoryCanvasPrefab;
    private GameObject FishInventoryCanvas;

    public GameObject StartCanvasPrefab;
    private PlayerController player;

    void Start()
    {
        Application.targetFrameRate = 60; 

        GameplayCanvas = Instantiate(GameplayCanvasPrefab);
        FishInventoryCanvas = Instantiate(FishInventoryCanvasPrefab);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleShopCanvas() {
        if(player.isShopOpen) {
            Destroy(ShopCanvas);
            GameplayCanvas = Instantiate(GameplayCanvasPrefab);
            player.isShopOpen = false;
        } else {
            Destroy(GameplayCanvas);
            ShopCanvas = Instantiate(ShopCanvasPrefab);
            player.isShopOpen = true;    
        }
    }
}
