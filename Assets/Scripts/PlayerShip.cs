using System;
using UnityEngine;

public class PlayerShip : Ship
{

    Gun[] guns;

    float moveSpeed = 7;

    bool moveUp;
    bool moveDown;
    bool moveLeft;
    bool moveRight;

    bool shoot;
[NonSerialized]
    public float deltaPositionx = 0;

    // public Animator Controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       guns = transform.GetComponentsInChildren<Gun>();

       var shootAnimation = Animator.StringToHash("Base Layer.ATTACK");

       // Controller.Play(shootAnimation);
    }

    // Update is called once per frame
    void Update()
    {
        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

        shoot = Input.GetKeyDown(KeyCode.RightShift);
        if (shoot)
        {
            shoot = false;
            foreach(Gun gun in guns)
            {
                gun.Shoot();
            }
        }
          
    }


    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.fixedDeltaTime;
        Vector2 move = Vector2.zero;

        if (moveUp)
        {
            move.y += moveAmount;
        }

        if (moveDown)
        {
            move.y -= moveAmount;
        }

        if (moveLeft)
        {
            move.x -= moveAmount;
        }

        if (moveRight)
        {
            move.x += moveAmount;
        }

        float moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y * move.y);
        if (moveMagnitude > moveAmount)
        {
            float ratio = moveAmount / moveMagnitude;
            move *= ratio;
        }
        
        pos += move;
        if (pos.x <= -4)
        {
            pos.x = -4;
        }
        if (pos.x >= 22)
        {
            pos.x = 22;
        }
        if (pos.y <= -1.75f)
        {
            pos.y = -1.75f;
        }
        if (pos.y >= 11.8f)
        {
            pos.y = 11.8f;
        }

        transform.position = pos;

        deltaPositionx = move.x;

    }

}
