using UnityEngine;

namespace uOSC
{

    [RequireComponent(typeof(uOscServer))]
    public class server : MonoBehaviour
    {
        private float _val;
        public float val
        {
            get { return _val; }
        }
        void Start()
        {
            var server = GetComponent<uOscServer>();
            server.onDataReceived.AddListener(OnDataReceived);
        }

        void OnDataReceived(Message message)
        {
            string val = "";

            foreach (var value in message.values) {
                val = value.GetString();
            }

            _val = float.Parse(val);
        }
    }

}