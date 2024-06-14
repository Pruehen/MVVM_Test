using UnityEngine;

public class TempProfileUI : MonoBehaviour
{
    string _curName;
    public void OnValueChange_SetCurName(string value)
    {
        _curName = value;
    }
    public void OnClick_ChangeName()
    {
        GameLogicManager.Inst.RequestChangeName(_curName);
    }
}
