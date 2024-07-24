using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Animation_Manager2 : MonoBehaviour
{
    Animator animator;
    float VelocityZ = 0.0f;
    float VelocityX = 0.0f;
    public float acceleration;
    public float deceleration;
    public float maximumWalkVelocity = 0.5f;
    public float maximumRunVelocity = 2.0f;



    //Increase Performance
    int VelocityZHash;
    int VelocityXHash;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();


        //Increase Performance 
        VelocityZHash = Animator.StringToHash("VelocityZ");
        VelocityXHash = Animator.StringToHash("VelocityX");

    }

    // Update is called once per frame
    void Update()
    {
        bool jumpPressed = Input.GetKey(KeyCode.Space);
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool backPressed = Input.GetKey(KeyCode.S);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        //this statement is called a Ternary Operator and it will set the varialbe equal to the first value after the question mark if the question mark is true. else it will set it to the second value if false__Basically a disguise If Statement
        float currentMaxVelocity = runPressed ? maximumRunVelocity : maximumWalkVelocity;


        changeVelocity(forwardPressed, leftPressed, rightPressed, backPressed, runPressed, currentMaxVelocity);
        lockOrResetVelocity(forwardPressed, leftPressed, rightPressed, backPressed, runPressed, currentMaxVelocity);

        animator.SetFloat(VelocityZHash, VelocityZ);
        animator.SetFloat(VelocityXHash, VelocityX);

        if (jumpPressed && !forwardPressed)
        {
            animator.SetBool("canJump", true);
            StartCoroutine(resetJump(0.6f));
        }

        if (jumpPressed && forwardPressed)
        {
            animator.SetBool("canJumpForward", true);
            StartCoroutine(resetJump(0.6f));
        }


    }








    void lockOrResetVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool backPressed, bool runPressed, float currentMaxVelocity)
    {

        //Running Cap Forward
        if (forwardPressed && runPressed && VelocityZ > currentMaxVelocity)
        {
            VelocityZ = currentMaxVelocity;
        }
        //decelerate to the maximum walk velocity
        else if (forwardPressed && VelocityZ > currentMaxVelocity)
        {
            VelocityZ -= Time.deltaTime * deceleration;
            //round to the currentMaxVelocity if within offset
            if (VelocityZ > currentMaxVelocity && VelocityZ < (currentMaxVelocity + 0.05))
            {
                VelocityZ = currentMaxVelocity;
            }
        }
        //round to the currentMaxVelocity if Within offset
        else if (forwardPressed && VelocityZ < currentMaxVelocity && VelocityZ > (currentMaxVelocity - 0.05f))
        {
            VelocityZ = currentMaxVelocity;
        }



        //Running Cap Left
        if (leftPressed && runPressed && VelocityX < -currentMaxVelocity)
        {
            VelocityX = -currentMaxVelocity;
        }
        //decelerate to the maximum walk velocity
        else if (leftPressed && VelocityX < -currentMaxVelocity)
        {
            VelocityX += Time.deltaTime * deceleration;
            //round to the currentMaxVelocity if within offset
            if (VelocityX > -currentMaxVelocity && VelocityX > (-currentMaxVelocity - 0.05))
            {
                VelocityX = -currentMaxVelocity;
            }
        }
        //round to the currentMaxVelocity if Within offset
        else if (leftPressed && VelocityX > -currentMaxVelocity && VelocityX < (-currentMaxVelocity + 0.05f))
        {
            VelocityX = -currentMaxVelocity;
        }


        //Running Cap Right
        if (rightPressed && runPressed && VelocityX > currentMaxVelocity)
        {
            VelocityX = currentMaxVelocity;
        }
        //decelerate to the maximum walk velocity
        else if (rightPressed && VelocityX > currentMaxVelocity)
        {
            VelocityX -= Time.deltaTime * deceleration;
            //round to the currentMaxVelocity if within offset
            if (VelocityX > currentMaxVelocity && VelocityX < (currentMaxVelocity + 0.05))
            {
                VelocityX = currentMaxVelocity;
            }
        }
        //round to the currentMaxVelocity if Within offset
        else if (rightPressed && VelocityX < currentMaxVelocity && VelocityX > (currentMaxVelocity - 0.05f))
        {
            VelocityX = currentMaxVelocity;
        }


        //Running Cap Back
        if (backPressed && runPressed && VelocityZ < -currentMaxVelocity)
        {
            VelocityZ = -currentMaxVelocity;
        }
        //decelerate to the maximum walk velocity
        else if (backPressed && VelocityZ < -currentMaxVelocity)
        {
            VelocityZ += Time.deltaTime * deceleration;
            //round to the currentMaxVelocity if within offset
            if (VelocityZ > -currentMaxVelocity && VelocityZ > (-currentMaxVelocity - 0.05))
            {
                VelocityZ = -currentMaxVelocity;
            }
        }
        //round to the currentMaxVelocity if Within offset
        else if (backPressed && VelocityZ > -currentMaxVelocity && VelocityZ < (-currentMaxVelocity + 0.05f))
        {
            VelocityZ = -currentMaxVelocity;
        }

    }



    void changeVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, bool backPressed, bool runPressed, float currentMaxVelocity)
    {

        


        //Increase Velocity

        if (forwardPressed && VelocityZ < currentMaxVelocity)
        {
            VelocityZ += Time.deltaTime * acceleration;
        }

        if (leftPressed && VelocityX > -currentMaxVelocity)
        {
            VelocityX -= Time.deltaTime * acceleration;
        }

        if (backPressed && VelocityZ > -currentMaxVelocity)
        {
            VelocityZ -= Time.deltaTime * acceleration;
        }

        if (rightPressed && VelocityX < currentMaxVelocity)
        {
            VelocityX += Time.deltaTime * acceleration;
        }

        //Decrease Velocity

        if (!forwardPressed && VelocityZ > 0.0f)
        {
            VelocityZ -= Time.deltaTime * deceleration;
        }

        if (!backPressed && VelocityZ < 0.0f)
        {
            VelocityZ += Time.deltaTime * deceleration;
        }

        if (!forwardPressed && !backPressed && VelocityZ != 0.0f && (VelocityZ > -0.05f && VelocityZ < 0.05f))
        {
            VelocityZ = 0.0f;
        }

        if (!leftPressed && VelocityX < 0.0f)
        {
            VelocityX += Time.deltaTime * deceleration;
        }

        if (!rightPressed && VelocityX > 0.0f)
        {
            VelocityX -= Time.deltaTime * deceleration;
        }

        if (!leftPressed && !rightPressed && VelocityX != 0.0f && (VelocityX > -0.05f && VelocityX < 0.05f))
        {
            VelocityX = 0.0f;
        }


    }

    IEnumerator resetJump(float delay)
    {

        yield return new WaitForSeconds(0.6f);
        animator.SetBool("canJump", false);
        animator.SetBool("canJumpForward", false);

    }


}
