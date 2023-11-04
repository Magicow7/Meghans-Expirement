using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelectOption : MonoBehaviour
{
    [SerializeField] private Image characterImage;
    [SerializeField] private Image outline;
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private Image playerOne;
    [SerializeField] private Image playerTwo;
    [SerializeField] private Image playerThree;

    public void Initialize(ScriptableCharacter character)
    {
        characterImage.sprite = character.characterImage;
        text.SetText(character.characterName);
    }

    public void SetPlayerOne(bool on) {
        playerOne.gameObject.SetActive(on);
    }

    public void SetPlayerTwo(bool on) {
        playerTwo.gameObject.SetActive(on);
    }

    public void SetPlayerThree(bool on) {
        playerThree.gameObject.SetActive(on);
    }
}
