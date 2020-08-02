using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanger : MonoBehaviour
{
    //[SerializeField]
    //GameObject[] prefabCharacters;

    GameObject[] prefabCharacters = new GameObject[4]; // dinamically add

    GameObject currnetCharacter;
    bool previousFrameCharacterChangeFlag = false;


    // Start is called before the first frame update
    void Start()
    {
        // dinamically add gameobject
        prefabCharacters[0] = (GameObject)Resources.Load("character0");
        prefabCharacters[1] = (GameObject)Resources.Load("character1");
        prefabCharacters[2] = (GameObject)Resources.Load("character2");
        prefabCharacters[3] = (GameObject)Resources.Load("character3");

        currnetCharacter = Instantiate<GameObject>(prefabCharacters[0], Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("CharacterChanger") > 0)
        {
            if (!previousFrameCharacterChangeFlag)
            {
                previousFrameCharacterChangeFlag = true;

                Vector3 position = currnetCharacter.transform.position;
                Destroy(currnetCharacter);

                currnetCharacter = Instantiate<GameObject>(
                    prefabCharacters[Random.Range(0, prefabCharacters.Length)], 
                    position, Quaternion.identity);
            }
        }
        else
        {
            previousFrameCharacterChangeFlag = false;
        }
    }
}
