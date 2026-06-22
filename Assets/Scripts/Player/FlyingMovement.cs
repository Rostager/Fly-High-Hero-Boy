using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

/* 
 * Super super simple movement, will be changed later
 */

public class FlyingMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;

    [SerializeField] private float forwardSpeed;
    [SerializeField] private float yawSpeed;
    [SerializeField] private float pitchSpeed;

    private void OnEnable()
    {
        moveAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
    }

    private void Update()
    {
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();

        float yaw = moveInput.x * yawSpeed * Time.deltaTime;
        float pitch = moveInput.y * pitchSpeed * Time.deltaTime;

        transform.Rotate(pitch, yaw, 0f, Space.Self);

        Vector3 forwardMovement = transform.forward * forwardSpeed * Time.deltaTime;
        transform.position += forwardMovement;
    }

}
