using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] CharacterSelectOption playerOneIcon;
    [SerializeField] CharacterSelectOption playerTwoIcon;
    [SerializeField] CharacterSelectOption playerThreeIcon;
    // Start is called before the first frame update
    void Start()
    {
        playerOneIcon.Initialize(GameManager.Instance.PlayerOneCharacter);
        playerTwoIcon.Initialize(GameManager.Instance.PlayerTwoCharacter);
        playerThreeIcon.Initialize(GameManager.Instance.PlayerThreeCharacter);
    }
}
