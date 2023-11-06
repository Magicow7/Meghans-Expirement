using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterOptions : MonoBehaviour
{
    [SerializeField] GameObject characterSelectPrefab;
    [SerializeField] ScriptableCharacter[] characters;
    [SerializeField] SceneLoadOverlay sceneLoadOverlay;
    int playerOneLocation = 0;
    int playerTwoLocation = 0;
    int playerThreeLocation = 0;

    private CharacterSelectOption[] characterSelects;
    // Start is called before the first frame update
    void Start()
    {
        characterSelects = new CharacterSelectOption[characters.Length];
        for (int i = 0; i < characters.Length; i++) {
            ScriptableCharacter character = characters[i];
            GameObject characterSelectOptionObject = Instantiate(characterSelectPrefab, transform);
            CharacterSelectOption characterSelectOption = characterSelectOptionObject.GetComponent<CharacterSelectOption>();
            characterSelectOption.Initialize(character);
            characterSelects[i] = characterSelectOption;
        }
        characterSelects[playerOneLocation].SetPlayerOne(true);
        characterSelects[playerTwoLocation].SetPlayerTwo(true);
        characterSelects[playerThreeLocation].SetPlayerThree(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Player One
        if (Input.GetKeyDown(KeyCode.A)) {
            characterSelects[playerOneLocation].SetPlayerOne(false);
            playerOneLocation = (playerOneLocation - 1 + characterSelects.Length) % characterSelects.Length;
            Debug.Log(playerOneLocation);
            characterSelects[playerOneLocation].SetPlayerOne(true);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            characterSelects[playerOneLocation].SetPlayerOne(false);
            playerOneLocation = (playerOneLocation + 1) % characterSelects.Length;
            characterSelects[playerOneLocation].SetPlayerOne(true);
        }

        // Player Two
        if (Input.GetKeyDown(KeyCode.G)) {
            characterSelects[playerTwoLocation].SetPlayerTwo(false);
            playerTwoLocation = (playerTwoLocation - 1 + characterSelects.Length) % characterSelects.Length;
            characterSelects[playerTwoLocation].SetPlayerTwo(true);
        }
        if (Input.GetKeyDown(KeyCode.J)) {
            characterSelects[playerTwoLocation].SetPlayerTwo(false);
            playerTwoLocation = (playerTwoLocation + 1) % characterSelects.Length;
            characterSelects[playerTwoLocation].SetPlayerTwo(true);
        }
        
        // Player Three
        if (Input.GetKeyDown(KeyCode.L)) {
            characterSelects[playerThreeLocation].SetPlayerThree(false);
            playerThreeLocation = (playerThreeLocation - 1 + characterSelects.Length) % characterSelects.Length;
            characterSelects[playerThreeLocation].SetPlayerThree(true);
        }
        if (Input.GetKeyDown(KeyCode.Quote)) {
            characterSelects[playerThreeLocation].SetPlayerThree(false);
            playerThreeLocation = (playerThreeLocation + 1) % characterSelects.Length;
            characterSelects[playerThreeLocation].SetPlayerThree(true);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            GameManager.Instance.SetPlayerOne(characters[playerOneLocation]);
            GameManager.Instance.SetPlayerTwo(characters[playerTwoLocation]);
            GameManager.Instance.SetPlayerThree(characters[playerThreeLocation]);
            StartCoroutine(sceneLoadOverlay.LoadOut());
        }
    }
}
