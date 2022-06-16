using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    
    public InventoryUIManager inventoryUIManager;
    public GameObject inventoryFishPrefab;
    public int fishInventorySize;
    public List<GameObject> fishInventory;
    private PlayerLevelManager playerLevelManager;


    void Start()
    {
        playerLevelManager = this.gameObject.GetComponent<PlayerLevelManager>();
        fishInventorySize = playerLevelManager.levelFishInventory;
        fishInventory = new List<GameObject>(fishInventorySize);
    }

    public void RemoveAllFishFromInventory() {
        foreach(GameObject fishPanelGameObject in inventoryUIManager.fishPanels) {
            fishPanelGameObject.transform.GetChild(0).GetComponent<FishPanel>().RemoveFish();
        }
    }

    public bool AddToInventory(Fish fish) 
    {
        if(fishInventory.Count < fishInventorySize) {
            GameObject inventoryFishGameObject = Instantiate(inventoryFishPrefab);

            InventoryFish inventoryFish = inventoryFishGameObject.GetComponent<InventoryFish>();

            inventoryFish.sprite = fish.gameObject.GetComponent<SpriteRenderer>().sprite;
            inventoryFish.species = fish.species;
            inventoryFish.sellValue = fish.sellValue;

            inventoryFishGameObject.transform.SetParent(gameObject.transform, true);

            fishInventory.Add(inventoryFishGameObject);

            inventoryUIManager.UpdatePanels();

            return true;
        } else {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

}
