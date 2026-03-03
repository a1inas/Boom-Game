using UnityEngine;

[CreateAssetMenu(fileName = "New character", menuName = "Scriptable Objects/Character")]   
public class Character : ScriptableObject
{
    public Sprite characterImage;
    public RuntimeAnimatorController bomberManAnimator;
}
