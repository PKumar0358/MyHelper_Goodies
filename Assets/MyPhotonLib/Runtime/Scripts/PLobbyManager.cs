
namespace PRK_PhotonLib
{
    using Photon.Pun;
    using Photon.Realtime;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PLobbyManager : ILobbyCallbacks,IDisposable
    {
        private Queue<Action<bool, object>> TempLobbyJoinListeners;
        public void Add_LobbyJoinListener(Action<bool, object> listener_)
        {
            TempLobbyJoinListeners.Enqueue(listener_);
        }
        public PLobbyManager()
        {
            TempLobbyJoinListeners=new Queue<Action<bool, object>>();
            PhotonNetwork.AddCallbackTarget(this);
        }

        public void Dispose()
        {
            PhotonNetwork.RemoveCallbackTarget(this);
            
            Debug.Log($"Disposed Loby");
        }
        ~PLobbyManager()
        {
            Dispose();
        }
        public void OnJoinedLobby()
        {
            Debug.Log($"OnJoinedLobby");
            if(TempLobbyJoinListeners.Count > 0)
            {
                while(TempLobbyJoinListeners.Count > 0)
                {
                    TempLobbyJoinListeners.Dequeue().Invoke(true,"");
                }
            }
        }

        public void OnLeftLobby()
        {

        }

        public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
        {

        }

        public void OnRoomListUpdate(List<RoomInfo> roomList)
        {

        }
    }
}
