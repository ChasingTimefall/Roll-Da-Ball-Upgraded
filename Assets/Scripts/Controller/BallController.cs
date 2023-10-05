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

    Vector3 vecStartPoint;
    void Start()
    {
        pRigidBody = GetComponent<Rigidbody>();
        vecStartPoint = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "FloorIsLava" || collision.gameObject.name == "Finish")
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(0);
        }

        if (collision.gameObject.name == "RampFirst")
        {
            bInCollisionWithRamp = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "RampFirst")
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

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0.0f || verticalInput != 0.0f)
        {
            Vector3 vecMove = new Vector3(horizontalInput, 0.0f, verticalInput);
            vecMove.Normalize();

            pRigidBody.velocity = new Vector3(vecMove.x * flMoveSpeedPerFrame, pRigidBody.velocity.y, pRigidBody.velocity.z);
        }

        pRigidBody.velocity = new Vector3(pRigidBody.velocity.x, pRigidBody.velocity.y, 2f * flMoveSpeedPerFrame);

        if (bInCollisionWithRamp)
            pRigidBody.velocity = new Vector3(pRigidBody.velocity.x, pRigidBody.velocity.y, 8f * flMoveSpeedPerFrame);


    }

}