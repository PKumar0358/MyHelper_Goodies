using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PRK_PhotonLib
{
    using Photon.Pun;
    using Photon.Realtime;
    public partial class PNetworkManager
    {
        private static PNetworkManager _Instance;
        private PConnectionManager connectionManager;
        private PLobbyManager lobbyManager;
        private PRoomManager roomManager;
        private static bool _IsInited = false;


    }
    public partial class PNetworkManager : MonoBehaviour
    {
        private void Awake()
        {
            if (!_IsInited)
            {
                if(_Instance== null)
                {
                    _Instance = this;
                    DontDestroyOnLoad(gameObject);
                }
                Init();
            }
        }

        private void Start()
        {
            Connect();
        }

        private void OnDestroy()
        {
            connectionManager.Dispose();
            lobbyManager.Dispose();
            roomManager.Dispose();

            connectionManager = null;
            lobbyManager = null;
            roomManager = null;
            _Instance = null;
        }

        public void CreateRoom()
        {
           
        }
    }
    public partial class PNetworkManager
    {
        private void Init()
        {           
            connectionManager = new PConnectionManager();
            lobbyManager = new PLobbyManager();
            roomManager = new PRoomManager();
            _IsInited = true;           
        }

        public static void Connect()
        {
            if(!_IsInited)
                Instance.Init();
            Instance.lobbyManager.Add_LobbyJoinListener((a, b) =>
            {
                Debug.Log($"{a},{b}");
                Instance.roomManager.Create("simple", (a, success) =>
                {
                    Debug.Log("room created");
                });
            });
            PhotonNetwork.ConnectUsingSettings();
        }
        public static PNetworkManager Instance
        {
            get
            {
                if (_Instance == null)
                {
                    GameObject g = new GameObject("PNetworkManager");
                    _Instance = g.AddComponent<PNetworkManager>();
                    DontDestroyOnLoad(g);
                }
                return _Instance;
            }
        }
    }
}
