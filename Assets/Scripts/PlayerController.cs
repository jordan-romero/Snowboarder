using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float torqueAmount = 1;
    SurfaceEffector2D surfaceEffector2D;

    [SerializeField] float boostSpeed = 50f;
    [SerializeField] float normalSpeed = 20f; 

    bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
       rb2d = GetComponent<Rigidbody2D>(); 
       surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }
    void RotatePlayer()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        } 
    }

    void RespondToBoost()
    {
        
        if(Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        } else
        {
            surfaceEffector2D.speed = normalSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }
}
