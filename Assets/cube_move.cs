using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_move : MonoBehaviour
{
    CharacterController Controller;
    float pyOld;
    float pxOld;
    public Vector3 gravityPower = new Vector3(0, -9, 0);
    public bool groundCheck;
    bool isSprinting;

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
        vector3 = 8 * Time.deltaTime * vector3;
        if (isSprinting == true)
        {
            vector3 *= 2f;
        }
        Controller.Move(vector3);
        float py = Input.GetAxis("Mouse Y");
        float px = Input.GetAxis("Mouse X");
        pyOld += px * 5;
        pxOld -= py * 5;
        gameObject.transform.rotation = Quaternion.Euler(0, pyOld, 0);
    }

    void Gravity()
    {
        
        if (groundCheck == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gravityPower.y = Mathf.Sqrt(5*27);
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
