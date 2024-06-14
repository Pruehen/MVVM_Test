namespace ViewModel.Extensions
{
    public static class GameLogicViewModelExtension
    {
        public static void RefreshViewModel(this GameLogicViewModel vm)//��û �ͽ��ټ�
        {
            int tempId = 2;
            GameLogicManager.Inst.RefreshCharacterInfo(tempId, vm.OnRefreshViewModel);//�ݹ� ȣ��
        }

        public static void OnRefreshViewModel(this GameLogicViewModel vm, int userId, string name, int level)//�ݹ�
        {
            vm.UserId = userId;
            vm.Name = name;
            vm.Level = level;
        }

        //public static void BindRegisterEvents(this TopLeftViewModel vm, bool isRegistring)
        //{
        //    if(isRegistring)
        //    {

        //    }
        //    else
        //    {

        //    }
        //}

        public static void RegisterEventsOnEnable(this GameLogicViewModel vm)
        {
            GameLogicManager.Inst.RegisterLevelUpCallback(vm.OnResponseLevelUp);
            GameLogicManager.Inst.RegisterChangeNameCallback(vm.OnResponseChangeName);
        }
        public static void UnRegisterEventsOnDisable(this GameLogicViewModel vm)
        {
            GameLogicManager.Inst.UnRegisterLevelUpCallback(vm.OnResponseLevelUp);
            GameLogicManager.Inst.UnRegisterChangeNameCallback(vm.OnResponseChangeName);
        }
        public static void OnResponseLevelUp(this GameLogicViewModel vm, int userId, int level)
        {
            if (vm.UserId != userId) return;

            vm.Level = level;
        }
        public static void OnResponseChangeName(this GameLogicViewModel vm, int userId, string name)
        {
            if (vm.UserId != userId) return;

            vm.Name = name;
        }
    }
}
