using UnityEngine;

namespace uOSC
{

    [RequireComponent(typeof(uOscServer))]
    public class server : MonoBehaviour
    {
        private static float _val;
        public static float val
        {
            get { return _val; }
        }
        void Start()
        {
            DontDestroyOnLoad(this);
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
            Debug.Log(_val);
        }
    }

}