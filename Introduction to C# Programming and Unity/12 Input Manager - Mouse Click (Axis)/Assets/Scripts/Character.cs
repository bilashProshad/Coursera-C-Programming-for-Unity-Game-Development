using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // cach half size of collider
    float colliderHalfWidth;
    float colliderHalfHeight;

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        colliderHalfHeight = boxCollider2D.size.y / 2;
        colliderHalfWidth = boxCollider2D.size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 postion = Input.mousePosition;
        postion.z = -Camera.main.transform.position.z;
        postion = Camera.main.ScreenToWorldPoint(postion);
        transform.position = postion;

        ClampInScreen();
    }

    void ClampInScreen()
    {
        Vector3 position = transform.position;
        if(position.x - colliderHalfWidth < ScreenUtils.ScreenLeft)
        {
            position.x = ScreenUtils.ScreenLeft + colliderHalfWidth;
        }
        else if(position.x + colliderHalfWidth > ScreenUtils.ScreenRight)
        {
            position.x = ScreenUtils.ScreenRight - colliderHalfWidth;
        }
        if(position.y + colliderHalfHeight > ScreenUtils.ScreenTop)
        {
            position.y = ScreenUtils.ScreenTop - colliderHalfHeight;
        }
        else if(position.y - colliderHalfHeight < ScreenUtils.ScreenBottom)
        {
            position.y = ScreenUtils.ScreenBottom + colliderHalfHeight;
        }
        transform.position = position;
    }
}
