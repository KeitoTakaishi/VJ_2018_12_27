using UnityEngine;
using System;

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
            if (message.address.Contains("low")) {
                foreach (var value in message.values) {
                    _val = float.Parse(value.GetString());
                }
            }

            //Debug.Log(_val);
        }
    }

}