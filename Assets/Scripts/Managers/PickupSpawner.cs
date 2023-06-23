using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private PickupSpawn[] pickups;

    [Range(0, 1)] [SerializeField] private float pickupProbability;


    private List<Pickup> pickupList = new List<Pickup>();

    private Pickup chosenPickup;
    // Start is called before the first frame update
    void Start()
    {
        foreach (PickupSpawn spawn in pickups)
        {
            for (int i = 0; i < spawn.spawnWeight; i++)
            {
                pickupList.Add(spawn.pickup)    ;
            }
        }
    }

    public void SpawnPickup(Vector2 position)
    {
        if (pickupList.Count <= 0)
        {
            return;
        }

        if (Random.Range(0, 1f) <= pickupProbability)
        {
            chosenPickup = pickupList[Random.Range(0, pickupList.Count)];
            Instantiate(chosenPickup, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    [System.Serializable]
    public struct PickupSpawn
    {
        public Pickup pickup;
        public int spawnWeight;
    }
}
