using UnityEngine;

public class TakeMousePosition : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    [SerializeField] LayerMask layer2;
    [SerializeField] MoveToTarget moveToTarget;
    [SerializeField] GameObject point;

    private void FixedUpdate()
    {
        if (!moveToTarget.moveSecondVar) MousePos();
            else OnMouseDrag();
    }
    void MousePos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit, layer)) moveToTarget.targPos = hit.point;
        }
        if (Input.GetMouseButtonUp(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit, layer)) moveToTarget.targPosEnd = hit.point;
        }
    }
    private void OnMouseDrag()
    {
        print("start draging");
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 37f); //переменной записываються координаты мыши по иксу и игрику
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition); //переменной - объекту присваиваеться переменная с координатами мыши
        point.transform.position = objPosition; //и собственно объекту записываються координаты
        if(Input.GetMouseButtonDown(0))
        {
            moveToTarget.targPos = new Vector3(point.transform.position.x, 0, point.transform.position.z); //отдаём конечную точку направления в наш Move()
        }
    }
}