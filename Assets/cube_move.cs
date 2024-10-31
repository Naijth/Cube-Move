using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_move : MonoBehaviour
{
    CharacterController Controller;
    public Vector3 gravityPower = new Vector3(0, -9, 0);
    public bool groundCheck;
    bool isSprinting;
    public int speed = 8;
    public int jump = 135;

    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Gravity();
        Running();
    }

    void Move()
    {
        Vector3 vector3 = gameObject.transform.right * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * gameObject.transform.forward;
        vector3 = speed * Time.deltaTime * vector3;
        if (isSprinting == true)
        {
            vector3 *= 2f;
        }
        Controller.Move(vector3);
    }

    void Gravity()
    {
        
        if (groundCheck == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                gravityPower.y = Mathf.Sqrt(jump);
            }
            if (gravityPower.y < -30)
            {
                gravityPower.y = -30f;
            }
        }
        if (groundCheck == false)
        {
            gravityPower.y += -30f * Time.deltaTime;
        }
        Controller.Move(gravityPower * Time.deltaTime);
    }

    void Running()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
        }
    }
}