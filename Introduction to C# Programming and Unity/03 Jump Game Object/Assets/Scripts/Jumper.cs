using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    // jump location support
    const float minX = -7;
    const float maxX = 7;
    const float minY = -3;
    const float maxY = 3;

    // timer support
    const float TotalJumpDelaySeconds = 1;
    float elapsedJumpDelaySeconds = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedJumpDelaySeconds += Time.deltaTime;
        if(elapsedJumpDelaySeconds >= TotalJumpDelaySeconds)
        {
            Vector2 newPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            transform.position = newPosition;
            elapsedJumpDelaySeconds = 0;
        }
    }
}
