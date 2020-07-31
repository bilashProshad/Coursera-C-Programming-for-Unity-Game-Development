using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanger : MonoBehaviour
{
    // Instantiate character and change character
    [SerializeField]
    GameObject prefabCharacter0;
    [SerializeField]
    GameObject prefabCharacter1;
    [SerializeField]
    GameObject prefabCharacter2;
    [SerializeField]
    GameObject prefabCharacter3;

    // Current character
    GameObject currentCharacter;

    // only first frame input support
    bool previousFrameChangeCharacterInput = false;

    // Start is called before the first frame update
    void Start()
    {
        currentCharacter = Instantiate<GameObject>(prefabCharacter0, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("CharacterChanger") > 0)
        {
            if (!previousFrameChangeCharacterInput)
            {
                previousFrameChangeCharacterInput = true;

                Vector3 position = currentCharacter.transform.position;
                Destroy(currentCharacter);

                int prefabNumber = Random.Range(0, 4);
                if (prefabNumber == 0)
                {
                    currentCharacter = Instantiate<GameObject>(prefabCharacter0, position, Quaternion.identity);
                }
                else if (prefabNumber == 1)
                {
                    currentCharacter = Instantiate<GameObject>(prefabCharacter1, position, Quaternion.identity);
                }
                else if (prefabNumber == 2)
                {
                    currentCharacter = Instantiate<GameObject>(prefabCharacter2, position, Quaternion.identity);
                }
                else
                {
                    currentCharacter = Instantiate<GameObject>(prefabCharacter3, position, Quaternion.identity);
                }
            }
        }
        else
        {
            previousFrameChangeCharacterInput = false;
        }
    }
}
