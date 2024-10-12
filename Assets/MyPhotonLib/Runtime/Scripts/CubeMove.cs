using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PRK_PhotonLib
{
    public class CubeMove : MonoBehaviour
    {
        

        // Update is called once per frame
        Vector3 target=new Vector3 (0,5f,0);
        private void OnEnable()
        {
            transform.position = Vector3.zero;
        }
        void Update()
        {
            transform.position =  Vector3.MoveTowards(transform.position,target,Time.deltaTime*20f);
            if (transform.position == target)
                target *= -1f;
        }
    }
}
