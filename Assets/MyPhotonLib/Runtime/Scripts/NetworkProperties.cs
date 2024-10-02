using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace PRK_PhotonLib
{
    
    public partial class NetworkProperties :MonoBehaviour
    {
        NetworkProperties_F tmp;
        private void Start()
        {
            Dictionary<string,object>o = new Dictionary<string,object>();
            object[] ht=new object[0];
            Debug.Log(ObjectToByteArrayConverter.ObjectToByteArray(ht).Length);
        }
    }
    public partial class NetworkProperties_F 
    {
        private NetworkDataDictionary<string, object> m_DataList;
       

    }

    public partial class NetworkProperties_F
    {
        private NetworkProperties_F ()
        {
            m_DataList=new NetworkDataDictionary<string, object>();
        }

        public static NetworkProperties_F New
        {
            get
            {
                return new NetworkProperties_F();
            }
        }

        public void Set(string ke,object val)
        {
           if(m_DataList.Contains(ke))
            {
                m_DataList[ke]=val;
            }
            else
            {
                m_DataList.Add(ke,val);
            }
        }
    }

    public static class ObjectToByteArrayConverter
    {
        public static byte[] ObjectToByteArray(object obj)
        {
          
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, obj);
                return memoryStream.ToArray();
            }
        }
    }

    public class NetworkDataDictionary<tKey,tValue>
    {
        private Dictionary<tKey, bool> m_ChangeTracker;
        private List<tKey> m_Keys;
        private Dictionary<tKey, tValue> m_Dict;
        public NetworkDataDictionary()
        {
            m_Dict = new Dictionary<tKey, tValue>();
            m_Keys = new List<tKey>();
            m_ChangeTracker = new Dictionary<tKey, bool>();
        }

        public void Add(tKey ke, tValue val)
        {
            m_Dict.Add(ke, val);
            m_Keys.Add(ke);
            m_ChangeTracker.Add(ke, true);
        }

        public void Remove(tKey ke)
        {
            m_Dict.Remove(ke);
            m_Keys.Remove(ke);
            m_ChangeTracker.Remove(ke);
        }

        public bool Contains(tKey ke)=>m_Dict.ContainsKey(ke);

       
        public int KeyIndex(tKey ke) => m_Keys.IndexOf(ke);

        public tValue this[tKey ke]
        {
            get
            {
                return m_Dict[ke];
            }
            set
            {
                m_Dict[ke] = value;
                m_ChangeTracker[ke] = true;
            }
        }
        public tValue this[int index]
        {
            get
            {
                return m_Dict[m_Keys[index]];
            }
            set
            {
                m_Dict[m_Keys[index]] = value;
                m_ChangeTracker[m_Keys[index]] = true;
            }
        }
        public bool IsChanged(tKey ke)
        {
            return m_ChangeTracker[ke];
        }
        public bool IsChanged(int index)
        {
            return m_ChangeTracker[m_Keys[index]];
        }

        public void SetChangeState(tKey ke,bool state_)
        {
            m_ChangeTracker[ke]=state_;
        }

        public void SetChangeState(int index, bool state_)
        {
            m_ChangeTracker[m_Keys[index]] = state_;
        }
    }
   
    public enum PE_Codes:byte
    {
        None,
        Event1,
        Event2,
        Event3,
        Event4,
    }

}
