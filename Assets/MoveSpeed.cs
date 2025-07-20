using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardMover : MonoBehaviour
{
    public InputActionAsset inputActions;  // Drag your .inputactions file here
    public float moveSpeed = 5f;

    private InputAction moveAction;

    void Awake()
    {
        var playerMap = inputActions.FindActionMap("Player");
        moveAction = playerMap.FindAction("Move");
    }

    void OnEnable() => moveAction?.Enable();
    void OnDisable() => moveAction?.Disable();

    void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 direction = new Vector3(input.x, 0, input.y);
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.Self);
    }
}