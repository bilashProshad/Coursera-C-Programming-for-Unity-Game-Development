using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    // prefab for Instantiate
    [SerializeField]
    GameObject prefabRock;

    // rock sprites
    [SerializeField]
    Sprite rockSprite0;
    [SerializeField]
    Sprite rockSprite1;
    [SerializeField]
    Sprite rockSprite2;

    // spawn time
    const float SpawnRockDelay = 1f;
    Timer spawnTimer;


    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = SpawnRockDelay;
        spawnTimer.Run();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTimer.Finished && GameObject.FindGameObjectsWithTag("Rock").Length < 3)
        {
            SpawnRock();

            spawnTimer.Duration = SpawnRockDelay;
            spawnTimer.Run();
        }
    }

    private void SpawnRock()
    {
        GameObject rock = Instantiate(prefabRock) as GameObject;
        rock.transform.position = Vector3.zero;
        SpriteRenderer rockSprite = rock.GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber == 0)
        {
            rockSprite.sprite = rockSprite0;
        }
        else if (spriteNumber == 1)
        {
            rockSprite.sprite = rockSprite1;
        }
        else
        {
            rockSprite.sprite = rockSprite2;
        }
    }
}
