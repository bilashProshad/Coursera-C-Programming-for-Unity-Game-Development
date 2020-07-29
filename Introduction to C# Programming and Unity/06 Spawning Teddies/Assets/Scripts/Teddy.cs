using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teddy : MonoBehaviour
{
    // death support
    Timer deathTimer;
    const float TeddyBearLifeSpanSeconds = 10f;

    // Start is called before the first frame update
    void Start()
    {
        const float MinImpolseForce = 3f;
        const float MaxImpolseForce = 5f;
        float angle = Random.Range(0, 2 * Mathf.PI);
        float magnitude = Random.Range(MinImpolseForce, MaxImpolseForce);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(magnitude * direction, ForceMode2D.Impulse);

        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = TeddyBearLifeSpanSeconds;
        deathTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (deathTimer.Finished)
        {
            Destroy(gameObject);
        }
    }
}
