using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyBearSpawner : MonoBehaviour
{
    // prefab for spawn
    [SerializeField]
    GameObject prefabTeddyBear;
    
    // sprite for change randerar
    [SerializeField]
    Sprite teddyBearSprite0;
    [SerializeField]
    Sprite teddyBearSprite1;
    [SerializeField]
    Sprite teddyBearSprite2;

    // support for timer
    const float MinSpawnTime = 1f;
    const float MaxSpawnTime = 2f;
    Timer spawnTimer;

    // spawn border area
    const int SpawnborderSize = 100;
    int minSpawnX;
    int maxSpawnX;
    int minSpawnY;
    int maxSpawnY;


    // Start is called before the first frame update
    void Start()
    {
        // save spawn boundaries
        minSpawnX = SpawnborderSize;
        maxSpawnX = Screen.width - SpawnborderSize;
        minSpawnY = SpawnborderSize;
        maxSpawnY = Screen.height - SpawnborderSize;

        // start and save timer
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = Random.Range(MinSpawnTime, MaxSpawnTime);
        spawnTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer.Finished)
        {
            SpawnBear();

            spawnTimer.Duration = Random.Range(MinSpawnTime, MaxSpawnTime);
            spawnTimer.Run();
        }
    }

    void SpawnBear()
    {
        Vector3 location = new Vector3
            (Random.Range(minSpawnX, maxSpawnX), 
            Random.Range(minSpawnY, maxSpawnY), 
            -Camera.main.transform.position.z);

        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);

        GameObject teddyBear = Instantiate(prefabTeddyBear) as GameObject;
        teddyBear.transform.position = worldLocation;

        SpriteRenderer spriteRenderer = teddyBear.GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if(spriteNumber == 0)
        {
            spriteRenderer.sprite = teddyBearSprite0;
        }
        else if(spriteNumber == 1)
        {
            spriteRenderer.sprite = teddyBearSprite1;
        }
        else
        {
            spriteRenderer.sprite = teddyBearSprite2;
        }
    }
}
