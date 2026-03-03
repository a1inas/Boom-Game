using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MapDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text mapName;
    [SerializeField] private TMP_Text mapDescription;
    [SerializeField] private Image mapImage;
    [SerializeField] private GameObject changeTypeButton;
    [SerializeField] private Image characterImage;
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject selectCharacter;
    [SerializeField] private GameObject nextMapButton;
    [SerializeField] private GameObject prevMapButton;
    [SerializeField] private GameObject nextCharacterButton;
    [SerializeField] private GameObject prevCharacterButton;
    [SerializeField] private GameObject playButton;
    public Map selectedMap;
    public SelectedCharacter selectedCharacter;
    
    public void DisplayMap(Map map)
    {
        mapName.text = map.mapName;
        mapDescription.text = map.mapDescription;
        mapImage.sprite = map.mapImage;
        selectedMap = map;

       
        Debug.Log("Displaying map: " + map.mapName);
    }

    public void LoadLevel()
    {
        if (selectedMap != null)
        {
            SceneManager.LoadSceneAsync(selectedMap.mapIndex);
        }
        else
        {
            Debug.LogError("No map selected to load.");
        }
    }


    public void DisplayCharacter(Character character)
    {
        characterImage.sprite = character.characterImage;
        selectedCharacter.characterSprite = character.characterImage;
        selectedCharacter.bomberManAnimator= character.bomberManAnimator;
     
        Animator animator = GetComponent<Animator>();

        if (animator != null)
        {
           
            if (character.bomberManAnimator != null)
            {
                animator.runtimeAnimatorController = character.bomberManAnimator;
                Debug.Log("Контроллер анимации обновлён для персонажа.");
            }
            else
            {
                Debug.LogError("Контроллер анимации отсутствует для выбранного персонажа.");
            }
        }
        else
        {
            Debug.LogError("Компонент Animator отсутствует на этом объекте.");
        }
    }

    public void SelectCharacter()
    {
        Debug.Log("SelectCharacter called in MapDisplay");
        
        background.SetActive(false);
        selectCharacter.SetActive(true);
        changeTypeButton.SetActive(false);
        playButton.SetActive(true);
        nextMapButton.SetActive(false);
        prevMapButton.SetActive(false);
        nextCharacterButton.SetActive(true);
        prevCharacterButton.SetActive(true);
        Debug.Log("Switched to character selection screen.");
    }
}
