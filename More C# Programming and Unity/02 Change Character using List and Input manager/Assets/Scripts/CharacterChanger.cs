using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChanger : MonoBehaviour
{
    //[SerializeField]
    //GameObject[] prefabCharacters;

    List<GameObject> prefabCharacters = new List<GameObject>(); // dinamically add

    GameObject currnetCharacter;
    bool previousFrameCharacterChangeFlag = false;


    // Start is called before the first frame update
    void Start()
    {
        // dinamically add gameobject
        prefabCharacters.Add((GameObject)Resources.Load(@"Prefabs\character0"));
        prefabCharacters.Add((GameObject)Resources.Load(@"Prefabs\character1"));
        prefabCharacters.Add((GameObject)Resources.Load(@"Prefabs\character2"));
        prefabCharacters.Add((GameObject)Resources.Load(@"Prefabs\character3"));

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
                    prefabCharacters[Random.Range(0, prefabCharacters.Count)], 
                    position, Quaternion.identity);
            }
        }
        else
        {
            previousFrameCharacterChangeFlag = false;
        }
    }
}
