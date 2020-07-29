using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizer : MonoBehaviour
{
    // timer
    const float TotalResizeSeconds = 1f;
    float elapsedResizeSeconds = 0f;

    const float ScaleFactorPerSeconds = 1f;
    float scaleFactorMultiplayer = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newScale = transform.localScale;
        newScale.x += scaleFactorMultiplayer * ScaleFactorPerSeconds * Time.deltaTime;
        newScale.y += scaleFactorMultiplayer * ScaleFactorPerSeconds * Time.deltaTime;
        transform.localScale = newScale;
        
        elapsedResizeSeconds += Time.deltaTime;
        if(elapsedResizeSeconds >= TotalResizeSeconds)
        {
            scaleFactorMultiplayer *= -1;
            elapsedResizeSeconds = 0;
        }

        
    }
}
