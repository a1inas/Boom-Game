using UnityEngine;

[CreateAssetMenu(fileName = "SelectedCharacter", menuName = "Scriptable Objects/Selected Character")]
public class SelectedCharacter : ScriptableObject
{
    public Sprite characterSprite;
    public RuntimeAnimatorController bomberManAnimator;
}
