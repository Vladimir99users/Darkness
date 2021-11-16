using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespace UnityStandardAssets._2D
//{
    public class Camera2DFollow : MonoBehaviour
    {
    public bool flag = true;
        public GameObject Player;
        public Transform target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;
        public static Camera2DFollow _instanteat;

        // Use this for initialization
         private void Start()
        {
        if (_instanteat) Destroy(_instanteat);
        _instanteat = this;
        StardedPlayer();
        }


        public void StardedPlayer()
        {
            //поиск нового объекта с названным тегом.
            Player = GameObject.FindGameObjectWithTag("Player");
            target = Player.transform;
            m_LastTargetPosition = target.position;
            m_OffsetZ = (transform.position - target.position).z;
            transform.parent = null;
        }
        // Update is called once per frame
        private void Update()
        {

        if (flag)
         {
            if (Player == null)
            {
                StardedPlayer();
            }

            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (target.position - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward * m_OffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

            transform.position = newPos;

            m_LastTargetPosition = target.position;
         }
            
        }

        public void StopCamera()
        {
        flag = false;
         }

        public void StartCamera()
        {
        flag = true;
        }


}



    
//}
