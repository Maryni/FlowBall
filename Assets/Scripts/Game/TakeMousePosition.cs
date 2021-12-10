using UnityEngine;

public class TakeMousePosition : MonoBehaviour
{
    #region Inspector variables

    [SerializeField] LayerMask layer;
    [SerializeField] LayerMask layer2;
    [SerializeField] MoveToTarget moveToTarget;
    [SerializeField] GameObject point;
    
    #endregion

    #region private variables

    private Camera cam;

    #endregion
    #region Unity functions

    private void FixedUpdate()
    {
        if (!moveToTarget.MoveSecondVariant)
        {
            MousePos();
        }
        else
        {
            OnMouseDrag();
        }
    }

    #endregion

    #region public functions

    public void SetCamera(Camera camera)
    {
        cam = camera;
    }

    #endregion
    #region private fuctions

    private void MousePos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit, layer)) moveToTarget.SetTargetPosition(hit.point);
        }
        if (Input.GetMouseButtonUp(0))
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit, layer)) moveToTarget.SetTargetPositionEnd(hit.point);
        }
    }
    private void OnMouseDrag()
    {
        Debug.Log("start draging");
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 37f); //переменной записываються координаты мыши по иксу и игрику
        Vector3 objPosition = cam.ScreenToWorldPoint(mousePosition); //переменной - объекту присваиваеться переменная с координатами мыши
        point.transform.position = objPosition; //и собственно объекту записываються координаты
        if(Input.GetMouseButtonDown(0))
        {
            moveToTarget.SetTargetPosition(new Vector3(point.transform.position.x, 0, point.transform.position.z)); //отдаём конечную точку направления в наш Move()
        }
    }

    #endregion
    

}