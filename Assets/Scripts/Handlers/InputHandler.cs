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
    [SerializeField] private KeyCode Pause;

    private bool isJumpPressed;
    private bool isAttackPressed;
    private bool isShootPressed;
    private bool isPausePressed;
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
        isPausePressed = false;
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
        
        if (Input.GetKeyDown(Pause))
        {
            isPausePressed = true;
        }
        else if (!Input.GetKeyDown(Pause))
        {
            isPausePressed = false;
        }

    }

    public Vector2 GetMove() { return moveInput; }
    public bool GetJump() { return isJumpPressed; }
    public bool GetAttack() { return isAttackPressed; }
    public bool GetShoot() { return isShootPressed; }
    public bool GetPause() { return isPausePressed; }

    public KeyCode ReturnJump() { return Jump; }
}
