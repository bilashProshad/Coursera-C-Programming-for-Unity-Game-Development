using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowSprite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector2 newScale = transform.localScale;
        newScale.x *= 4;
        newScale.y *= 4;
        transform.localScale = newScale;
    }

   
}
