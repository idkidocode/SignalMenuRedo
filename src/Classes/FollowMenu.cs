namespace SignalMenu
{
    public class FollowMenu : MonoBehaviour {
        public Transform target;
        public Vector3 pos;
        public Quaternion rot;

        void LateUpdate()
        {
            transform.position = target.TransformPoint(pos);
            transform.rotation = target.rotation * rot;
        }
    }
}