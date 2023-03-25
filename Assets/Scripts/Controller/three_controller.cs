using Cinemachine.Utility;
using flat_land.camera;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace flat_land.controller
{
    [RequireComponent(typeof(Rigidbody))]
    public class three_controller : AbstractController
    {
        [SerializeField] float speed;
        [SerializeField] float maxSpeed;
        Rigidbody rb = null;

        [SerializeField] CinemachinePOVExt pOVExt = null;
        [SerializeField] Transform forwardTransform = null;
        [SerializeField] float RotationSpeed = 10;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>(); 
        }

        internal override void Interacts()
        {
            throw new System.NotImplementedException();
        }
        internal override void MouseClicked()
        {
            Debug.Log("Maybe some action could be triggered");
        }

        internal override void MouseMove(Vector2 direction)
        {
            if (pOVExt != null)
            {
                pOVExt.SetMousePosition(direction, RotationSpeed);
                //Vector3 newRot = transform.rotation.eulerAngles;
                //newRot.y += direction.x * Time.deltaTime * RotationSpeed;

                //transform.rotation = Quaternion.Euler(newRot);
            }
        }

        internal override void Move(Vector2 direction)
        {
            Vector3 transformedDirection = forwardTransform.forward * direction.y + forwardTransform.right * direction.x;

            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed); 
            }

            rb.AddForce(transformedDirection * speed * Time.deltaTime);
        }

        internal override void PressSpaceBar()
        {
            Debug.Log("Maybe some action could be triggered");
        }
    }
}

