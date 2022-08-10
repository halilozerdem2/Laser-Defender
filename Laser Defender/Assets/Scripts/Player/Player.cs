using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 rawInput;

    [SerializeField] private float moveSpeed = 5f;
     
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        transform.position += delta;
    }

    private void OnMove(InputValue value)
    {
        value.Get<Vector2>();
        rawInput = value.Get<Vector2>();
    }
}
