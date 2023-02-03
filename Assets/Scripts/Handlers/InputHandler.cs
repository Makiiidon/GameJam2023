using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance;

    private Vector2 moveInput;

    [SerializeField] private KeyCode Jump;
    [SerializeField] private KeyCode Attack;
    [SerializeField] private KeyCode button3;
    [SerializeField] private KeyCode button4;

    private bool isJumpPressed;
    private bool isAttackPressed;
    private bool isButton3Pressed;
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
        isButton3Pressed = false;
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
        
        if (Input.GetKeyDown(button3))
        {
            isButton3Pressed = true;
        }
        else if (!Input.GetKeyDown(button3))
        {
            isButton3Pressed = false;
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
    public bool GeTAttack() { return isAttackPressed; }
    public bool GetButton3() { return isButton3Pressed; }
    public bool GetButton4() { return isButton4Pressed; }

    public KeyCode ReturnJump() { return Jump; }
}
