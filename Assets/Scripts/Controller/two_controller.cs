using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace flat_land.controller
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class two_controller : AbstractController
    {
        Rigidbody2D rb = null;
        [SerializeField] float jumpForce;
        [SerializeField] float jumpTimer;
        float timer = 0;
        [SerializeField] bool isGrounded;
        [SerializeField] float GroundHeight = 0.55f;
        [SerializeField] Transform groundTransform;
        [SerializeField] LayerMask whatsGround;


        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        internal override void Interacts()
        {

        }

        internal override void MouseClicked()
        {

        }

        internal override void MouseMove(Vector2 direction)
        {

        }

        internal override void Move(Vector2 direction)
        {

        }

        internal override void PressSpaceBar()
        {
            HandleJump();
        }

        private void HandleJump()
        {
            if (timer + jumpTimer <= Time.time)
            {
                timer = Time.time;
                if (CheckIsGrounded())
                {
                    isGrounded = true;
                    Vector3 direction = Vector3.up;
                    rb.velocity = direction * jumpForce;
                }
            }
        }

        private bool CheckIsGrounded()
        {
            isGrounded = Physics2D.Raycast(transform.position, Vector3.down, GroundHeight + 0.2f, whatsGround);

            return isGrounded;
        }

        internal override void IPressed()
        {

        }
    }
}

