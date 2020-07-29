using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        //rigidbody2D.AddForce(new Vector2(5, 0), ForceMode2D.Impulse);

        GetComponent<Rigidbody2D>().AddForce(new Vector2(5, 0), ForceMode2D.Impulse);
    }

    
}
