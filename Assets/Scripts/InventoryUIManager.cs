using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{

    public PlayerInventoryManager playerInventoryManager;
    public GameObject fishInventoryCentre;
    private Vector2 fishInventoryCentreVector;
    public GameObject fishPanelPrefab;
    public List<GameObject> fishPanels;

    void Start()
    {
        playerInventoryManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventoryManager>();
        playerInventoryManager.inventoryUIManager = this;
        fishInventoryCentreVector = fishInventoryCentre.transform.position;
        CreateFishPanels();
    }

    public void CreateAndUpdatePanels()
    {
        RemoveFishPanels();
        CreateFishPanels();
        UpdatePanels();
    }

    void RemoveFishPanels() 
    {
        foreach (GameObject fishPanel in fishPanels) {
            Destroy(fishPanel);
        }
        fishPanels = new List<GameObject>();
    }

    void CreateFishPanels() 
    {   
        int panelSpacing = 100;
        float xVectorStartDifference = (playerInventoryManager.fishInventorySize - 1) * (panelSpacing / 2);
        for (int i = 0; i < playerInventoryManager.fishInventorySize; i++) {
            GameObject fishPanel = Instantiate(fishPanelPrefab);
            Vector2 fishPanelVector = new Vector2 (fishInventoryCentreVector.x + (panelSpacing * i) - xVectorStartDifference, fishInventoryCentreVector.y);
            fishPanel.transform.position = fishPanelVector;
            fishPanel.transform.SetParent(gameObject.transform, true);
            fishPanels.Add(fishPanel);
            //fishPanel.transform.parent = gameObject.transform;
        }
    }


    public void UpdatePanels() {
        int panelCount = 0;
        foreach (GameObject inventoryFishGO in playerInventoryManager.fishInventory) {
            InventoryFish inventoryFish = inventoryFishGO.GetComponent<InventoryFish>();
            Transform fishPanel = fishPanels[panelCount].transform.GetChild(0);
            fishPanel.GetComponent<Image>().sprite = inventoryFish.sprite;
            fishPanel.GetComponent<FishPanel>().inventoryFish = inventoryFish;
            fishPanel.GetComponent<FishPanel>().fishGameObject = inventoryFishGO;

            
            //fishPanels[panelCount].GetComponent<Image>().sprite = inventoryFish.sprite;
            panelCount += 1; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
