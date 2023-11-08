using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BallController : MonoBehaviour
{

    bool bInCollisionWithRamp = false;
    float flMoveSpeedPerFrame = 3.5f;
    Rigidbody pRigidBody;
    Camera CamObj;

    Vector3 vecStartPoint;
    void Start()
    {
        pRigidBody = GetComponent<Rigidbody>();
        CamObj = Camera.main;
        vecStartPoint = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Finish")
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(3);
        }

        if (collision.gameObject.name == "AnimCube" || collision.gameObject.name == "AnimSphere" || collision.gameObject.name == "FloorIsLava" || collision.gameObject.name == "Left" || collision.gameObject.name == "Right")
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(2);
        }

        if (collision.gameObject.name == "SpeedRamp")
        {
            bInCollisionWithRamp = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "SpeedRamp")
        {
            bInCollisionWithRamp = false;
        }
    }

    void OnCollisionStay(Collision collision)
    {
       // if (collision.gameObject.name == "RampFirst")
      //  {
          //  bInCollisionWithRamp = false;
      //  }
    }

    private float _dragObjectSpeed = 0.2f;
    public float rotationSpeed = 75.0f;
    public float walkSpeed;


    private void Move()
    {
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");
        float speed = 5.0f;

        Vector3 forward = CamObj.transform.forward;
        Vector3 right = CamObj.transform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 dir = right * hMove + forward * vMove;
        dir.Normalize();
        Vector3 NewDirection = dir * speed * 2;
        pRigidBody.velocity = new Vector3(NewDirection.x, pRigidBody.velocity.y, NewDirection.z);


        // Set rotation to direction of movement if moving
        if (dir != Vector3.zero)
        {
           // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(forward), 0.2f);
        }

    }

    void Update()
    {
        if (transform.position.y < 0 )
        {
            Scene scene = SceneManager.GetActiveScene();

            if (scene != null)
            {
                SceneManager.LoadScene(2);
                return;
            }

        }

        Move();
        /*
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 vecMove = new Vector3(horizontalInput, 0.0f, verticalInput);
        transform.position += vecMove;

        if (horizontalInput != 0.0f || verticalInput != 0.0f)
        {

            vecMove.Normalize();

            pRigidBody.velocity = new Vector3(vecMove.x * flMoveSpeedPerFrame, pRigidBody.velocity.y, vecMove.y * flMoveSpeedPerFrame);
        }

        //pRigidBody.velocity = new Vector3(pRigidBody.velocity.x, pRigidBody.velocity.y, 2f * flMoveSpeedPerFrame);

        if (bInCollisionWithRamp)
            pRigidBody.velocity = new Vector3(pRigidBody.velocity.x, pRigidBody.velocity.y, 8f * flMoveSpeedPerFrame);
        */

    }

}