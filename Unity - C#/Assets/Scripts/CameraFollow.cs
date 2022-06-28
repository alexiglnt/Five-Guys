using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //let camera follow target
    public class CameraFollow : MonoBehaviour
    {
        private Transform target;
        public float lerpSpeed = 3.5f;

        private Vector3 offset;

        private Vector3 targetPos;

        private void Awake()
        {
            if (target != null)
            {
                offset = target.position;
                offset.z = -10;
            }

        }

        private void Update()
        {
            if (target == null)
                target = GameObject.FindGameObjectWithTag("Player").transform;

            targetPos = target.position;
            targetPos.z = -10;
            transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
        }

        public void SetTarget(Transform new_target)
        {
            target=new_target;
        }
}
