using UnityEngine;

[CreateAssetMenu(fileName = "Powerup", menuName = "Scriptable Objects/PowerupSO")]
public class PowerupSO : ScriptableObject
{
    [SerializeField] string powerupType;
    [SerializeField] float valueChange;
    [SerializeField] float time;
}
