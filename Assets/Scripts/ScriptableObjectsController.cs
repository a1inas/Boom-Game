using System;
using UnityEngine;

public class ScriptableObjectsController : MonoBehaviour
{
    [SerializeField] private Map[] maps;
    [SerializeField] private Character[] characters;
    [SerializeField] private MapDisplay mapDisplay;
    private int currentMapIndex;
    private int currentCharacterIndex;
    private Map selectedMap;
    public static SelectedCharacter selectedCharacter;

    private void Awake()
    {
        if (maps != null && maps.Length > 0)
        {
            ChangeMap(0);
        }
        else
        {
            Debug.LogError("The maps array is null or empty.");
        }

        if (characters != null && characters.Length > 0)
        {
            ChangeCharacter(0);
        }
        else
        {
            Debug.LogError("The characters array is null or empty.");
        }
    }

    public void ChangeMap(int change)
    {
        if (maps == null || maps.Length == 0)
        {
            Debug.LogError("The maps array is null or empty.");
            return;
        }

        currentMapIndex += change;
        if (currentMapIndex < 0) currentMapIndex = maps.Length - 1;
        else if (currentMapIndex > maps.Length - 1) currentMapIndex = 0;


        Debug.Log("Displaying map...");
        mapDisplay.DisplayMap(maps[currentMapIndex]);
        selectedMap = maps[currentMapIndex];
        mapDisplay.selectedMap = maps[currentMapIndex];
    }

    public void ChangeCharacter(int change)
    {        
        if (characters == null || characters.Length == 0)
        {
            Debug.LogError("The characters array is null or empty.");
            return;
        }

        currentCharacterIndex += change;
        if (currentCharacterIndex < 0) currentCharacterIndex = characters.Length - 1;
        else if (currentCharacterIndex > characters.Length - 1) currentCharacterIndex = 0;

        ScriptableObject currentObject = characters[currentCharacterIndex];
        Debug.Log($"Changing character to index {currentCharacterIndex}, object type: {currentObject.GetType()}");

        if (mapDisplay != null && currentObject is Character character)
        {
            Debug.Log("Displaying character...");
            mapDisplay.DisplayCharacter(character);
        }
        else
        {
            Debug.LogError("Unsupported ScriptableObject type for characters.");
        }
    }
    public void SelectCharacter() { mapDisplay.SelectCharacter(); }

}
