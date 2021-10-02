using UnityEngine;
using UnityEngine.U2D;

namespace RPGM.Gameplay
{
    /// <summary>
    /// A simple controller for animating a 4 directional sprite using Physics.
    /// </summary>
    public class CharacterController2D : MonoBehaviour
    {
        public float speed = 1;
        public float acceleration = 2;
        public float stepSize = 0.1f;
        private float MinDistanceMovement = 0.2f;

        public Vector3 nextMoveCommand;
        public Animator animator;
        private Vector3 desiredPos;

        new Rigidbody2D rigidbody2D;
        SpriteRenderer spriteRenderer;
        PixelPerfectCamera pixelPerfectCamera;

        enum State
        {
            Idle, Moving
        }

        State state = State.Idle;
        Vector2 currentVelocity;

        public void GoToPosition(Vector3 pos)
        {
            desiredPos = pos;
        }

        void IdleState()
        {
            if (nextMoveCommand != Vector3.zero)
            {
                UpdateAnimator(nextMoveCommand);
                //nextMoveCommand = Vector3.zero;
                state = State.Moving;
            }
        }

        void MoveState()
        {
            UpdateAnimator(nextMoveCommand);
            rigidbody2D.velocity = Vector2.SmoothDamp(rigidbody2D.velocity, nextMoveCommand * speed, ref currentVelocity, acceleration, speed);
            spriteRenderer.flipX = rigidbody2D.velocity.x >= 0 ? false : true;
        }

        void UpdateAnimator(Vector3 direction)
        {
            if (animator)
            {
                animator.SetInteger("WalkX", direction.x < 0 ? -1 : direction.x > 0 ? 1 : 0);
                animator.SetInteger("WalkY", direction.y < 0 ? 1 : direction.y > 0 ? -1 : 0);
            }
        }

        void Update()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
            spriteRenderer.sortingOrder = -(int)(transform.position.y * 100);
            if (desiredPos != Vector3.zero)
            {
                Vector3 movement = Vector3.zero;
                float distX = Mathf.Abs(transform.position.x - desiredPos.x);
                float distY = Mathf.Abs(transform.position.y - desiredPos.y);

                if (distX > MinDistanceMovement && Mathf.Abs(desiredPos.x) > 0)
                {

                    if (transform.position.x > desiredPos.x)
                    {
                        movement = Vector3.left;
                    }
                    else if (transform.position.x < desiredPos.x)
                    {
                        movement = Vector3.right;
                    }
                }

                if (distY > MinDistanceMovement && Mathf.Abs(desiredPos.y) > 0)
                {
                    if (transform.position.y > desiredPos.y)

                    {
                        movement += Vector3.down;
                    }
                    else if (transform.position.y < desiredPos.y)
                    {
                        movement += Vector3.up;
                    }
                }

                nextMoveCommand = movement * stepSize;
            }

            switch (state)
            {
                case State.Idle:
                    IdleState();
                    break;
                case State.Moving:
                    MoveState();
                    break;
            }

        }

        void LateUpdate()
        {
            if (pixelPerfectCamera != null)
            {
                transform.position = pixelPerfectCamera.RoundToPixel(transform.position);
            }
        }

        void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            pixelPerfectCamera = GameObject.FindObjectOfType<PixelPerfectCamera>();
        }
    }
}
