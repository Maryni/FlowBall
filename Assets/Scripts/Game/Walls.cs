using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    [SerializeField] private MoveToTarget moveToTarget;
    private Vector3 currentDirection;
    private Vector3 reflectedDirection;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            currentDirection = moveToTarget.Direction;      //получив наше направление что было
            if (collision.gameObject.name == "Wall1")
            {
                reflectedDirection = Vector3.Reflect(currentDirection, new Vector3(0, 0, -1));  //делаем отражение этого направления
                //Debug.DrawLine(transform.position, Vector3.Reflect(currentDirection, new Vector3 (0, 0, -1)),Color.red);
            }
            if(collision.gameObject.name == "Wall2")
            {
                reflectedDirection = Vector3.Reflect(currentDirection, new Vector3(0, 0, 1));
                //Debug.DrawLine(transform.position, Vector3.Reflect(currentDirection, new Vector3(0, 0, -1)), Color.red);
            }
            if (collision.gameObject.name == "Wall3")
            {
                reflectedDirection = Vector3.Reflect(currentDirection, new Vector3(-1, 0, 0));
                //Debug.DrawLine(transform.position, Vector3.Reflect(currentDirection, new Vector3(-1, 0, 0)), Color.red);
            }
            if (collision.gameObject.name == "Wall4")
            {
                reflectedDirection = Vector3.Reflect(currentDirection, new Vector3(1, 0, 0));
                //Debug.DrawLine(transform.position, Vector3.Reflect(currentDirection, new Vector3(1, 0, 0)), Color.red);
            }
            
            UseDirection();     //и примерняем это направление
        }
    }
    void UseDirection()
    {
        moveToTarget.SetDirection(reflectedDirection);
        moveToTarget.SetTargetPositionEnd(transform.position);
        moveToTarget.SetTargetPosition(transform.position - reflectedDirection);
        moveToTarget.UseForce(true); //применяяем силу
    }
}
