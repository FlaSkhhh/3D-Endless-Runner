using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public Collider topHitBox;
    public float lane;
    private float pos;
    private bool laneTransition = false;
    private bool jumping = false;
    private bool falling = false;
    private bool rolling = false;
    private bool grounded = true;
    private Vector3 mov;
    private float nextRoll;
    private float counter=0f;

    void Start()
    {
        lane = 0f;
    }

    void Update()
    {
        grounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);
        //extra ground check
        if (falling && grounded)
        {
            falling = false;
        }
        //front roll at top to avoid premature transition from jump to roll
        if (Input.GetKeyDown(KeyCode.S) && Time.time > nextRoll && !laneTransition && !jumping)
        {
            nextRoll = Time.time + 0.75f;
            animator.SetTrigger("Roll");
            rolling = true;
            return;
        }
        //lane transition to give side momentum and avoid input during lane change
        if (laneTransition)
        {
            if (transform.position.x == pos)
            {
                laneTransition = false;
                mov = new Vector3(0f, 0f, 0f);
                counter = 0f;
            }
        }
        //getting input while not changing lanes
        if (!laneTransition && !falling)
        {
            if (Input.GetKeyDown(KeyCode.A) && lane != -1 && Time.time > nextRoll && !rolling)
            {
                lane = lane - 1;
                pos = transform.position.x - 3f;
                nextRoll = Time.time + 0.7f;
                if (grounded && !jumping)
                {
                    animator.SetTrigger("Left");
                    ObstacleSpeed.instance.roll = true;
                }
                LaneChangeLeft();
                return;
            }
            if (Input.GetKeyDown(KeyCode.D) && lane != 1 && Time.time > nextRoll && !rolling)
            {
                lane = lane + 1;
                pos = transform.position.x + 3f;
                nextRoll = Time.time + 0.7f;
                if (grounded && !jumping)
                {
                    animator.SetTrigger("Right");
                    ObstacleSpeed.instance.roll = true;
                }
                LaneChangeRight();
                return;
            }
            if (Input.GetButtonDown("Jump") && grounded && !rolling && !jumping)
            {
                animator.SetTrigger("Jump");
                nextRoll = Time.time + 0.05f;
                return;
            }
        }
    }

    void FixedUpdate()
    {
        //if (transform.position.x > 3 && laneTransition)
        //{
        //    mov = new Vector3(0f, 0f, 0f);
        //    transform.position = Vector3.MoveTowards(transform.position, new Vector3(pos,0.06f,0f), 0.5f);
        //}
        //if (transform.position.x < -3f && laneTransition)
        //{
        //    mov = new Vector3(0f, 0f, 0f);
        //    transform.position = Vector3.MoveTowards(transform.position, new Vector3(pos, 0.06f, 0f), 0.5f);
        //}
        if (laneTransition && counter<=24f)
        {
            controller.Move(mov * 2f * Time.deltaTime);
            counter++;
        }
        if (rolling)
        {
           controller.Move(new Vector3(0f, -10f, 0f) * Time.deltaTime);
        }
        if (jumping)
        {
           controller.Move(new Vector3(0f,4f,0f)* Time.deltaTime);
        }
        else 
        {
           controller.Move(new Vector3(0f, -5f, 0f) * Time.deltaTime);
        }
    }

    void LaneChangeLeft()
    {
        laneTransition = true;
        mov = new Vector3(-3f, 0f, 0f);
    }

    void LaneChangeRight()
    {
        laneTransition = true;
        mov = new Vector3(3f, 0f, 0f);
    }

    void JumpStart()
    {
        ObstacleSpeed.instance.roll=false;
        jumping = true;
        grounded = false;
    }

    void JumpDescent()
    {
        jumping = false;
        falling = true;
        animator.ResetTrigger("Left");
        animator.ResetTrigger("Right");
    }

    void Roll()
    {
        topHitBox.enabled = false;
    }

    void Rollout()
    {
        rolling = false;
        ObstacleSpeed.instance.roll=false;
    }

    void RolloutFront()
    {
        rolling = false;
        topHitBox.enabled = true;
    }
}
