namespace SignalMenu {
    public class MovementMods {
        public static void Fly()
        {
            if(ControllerInputPoller.instance.rightControllerTriggerButton)
            {
                GorillaLocomotion.GTPlayer.Instance.transform.position += GorillaLocomotion.GTPlayer.Instance.headCollider.transform.forward * Time.deltaTime * 10;
                GorillaLocomotion.GTPlayer.Instance.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            }
        }

        public static void SpeedBoost()
        {
            GorillaLocomotion.GTPlayer.Instance.maxJumpSpeed = 6.4f;
            GorillaLocomotion.GTPlayer.Instance.jumpMultiplier = 6.4f;
        }
    }
}