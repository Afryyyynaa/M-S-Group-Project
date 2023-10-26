using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;

    private bool isWalking;

    void Update()
    {

        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * deltaTime;
        float playerSize = .7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.posiiton, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (canMove){
        transform.position += moveDir * moveDistance;
        
        isWalking = moveDir != Vector3.zero;
        
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);

    }

    public bool IsWalking()
    {
        return IsWalking;
    }
}
