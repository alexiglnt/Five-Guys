using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMinimap : MonoBehaviour
{
      public Transform target;
        public float lerpSpeed = 3.5f;

        private Vector3 offset;

        private Vector3 targetPos;

        private void Start()
        {
            if (target == null) return;

            offset = target.position;
            offset.z = -11;
        }

        private void Update()
        {
            if (target == null)
                target = GameObject.FindGameObjectWithTag("Player").transform;

            targetPos = target.position;
            targetPos.z = -11;
            transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
        }
}
