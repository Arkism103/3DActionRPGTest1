using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Animator animator;

    private Vector3 latestPos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var a = Input.GetAxis("Horizontal");//左右
        var b = Input.GetAxis("Vertical");//上下

        Vector3 diff = transform.position - latestPos;
        latestPos = transform.position;

        if(Input.GetKeyDown("up"))
        {
            transform.position += transform.forward * 0.1f;
            animator.SetBool("RunBool", true);
            if(diff.magnitude > 0.01f)
            {
                transform.rotation = Quaternion.LookRotation(diff);
            }
        }

        else
        {
            animator.SetBool("RunBool", false);
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(0, 10, 0);
        }
        if (Input.GetKey("left"))
        {
            transform.Rotate(0, -10, 0);
        }
    }
}
