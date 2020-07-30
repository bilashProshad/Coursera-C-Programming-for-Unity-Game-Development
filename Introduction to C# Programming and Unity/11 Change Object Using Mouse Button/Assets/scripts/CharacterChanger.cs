using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Changes character on left mouse button
/// </summary>
public class CharacterChanger : MonoBehaviour
{
    [SerializeField]
    GameObject prefabCharacter0;
    [SerializeField]
    GameObject prefabCharacter1;
    [SerializeField]
    GameObject prefabCharacter2;
    [SerializeField]
    GameObject prefabCharacter3;

    // need for location of new character
    GameObject currentCharacter;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        currentCharacter = Instantiate<GameObject>(
            prefabCharacter0, Vector3.zero,
            Quaternion.identity);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = currentCharacter.transform.position;
            Destroy(currentCharacter);

            int characterIndex = Random.Range(0, 4);
            if(characterIndex == 0)
            {
                currentCharacter = Instantiate<GameObject>(prefabCharacter0, position, Quaternion.identity);
            }else if(characterIndex == 1)
            {
                currentCharacter = Instantiate<GameObject>(prefabCharacter1, position, Quaternion.identity);
            }else if(characterIndex == 2)
            {
                currentCharacter = Instantiate<GameObject>(prefabCharacter2, position, Quaternion.identity);
            }
            else
            {
                currentCharacter = Instantiate<GameObject>(prefabCharacter3, position, Quaternion.identity);
            }
        }
    }
}
