using System.ComponentModel;

public class TopLeftViewModel
{
    int _userId;
    string _name;
    int _level;
    string _iconName;

    public int UserId
    {
        get { return _userId; }
        set
        {
            _userId = value;
        }
    }
    public string Name
    {
        get { return _name; }
        set
        {
            if (_name == value) return;
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }
    public int Level
    {
        get { return _level; }
        set
        {
            if (_level == value) return;
            _level = value;
            OnPropertyChanged(nameof(Level));
        }
    }
    public string IconName
    {
        get { return _iconName; }
        set
        {
            if (_iconName == value) return;
            _iconName = value;
            OnPropertyChanged(nameof(IconName));
        }
    }

    #region PropChanged
    public event PropertyChangedEventHandler PropertyChanged;
    
    protected virtual void OnPropertyChanged(string propertyName)//���� ����Ǿ��� �� �̺�Ʈ�� �߻���Ű�� ���� �뵵 (������ ���ε�)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
}
