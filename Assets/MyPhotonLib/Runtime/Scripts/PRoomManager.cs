
namespace PRK_PhotonLib
{
    using Photon.Pun;
    using Photon.Realtime;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using PHashTable = ExitGames.Client.Photon.Hashtable;
    public class PRoomManager : IInRoomCallbacks,IMatchmakingCallbacks,IDisposable
    {
        private Queue<Action<object,bool>> OnRoomCreatedTempListeners;
        private Queue<Action<object,bool>> OnRoomJoinTempListeners;

        public void Create(string name_,Action<object, bool> createListener_)
        {
            OnRoomCreatedTempListeners.Enqueue(createListener_);
            PhotonNetwork.CreateRoom(name_);
        }
        public void JoinRoom(string name_, Action<object, bool> createListener_)
        {
            OnRoomJoinTempListeners.Enqueue(createListener_);
            PhotonNetwork.JoinRoom(name_);
        }
        public PRoomManager()
        {
            OnRoomCreatedTempListeners=new Queue<Action<object,bool>>();
            OnRoomJoinTempListeners = new Queue<Action<object,bool>>();
            PhotonNetwork.AddCallbackTarget(this);
        }
        public void Dispose()
        {
            PhotonNetwork.RemoveCallbackTarget(this);
        }

        public void OnCreatedRoom()
        {
            if(OnRoomCreatedTempListeners.Count > 0)
            {
                while(OnRoomCreatedTempListeners.Count >0)
                {
                    OnRoomCreatedTempListeners.Dequeue().Invoke("",true);
                }
            }
        }

      


        public void OnJoinedRoom()
        {
            Debug.Log("OnRoomJoined");
            if (OnRoomJoinTempListeners.Count > 0)
            {
                while (OnRoomJoinTempListeners.Count > 0)
                {
                    OnRoomJoinTempListeners.Dequeue().Invoke("joined", true);
                }
            }
        }

        public void OnJoinRandomFailed(short returnCode, string message)
        {
        }

        public void OnJoinRoomFailed(short returnCode, string message)
        {
        }

        public void OnLeftRoom()
        {
        }

        public void OnMasterClientSwitched(Player newMasterClient)
        {
        }

        public void OnPlayerEnteredRoom(Player newPlayer)
        {
        }

        public void OnPlayerLeftRoom(Player otherPlayer)
        {
        }

        public void OnPlayerPropertiesUpdate(Player targetPlayer, PHashTable changedProps)
        {
        }

        public void OnRoomPropertiesUpdate(PHashTable propertiesThatChanged)
        {
        }
        public void OnCreateRoomFailed(short returnCode, string message)
        {
        }

        public void OnFriendListUpdate(List<FriendInfo> friendList)
        {
        }
    }
}
