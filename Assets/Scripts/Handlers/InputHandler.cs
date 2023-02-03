using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance;

    private Vector2 moveInput;

    [SerializeField] private KeyCode Jump;
    [SerializeField] private KeyCode Attack;
    [SerializeField] private KeyCode Shoot;
    [SerializeField] private KeyCode button4;

    private bool isJumpPressed;
    private bool isAttackPressed;
    private bool isShootPressed;
    private bool isButton4Pressed;
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        isJumpPressed = false;
        isAttackPressed = false;
        isShootPressed = false;
        isButton4Pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(Jump))
        {
            isJumpPressed = true;
        }
        else if (!Input.GetKeyDown(Jump))
        {
            isJumpPressed = false;
        }

        if (Input.GetKeyDown(Attack))
        {
            isAttackPressed = true;
        }
        else if (!Input.GetKeyDown(Attack))
        {
            isAttackPressed = false;
        }
        
        if (Input.GetKeyDown(Shoot))
        {
            isShootPressed = true;
        }
        else if (!Input.GetKeyDown(Shoot))
        {
            isShootPressed = false;
        }
        
        if (Input.GetKeyDown(button4))
        {
            isButton4Pressed = true;
        }
        else if (!Input.GetKeyDown(button4))
        {
            isButton4Pressed = false;
        }

    }

    public Vector2 GetMove() { return moveInput; }
    public bool GetJump() { return isJumpPressed; }
    public bool GetAttack() { return isAttackPressed; }
    public bool GetShoot() { return isShootPressed; }
    public bool GetButton4() { return isButton4Pressed; }

    public KeyCode ReturnJump() { return Jump; }
}
