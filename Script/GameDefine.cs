using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDefine 
{
    public const string startScene="UI";
    public const string CreateCharacterScene="create character";
    public const string playerName ="playerName";
    public const string playerRole ="playerRole";
    public const string character1Path = "Prefabs/character1";
    public const string character2Path = "Prefabs/character2";
    public const string EnimyPath = "Prefabs/FieldGoblin";
    public const string animIdle="Idle";
    public const string animRun="Run";
    public const string animDeath="Death";
    public const string animAttack1="Attack1";
    public const string animAttack2="Attack2";
    public const string character1attack = "Prefabs/BombEffect";
    public const string character2attack = "Prefabs/BowArrowC";
    public const string character1skill1 = "Prefabs/IceBurstEffect";
    public const string character1skill1plus = "Prefabs/MagicCircleYellow";

    // Update is called once per frame
}
public enum CharacterType
    {
        character1,
        character2,
    }

