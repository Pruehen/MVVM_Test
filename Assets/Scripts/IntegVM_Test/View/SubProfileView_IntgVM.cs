using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using ViewModel;
using ViewModel.Extensions;

public class SubProfileView_IntgVM : MonoBehaviour
{
    [SerializeField] Text Text_Name;
    [SerializeField] Text Text_Level;

    SubProfileViewModel _vm;

    private void OnEnable()
    {
        if (_vm == null)
        {
            _vm = new SubProfileViewModel();
            _vm.PropertyChanged += OnPropertyChanged;
            _vm.RegisterEventsOnEnable();
            _vm.RefreshViewModel();
        }
    }
    private void OnDisable()
    {
        if (_vm != null)
        {
            _vm.UnRegisterOnDisable();
            _vm.PropertyChanged -= OnPropertyChanged;
            _vm = null;
        }
    }

    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(_vm.Name):
                Text_Name.text = $"이름 : {_vm.Name}";
                break;
            case nameof(_vm.Level):
                Text_Level.text = $"레벨 : {_vm.Level}";
                break;
        }
    }
}
public class SubProfileViewModel : ViewModelBase
{
    private int _userId;
    private string _name;
    private int _level;

    public int UserId
    {
        get { return _userId; }
        set { _userId = value; }
    }
    public string Name
    {
        get { return _name; }
        set
        {
            if (_name == value)
                return;

            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }
    public int Level
    {
        get { return _level; }
        set
        {
            if (_level == value)
                return;

            _level = value;
            OnPropertyChanged(nameof(Level));
        }
    }
}