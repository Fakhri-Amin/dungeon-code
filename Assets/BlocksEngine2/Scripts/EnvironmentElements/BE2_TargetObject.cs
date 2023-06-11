using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MG_BlocksEngine2.Environment
{
    public class BE2_TargetObject : MonoBehaviour, I_BE2_TargetObject
    {
        private Vector3 startPosition;
        public Transform Transform => transform;

        public I_BE2_ProgrammingEnv ProgrammingEnv { get; set; }

        private CollisionHandler collisionHandler;

        private void Awake()
        {
            collisionHandler = GetComponent<CollisionHandler>();
        }

        private void Update()
        {
            // Debug.DrawRay(transform.position + Vector3.up * 0.5f, transform.right, Color.yellow);
            // Debug.DrawRay(transform.position + Vector3.up * 0.5f, -transform.right, Color.yellow);
        }

        public void SetActiveStatus(bool condition)
        {
            GameManager.Instance.isRunning = condition;
        }

        public bool GetSidewayInfo(Vector3 direction)
        {
            Debug.DrawRay(Transform.position + Vector3.up * 0.5f, direction, Color.yellow);
            RaycastHit hit;

            if (Physics.Raycast(Transform.position + Vector3.up * 0.5f, direction, out hit, 1f))
            {
                if (hit.collider.gameObject.TryGetComponent<RotatingItem>(out RotatingItem rotatingItem))
                {
                    return true;
                }

                if (hit.collider.gameObject.TryGetComponent<NumberCollectableItem>(out NumberCollectableItem number))
                {
                    return true;
                }

                // Debug.Log("There's a path to go!");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}