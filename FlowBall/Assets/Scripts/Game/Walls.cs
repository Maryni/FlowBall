using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    [SerializeField] MoveToTarget moveToTarget;
    Vector3 temp;
    Vector3 temp2;
    private void OnCollisionEnter(Collision collision)
    { 
        if(collision.gameObject.name=="Wall1")
        {
            temp = moveToTarget.direction; //получив наше направление что было
            temp2 = Vector3.Reflect(temp, new Vector3(0, 0, -1));  //делаем отражение этого направления
            UseDirection(); //и примерняем это направление
            Debug.DrawLine(transform.position, Vector3.Reflect(temp, new Vector3 (0, 0, -1)),Color.red);
        }
        if(collision.gameObject.name == "Wall2")
        {
            temp = moveToTarget.direction;
            temp2 = Vector3.Reflect(temp, new Vector3(0, 0, 1));
            UseDirection();
            Debug.DrawLine(transform.position, Vector3.Reflect(temp, new Vector3(0, 0, -1)), Color.red);
        }
        if (collision.gameObject.name == "Wall3")
        {
            temp = moveToTarget.direction;
            temp2 = Vector3.Reflect(temp, new Vector3(-1, 0, 0));
            UseDirection();
            Debug.DrawLine(transform.position, Vector3.Reflect(temp, new Vector3(-1, 0, 0)), Color.red);
        }
        if (collision.gameObject.name == "Wall4")
        {
            temp = moveToTarget.direction;
            temp2 = Vector3.Reflect(temp, new Vector3(1, 0, 0));
            UseDirection();
            Debug.DrawLine(transform.position, Vector3.Reflect(temp, new Vector3(1, 0, 0)), Color.red);
        }
    }
    void UseDirection()
    {
        moveToTarget.direction = temp2;
        moveToTarget.targPosEnd = transform.position;
        moveToTarget.targPos = transform.position - temp2;
        moveToTarget.UseForce(); //применяяем силу
    }
}
