using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform characterTransform;
    public LayerMask groundMask;

    public float moveSpeed = 50f;
    public float brakeForce = .5f;
    public float maxSpeed = 5f;
    public float turnSpeed = 15f;
    public float jumpForce = 750f;
    public float gravityModifier = .1f;

    private Vector2 m_Move;
    private bool m_Jump;
    private Rigidbody m_Rigidbody;
    private Animator m_Animator;
    private bool m_CanMove = false;
    private bool m_IsGrounded = true;

    private float m_JumpDelay = 0.3f;
    private float m_NextJumpTime = 0f;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        m_Move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        m_Jump = Input.GetButton("Jump");

        m_CanMove = (Mathf.Abs(m_Move.x) > 0 || Mathf.Abs(m_Move.y) > 0);

        m_IsGrounded = (Physics.Raycast(transform.position, Vector3.down, 0.3f, groundMask));


    }

    void FixedUpdate()
    {
        if (m_CanMove)
        {
            Vector3 moveDirection = new Vector3(m_Move.x, 0, m_Move.y).normalized;
            
            if(new Vector3(m_Rigidbody.velocity.x, 0, m_Rigidbody.velocity.z).magnitude < maxSpeed)
            {
                m_Rigidbody.velocity += moveDirection * moveSpeed * Time.deltaTime;
            }

            Vector3 viewDirection = m_Rigidbody.velocity.normalized;
            Quaternion newRotation = Quaternion.Lerp(characterTransform.transform.rotation, Quaternion.LookRotation(viewDirection, Vector3.up), Time.deltaTime * turnSpeed);
            characterTransform.localEulerAngles = new Vector3(0, newRotation.eulerAngles.y, 0);
        }

        if(m_IsGrounded)
        {
            if(m_Jump && m_NextJumpTime < Time.time)
            {
                m_Rigidbody.AddForce(Vector3.up * jumpForce);
                m_NextJumpTime = Time.time + m_JumpDelay;
            }

            if (m_Rigidbody.velocity.sqrMagnitude > 1)
            {
                m_Rigidbody.velocity += -m_Rigidbody.velocity.normalized * brakeForce;
            }
        }
        else
        {
            m_Rigidbody.velocity += Physics.gravity * gravityModifier;
        }

        m_Animator.SetFloat("speed", new Vector3(m_Rigidbody.velocity.x, 0, m_Rigidbody.velocity.z).magnitude);
        m_Animator.SetBool("isGrounded", m_IsGrounded);


    }
}
