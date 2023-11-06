using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public ScriptableCharacter PlayerOneCharacter { get; private set; }
    public ScriptableCharacter PlayerTwoCharacter { get; private set; }
    public ScriptableCharacter PlayerThreeCharacter { get; private set; }
    private void Awake() 
    { 
        DontDestroyOnLoad(this);

        if (Instance != null && Instance != this)
            Destroy(this); 
        else 
            Instance = this; 
    }

    public void SetPlayerOne(ScriptableCharacter character) {
        PlayerOneCharacter = character;
    }

    public void SetPlayerTwo(ScriptableCharacter character) {
        PlayerTwoCharacter = character;
    }

    public void SetPlayerThree(ScriptableCharacter character) {
        PlayerThreeCharacter = character;
    }
}
