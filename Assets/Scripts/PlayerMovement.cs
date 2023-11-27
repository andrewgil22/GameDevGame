using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private float fireCooldown = 0.5f;
    private float lastFireTime;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private GameObject pinPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float pinSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        // Check if the cooldown period has elapsed
        if (Time.time - lastFireTime >= fireCooldown)
        {
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && Input.GetButtonDown("Fire1"))
            {
                ShootPinUpwards();
                lastFireTime = Time.time; // Update the last fire time
            }
            else if (Input.GetButtonDown("Fire1"))
            {
                ShootPin();
                lastFireTime = Time.time; // Update the last fire time
            }
        }

        Flip();
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        // Check if horizontal input is non-zero and character needs flipping
        if ((horizontal > 0f && !isFacingRight) || (horizontal < 0f && isFacingRight))
        {
            // Toggle the isFacingRight flag
            isFacingRight = !isFacingRight;

            // Flip the character by scaling along the x-axis
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void ShootPin()
    {
        GameObject pinInstance = Instantiate(pinPrefab, firePoint.position, Quaternion.identity);

        // Set the direction of the pin based on whether the player is facing right or left
        Vector2 direction = isFacingRight ? Vector2.right : Vector2.left;

        SlashMovement slashMovement = pinInstance.GetComponent<SlashMovement>();
        if (slashMovement != null)
        {
            slashMovement.Initialize(pinSpeed, direction);
        }

        // Flip the pin's graphical representation if needed
        if (!isFacingRight)
        {
            Vector3 scale = pinInstance.transform.localScale;
            scale.x *= -1;
            pinInstance.transform.localScale = scale;
        }
    }

    void ShootPinUpwards()
    {
        Quaternion upwardRotation = Quaternion.Euler(0, 0, 90);
        GameObject pinInstance = Instantiate(pinPrefab, firePoint.position, upwardRotation);

        SlashMovement slashMovement = pinInstance.GetComponent<SlashMovement>();
        if (slashMovement != null)
        {
            slashMovement.Initialize(pinSpeed, Vector2.up);
        }
    }





}