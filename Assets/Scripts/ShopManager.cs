using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ShopManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Button airCapacityUpgradeButton;
    public TMP_Text airCapacityUpgradeButtonText;
    public int airCapacityUpgradeCost;
    public TMP_Text airCapacityLevelText;
    public Button inventoryUpgradeButton;
    public TMP_Text inventoryUpgradeButtonText;
    public int inventoryUpgradeCost;
    public TMP_Text inventoryLevelText;

    public Button speedUpgradeButton;
    public TMP_Text speedUpgradeButtonText;
    public int speedUpgradeCost;
    public TMP_Text speedLevelText;

    private PlayerLevelManager player; 
    private PlayerInventoryManager playerInventoryManager;
    private InventoryUIManager inventoryUIManager;

    void Start()
    {
        airCapacityUpgradeButton.onClick.AddListener(TaskUpgradeAirCapacity);
        inventoryUpgradeButton.onClick.AddListener(TaskUpgradeInventory);
        speedUpgradeButton.onClick.AddListener(TaskUpgradeSpeed);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLevelManager>();
        playerInventoryManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventoryManager>();
        inventoryUIManager = GameObject.FindGameObjectWithTag("FishInvUIManager").GetComponent<InventoryUIManager>();

        //Initialise these to avoid flashing default text
        airCapacityUpgradeCost = 10 * player.levelOxygenMaxCapacity;
        inventoryUpgradeCost = 20 * player.levelFishInventory;
        speedUpgradeCost = 200;

        UpdateButtons();
    }

    bool BuyItem(int cost) {
        if(player.currentShellCount >= cost) {
            player.currentShellCount -= cost;
            return true;
        } else {
            return false;
        }
    }

    void UpdateButtons() {
        airCapacityUpgradeCost = 10 * player.levelOxygenMaxCapacity;
        inventoryUpgradeCost = 20 * player.levelFishInventory;
        speedUpgradeCost = 200 * player.levelSpeedFactor;

        airCapacityUpgradeButtonText.text = ($"${airCapacityUpgradeCost.ToString()}");
        inventoryUpgradeButtonText.text = ($"${inventoryUpgradeCost.ToString()}");
        speedUpgradeButtonText.text = ($"${speedUpgradeCost.ToString()}");

        airCapacityLevelText.text = ($"Level {player.levelOxygenMaxCapacity.ToString()}");
        inventoryLevelText.text = ($"Level {player.levelFishInventory.ToString()}");
        speedLevelText.text = ($"Level {player.levelSpeedFactor.ToString()}");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SellFish(InventoryFish fish) {
        player.currentShellCount += fish.sellValue;
    }

    void TaskUpgradeAirCapacity()
    {
        if(BuyItem(airCapacityUpgradeCost)) {
            player.oxygenMaxCapacity += 10;
            player.levelOxygenMaxCapacity += 1;
            UpdateButtons();
        } else {

        }
    }

    void TaskUpgradeInventory()
    {
        if(BuyItem(inventoryUpgradeCost)) {

            player.levelFishInventory += 1;
            playerInventoryManager.fishInventorySize += 1;

            inventoryUIManager.CreateAndUpdatePanels();

            UpdateButtons();
        } else {

        }
    }


    void TaskUpgradeSpeed()
    {
        if(BuyItem(speedUpgradeCost)) {

            player.levelSpeedFactor += 1;
            UpdateButtons();
        } else {

        }
    }
}
