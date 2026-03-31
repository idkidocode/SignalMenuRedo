

namespace SignalMenu
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Main : BaseUnityPlugin
    {
        static bool isMenuCreated = false;
        static GameObject menuObj;

        public float pageSwitchCooldown = 0f;

        public static int currentCat = 0;

        public static int currentPage = 1;

        static List<GameObject> btns = new List<GameObject>();

        void Awake()
        {
            Harmony harmony = new Harmony("vr.input.module");
            harmony.PatchAll();
            Debug.Log("Loaded Menu");
        }

        void Update()
        {
            if (!isMenuCreated && ControllerInputPoller.instance.leftControllerSecondaryButton)
            {
                Debug.Log("Opening Menu");
                CreateMenu();
            }
            else if (isMenuCreated && !ControllerInputPoller.instance.leftControllerSecondaryButton)
            {
                Debug.Log("Closing Menu");
                DestroyMenu();
            }

            foreach (var btn in Buttons.buttonList)
            {
                if (btn.IsToggleable && ButtonCollider.IsToggled(btn.Name))
                {
                    btn.Action.Invoke();
                }
            }
        }

        public static void CreateMenu()
        {
            isMenuCreated = true;

            var player = GorillaLocomotion.GTPlayer.Instance;

            menuObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            menuObj.transform.parent = player.LeftHand.controllerTransform;
            menuObj.transform.localPosition = Vector3.zero;
            menuObj.transform.localRotation = Quaternion.identity;
            menuObj.transform.localScale = new Vector3(0.03f, 0.3f, 0.45f);

            menuObj.GetComponent<Rigidbody>().Destroy();
            menuObj.GetComponent<Collider>().Destroy();

            var rend = menuObj.GetComponent<Renderer>();
            rend.material.shader = Shader.Find("GorillaTag/UberShader");
            rend.material.color = Themes.backgroundColor;

            var textObj = new GameObject("ButtonLabel");
            textObj.transform.SetParent(menuObj.transform);
            textObj.transform.localPosition = new Vector3(0.55f, 0f, 0f);
            textObj.transform.localRotation = Quaternion.Euler(0f, -90f, -90f);

            var text = textObj.AddComponent<TextMeshPro>();
            text.text = "Signal Menu";
            text.fontSize = 30;
            text.alignment = TextAlignmentOptions.Top;
            text.color = Themes.TextColor;
            text.enableAutoSizing = true;
            text.transform.localScale = new Vector3(0.01f, 0.1f, 0.3f);

            Buttons.AllButtons();
        }

        public static void DestroyMenu()
        {
            isMenuCreated = false;
            GameObject.Destroy(menuObj);
            DestroyButtons();
        }

        public static void AddButton(float zOffset, string Name, Action action, bool isToggleable)
        {
            GameObject btnObj = GameObject.CreatePrimitive(PrimitiveType.Cube);

            var player = GorillaLocomotion.GTPlayer.Instance;

            var follow = btnObj.AddComponent<FollowMenu>();
            follow.target = player.LeftHand.controllerTransform;
            follow.pos = new Vector3(0.02f, 0f, zOffset);
            follow.rot = Quaternion.identity;

            btnObj.transform.localScale = new Vector3(0.03f, 0.28f, 0.04f);

            var trigger = btnObj.AddComponent<ButtonCollider>();
            trigger.action = action;
            trigger.isToggleable = isToggleable;
            trigger.buttonName = Name;

            var rend = btnObj.GetComponent<Renderer>();
            rend.material.shader = Shader.Find("GorillaTag/UberShader");
            rend.material.color = (isToggleable && ButtonCollider.IsToggled(Name)) ? Themes.btnOnColor : Themes.btnOffColor;
            btnObj.GetComponent<Collider>().isTrigger = true;
            btnObj.layer = 18;

            var textObj = new GameObject("ButtonLabel");
            textObj.transform.SetParent(btnObj.transform);
            textObj.transform.localPosition = new Vector3(0.55f, 0f, 0f);
            textObj.transform.localRotation = Quaternion.Euler(0f, -90f, -90f);

            var text = textObj.AddComponent<TextMeshPro>();
            text.text = Name;
            text.fontSize = 30;
            text.alignment = TextAlignmentOptions.Top;
            text.color = Themes.TextColor;
            text.enableAutoSizing = true;
            text.transform.localScale = new Vector3(0.01f, 0.1f, 0.3f);

            btns.Add(btnObj);
        }

        public static void DestroyButtons()
        {
            foreach (GameObject btn in btns)
            {
                GameObject.Destroy(btn);
            }
            btns.Clear();
        }
    }
}