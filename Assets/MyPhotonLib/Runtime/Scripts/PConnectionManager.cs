using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PRK_PhotonLib
{
    using Photon.Pun;
    using Photon.Realtime;
    using System;

    public class PConnectionManager : IConnectionCallbacks,IDisposable
    {
       
        public PConnectionManager() 
        { 
            PhotonNetwork.AddCallbackTarget(this);
        }

        public void Dispose()
        {
           PhotonNetwork.RemoveCallbackTarget(this);
        }

        public void OnConnected()
        {

            Debug.LogError($"OnConnected");
        }

        public void OnConnectedToMaster()
        {
            Debug.Log($"OnConnectedToMaster");
            PhotonNetwork.JoinLobby();
        }

        public void OnCustomAuthenticationFailed(string debugMessage)
        {
        }

        public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
        {
        }

        public void OnDisconnected(DisconnectCause cause)
        {
        }

        public void OnRegionListReceived(RegionHandler regionHandler)
        {
        }
    }
}
