namespace SignalMenu
{
    public class ButtonData
    {
        public string Name;
        public Action Action;
        public bool IsToggleable;
        public int TargetCat;
        public int TargetPage;

        public ButtonData(string name, Action action, bool isToggleable, int targetCat, int targetPage)
        {
            Name = name;
            Action = action;
            IsToggleable = isToggleable;
            TargetCat = targetCat;
            TargetPage = targetPage;
        }
    }
}