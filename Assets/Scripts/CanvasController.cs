using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject GameplayCanvasPrefab;
    private GameObject GameplayCanvas;
    public GameObject ShopCanvasPrefab;
    private GameObject ShopCanvas;

    public GameObject FishInventoryCanvasPrefab;
    private GameObject FishInventoryCanvas;

    public GameObject StartCanvasPrefab;
    public PlayerController player;

    void Start()
    {
        GameplayCanvas = Instantiate(GameplayCanvasPrefab);
        FishInventoryCanvas = Instantiate(FishInventoryCanvasPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !player.isUnderwater) {
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
}
