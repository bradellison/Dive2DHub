using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class FishPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public Sprite emptySprite;
    public PlayerController player;
    private PlayerInventoryManager playerInventoryManager;
    public InventoryFish inventoryFish;
    public ShopManager shopManager;
    private Image image;
    public GameObject fishGameObject;
    // Start is called before the first frame update
    void Start()
    {
        image = this.GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerInventoryManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick() {
        Debug.Log("Click");
    }

    private void OnMouseUp() {
        Debug.Log("mouse up");
    }

    public void RemoveFish() {
        inventoryFish = null;
        image.sprite = emptySprite;
                
        playerInventoryManager.fishInventory.Remove(fishGameObject);
        Destroy(fishGameObject);
    }

    //Detect current clicks on the GameObject (the one with the script attached)
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        //Output the name of the GameObject that is being clicked
        //Debug.Log(name + "Game Object Click in Progress");

    }

    //Detect if clicks are no longer registering
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        //Debug.Log(name + "No longer being clicked");
        if(player.isShopOpen && inventoryFish != null) {

            shopManager = GameObject.FindGameObjectWithTag("ShopManager").GetComponent<ShopManager>();
            shopManager.SellFish(inventoryFish);
            RemoveFish();
        }
    }



}
