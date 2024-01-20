using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public GameObject tomPrefab;
    public GameObject playerPrefab;
    public GameObject avatar3Prefab;
    public GameObject avatar4Prefab;

    public GameObject currentCharacter;

    public void SetCharacter(string characterName)
    {
        if(currentCharacter!= null)
        {

            Destroy(currentCharacter);

        }
        if (characterName.Equals("Tom", System.StringComparison.OrdinalIgnoreCase))
        {

            currentCharacter = Instantiate(tomPrefab, transform.position,Quaternion.identity);

        }
        else if (characterName.Equals("Player", System.StringComparison.OrdinalIgnoreCase))
        {

            currentCharacter = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        }

        else if (characterName.Equals("Avatar3", System.StringComparison.OrdinalIgnoreCase))
        {

            currentCharacter = Instantiate(avatar3Prefab, transform.position, Quaternion.identity);

        }
        else if (characterName.Equals("Avatar4", System.StringComparison.OrdinalIgnoreCase))
        {

            currentCharacter = Instantiate(avatar4Prefab, transform.position, Quaternion.identity);

        }
    }
}
