using Cinemachine.Utility;
using flat_land.camera;
using flat_land.gameManager;
using flat_land.interaction;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        [SerializeField] Transform interactTransform = null;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>(); 
        }

        internal override void Interacts()
        {
            Collider[] colliders = Physics.OverlapSphere(interactTransform.position, 1f);
            colliders.ToList().ForEach(c =>
            {
                if (c.gameObject.layer == 30)
                {
                    GameManager.LoadNextScene(c.GetComponent<GateInteraction>().Interact());
                }
            });
        }

        internal override void MouseClicked()
        {

        }

        internal override void MouseMove(Vector2 direction)
        {
            if (pOVExt != null)
            {
                pOVExt.SetMousePosition(direction, RotationSpeed);
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

        }

        internal override void IPressed()
        {

        }
    }
}

