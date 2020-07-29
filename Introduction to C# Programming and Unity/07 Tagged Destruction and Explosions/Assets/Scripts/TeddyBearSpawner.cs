using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddyBearSpawner : MonoBehaviour
{
    // prefab for spawn
    [SerializeField]
    GameObject prefabYellowTeddyBear;
    [SerializeField]
    GameObject prefabGreenTeddyBear;
    [SerializeField]
    GameObject prefabPurpleTeddyBear;
   

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
        GameObject teddyBear;

        int prefabNumber = Random.Range(0, 3);
        if(prefabNumber == 0)
        {
            teddyBear = Instantiate<GameObject>(prefabYellowTeddyBear, worldLocation, Quaternion.identity);
            // dinamically add tag to a gameObject
            teddyBear.tag = "C4Teddy";      
        }
        else if(prefabNumber == 1)
        {
            teddyBear = Instantiate<GameObject>(prefabGreenTeddyBear, worldLocation, Quaternion.identity);
            teddyBear.tag = "C4Teddy";
        }
        else
        {
            teddyBear = Instantiate<GameObject>(prefabPurpleTeddyBear, worldLocation, Quaternion.identity);
            teddyBear.tag = "C4Teddy";
        }
    }
}
