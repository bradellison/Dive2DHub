using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawnPoint : MonoBehaviour
{

    public bool isRandomFish;
    public GameObject notRandomFishToSpawn;
    public int spawnWeighting;
    public bool isFishSpawned;
    private List<GameObject> allFishPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        allFishPrefabs = transform.parent.GetComponent<AllFishPrefabs>().allFishPrefabs;
        CreateFish();
    }

    private GameObject ChooseFishToSpawn() {
        for(int i = 0; i < allFishPrefabs.Count; i++) {
            int index = Random.Range (0, allFishPrefabs.Count);
            if(allFishPrefabs[index].GetComponent<Fish>().spawnValue <= spawnWeighting) {
                return allFishPrefabs[index];
            }
        }
        return null;
    }

    public void CreateFish() {
        if (!isFishSpawned) {
            GameObject fishToSpawn;
            if(isRandomFish) {
                fishToSpawn = ChooseFishToSpawn();
            } else {
                fishToSpawn = notRandomFishToSpawn;
            }
            if(fishToSpawn != null) {
                GameObject spawnedFish = Instantiate(fishToSpawn);
                spawnedFish.transform.position = this.transform.position;
                spawnedFish.GetComponent<Fish>().spawnPoint = this;
                isFishSpawned = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
