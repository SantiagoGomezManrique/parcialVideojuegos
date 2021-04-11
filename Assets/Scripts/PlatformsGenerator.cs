using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

public class PlatformsGenerator : MonoBehaviour
{
    [Header("Platform default model")]
    [SerializeField] private GameObject platformDefault;
    [Header("Item default model")]
    [SerializeField] private GameObject item;
    private Vector3 itemPosition;
    private Vector3 spawnPosition;
    [Header("Maximum platforms")]
    [SerializeField] private int maxPlatforms = 120;
    private float levelWidht = 3f;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = new Vector3();
        itemPosition = new Vector3();
        GeneratePlatformsWithItems();
    }

    private void GeneratePlatformsWithItems()
    {
        for (int i = 0; i < maxPlatforms; i++)
        {
            spawnPosition.y += 1.7f;
            spawnPosition.x = Random.Range(-levelWidht, levelWidht);                    
            Instantiate(platformDefault, spawnPosition, Quaternion.identity);

            item.GetComponent<Item>().isDangerous = GenerateDangerous();
            itemPosition.y = spawnPosition.y + 1f;
            itemPosition.x = spawnPosition.x;
            Instantiate(item, itemPosition, Quaternion.identity);
        }
    }

    private bool GenerateDangerous()
    {
        return (Random.value > 0.7f);
    }
}
    

