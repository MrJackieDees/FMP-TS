using System;
using UnityEngine;

public class PlayerShip : Ship
{

    Gun[] guns;



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
            foreach (Gun gun in guns)
            {
                gun.shootdefault();
            }
        }

    }


    private void FixedUpdate()
    {

        Vector2 move = Vector2.zero;

        if (moveUp)
        {
            move.y += 1;
        }

        if (moveDown)
        {
            move.y -= 1;
        }

        if (moveLeft)
        {
            move.x -= 1;
        }

        if (moveRight)
        {
            move.x += 1;
        }

        move.Normalize();

        moveAround(move);
    }

    private void moveAround(Vector2 moveInput)
    {
        Vector2 previousPosition = transform.position;

        moveShipAround(moveInput);

        Vector2 pos = transform.position;

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

        var newPosition = pos;

        deltaPositionx = (newPosition - previousPosition).x;
    }

}
