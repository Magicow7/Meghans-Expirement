using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Character", menuName = "New Character", order = 1)]
public class ScriptableCharacter : ScriptableObject
{
    public Sprite characterImage;
    public string characterName;
}