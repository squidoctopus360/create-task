using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragobject : MonoBehaviour
{
    Vector2 mousepos;
    Collider2D col;
    Rigidbody2D RB;
    bool IsGrabbing;
    Vector2 disFromMouse;
    Vector2 lastMousePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKey(KeyCode.Mouse1) && !IsGrabbing)
        {
            if (Physics2D.OverlapPoint(mousepos) && Physics2D.OverlapPoint(mousepos).GetComponent<Rigidbody2D>() != null)
            {
                IsGrabbing = true;
                col = Physics2D.OverlapPoint(mousepos);
                RB = col.GetComponent<Rigidbody2D>();
                disFromMouse = col.transform.position - new Vector3(mousepos.x, mousepos.y, 0f);
                
            }
        }
        else if(Input.GetKey(KeyCode.Mouse1))
        {
            col.transform.position = mousepos + disFromMouse;
            RB.freezeRotation = true;
            RB.velocity = Vector2.zero;
            RB.angularVelocity = 0;
        }
        else if(IsGrabbing)
        {
            IsGrabbing = false;
            RB.freezeRotation = false;
            RB.velocity = (mousepos - lastMousePos)/(Time.deltaTime*10);
        }
        lastMousePos = mousepos;
    }
}
