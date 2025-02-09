using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using ViewModel.Extensions;

public class TopLeftView : MonoBehaviour
{
    [SerializeField] Text Text_Name;
    [SerializeField] Text Text_Level;
    [SerializeField] Image Image_Icon;

    //��� ����
    GameLogicViewModel _vm;

    private void OnEnable()
    {
        if(_vm == null)
        {
            _vm = new GameLogicViewModel();
            _vm.PropertyChanged += OnPropertyChanged;
            _vm.RegisterEventsOnEnable();
            _vm.RefreshViewModel();
        }
    }
    private void OnDisable()
    {
        if(_vm != null)
        {
            _vm.UnRegisterEventsOnDisable();
            _vm.PropertyChanged -= OnPropertyChanged;
            _vm = null;
        }
    }

    void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(_vm.Name):
                Text_Name.text = _vm.Name;
                break;
            case nameof(_vm.Level):
                Text_Level.text = $"{_vm.Level}";
                break;
            case nameof(_vm.IconName):
                break;
        }
    }
}
