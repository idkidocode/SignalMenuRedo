namespace SignalMenu {
    public class ButtonCollider : GorillaPressableButton {

        public Action action;
        public bool isToggleable;
        public string buttonName;

        private static Dictionary<string, bool> toggleStates = new Dictionary<string, bool>();

        private static float cooldownDuration = 0.2f;
        private static float lastClickTime = -Mathf.Infinity;

        private static bool IsOnCooldown() => (Time.time - lastClickTime) < cooldownDuration;
        private static void RegisterClick() => lastClickTime = Time.time;

        private bool isToggled => isToggleable && toggleStates.ContainsKey(buttonName) && toggleStates[buttonName];

        public static bool IsToggled(string name) =>
            toggleStates.ContainsKey(name) && toggleStates[name];

        public override void ButtonActivationWithHand(bool isLeftHand)
        {
            base.ButtonActivationWithHand(isLeftHand);

            if (!isLeftHand)
            {
                if (IsOnCooldown()) return;
                RegisterClick();

                GorillaTagger.Instance.StartVibration(isLeftHand, GorillaTagger.Instance.tagHapticStrength / 2f, GorillaTagger.Instance.tagHapticDuration / 2f);
                VRRig.LocalRig.PlayHandTapLocal(8, isLeftHand, 1f);

                if (isToggleable)
                {
                    toggleStates[buttonName] = !isToggled;
                    GetComponent<Renderer>().material.color = isToggled ? Themes.btnOnColor : Themes.btnOffColor;
                }
                else
                {
                    action.Invoke();
                }
            }
        }

        void Update()
        {
            if (isToggled)
            {
                action.Invoke();
            }
        }
    }
}