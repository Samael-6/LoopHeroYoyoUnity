using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDatas", menuName = "Scriptable Objects/PlayerDatas")]
public class PlayerDatas : ScriptableObject
{
    public int _cellNumber;
    public int _IndexKingDialogue;
    public int _IndexSuspiciousWomanDialogue;
    public int _IndexSentinelleDialogue;
    public bool _IsEquiped;
    public bool _IsBeginning;
    public bool _IsEnding;
    public bool _IsDrunk;
}
