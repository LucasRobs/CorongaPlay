using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Stone.MasterHouse.CameraControl
{
    public class CameraControler : MonoBehaviour
    {
        public static CameraControler instance { get; private set; }
        [SerializeField] private Transform target_;
        [SerializeField] Vector3 offser;
        [SerializeField] float smother = 0.125f;

        private void Start()
        {
            instance = this;
        }

        private void LateUpdate()
        {
            if (target_)
            {
                Vector3 desirePos = target_.position + offser;
                Vector3 smothPos = Vector3.Lerp(transform.position, desirePos, smother);
                transform.position = smothPos;

            }
            else
            {
                target_ = _Stone.MasterHouse.MasterHouse.instance.transform;
            }




        }

    }

}
