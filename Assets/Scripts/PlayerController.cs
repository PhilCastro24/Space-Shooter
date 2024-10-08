using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    Vector2 rawInput;

    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    Shooter shooter;

    Vector2 minBounds;
    Vector2 maxBounds;

    void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    void Start()
    {
        InitBounds();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 delta = moveSpeed * Time.deltaTime * rawInput;
        Vector2 newPos = new Vector2();

        newPos.x = Mathf.Clamp(
            transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);

        newPos.y = Mathf.Clamp(
            transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);

        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        //Debug.Log(rawInput);
    }

    void OnFire(InputValue value) // name of this method should be the same as in Player Input component
    {
        if (shooter != null)
        {
            //Debug.Log("Shooter script is assigned correctly");
            shooter.isFiring = value.isPressed;
        }
    }
}
