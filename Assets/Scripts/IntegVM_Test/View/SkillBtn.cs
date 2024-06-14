using UnityEngine;

public class SkillBtn : MonoBehaviour
{
    public void OnClick_LevelUp()
    {
        GameLogicManager.Inst.RequestLevelUp(2);
    }
}
