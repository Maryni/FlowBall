using UnityEngine;
using UnityEngine.Events;

public class TakeMousePosition : MonoBehaviour
{
    #region Inspector variables

    [SerializeField] LayerMask layer;
    [SerializeField] LayerMask layer2;
    [SerializeField] GameObject point;
    
    #endregion

    #region private variables

    private Camera cam;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private UnityAction actionWhenBallReadyToMove;

    #endregion

    #region properties

    public Vector3 StartPoint => startPoint;
    public Vector3 EndPoint => endPoint;

    #endregion
    #region Unity functions

    private void FixedUpdate()
    {
        MousePos();
    }

    #endregion

    #region public functions

    public void SetCamera(Camera camera)
    {
        cam = camera;
    }

    public void SetActions(params UnityAction[] action)
    {
        for (int i = 0; i < action.Length; i++)
        {
            actionWhenBallReadyToMove += action[i]; 
        }
        
    }
    #endregion
    #region private fuctions

    private void MousePos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit, layer))
            {
                startPoint = hit.point; 
                //moveToTarget.SetTargetPosition(hit.point);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit, layer))
            {
                endPoint = hit.point;
                //moveToTarget.SetTargetPositionEnd(hit.point);
            }
        }

        if (startPoint != Vector3.zero && endPoint != Vector3.zero)
        {
            actionWhenBallReadyToMove?.Invoke();
            startPoint = Vector3.zero;
            endPoint = Vector3.zero;
        }
    }
    // private void OnMouseDrag()
    // {
    //     Debug.Log("start draging");
    //     Vector2 inputMousePos = Input.mousePosition;
    //     Vector3 mousePosition = new Vector3(inputMousePos.x, 0f,inputMousePos.y); //переменной записываються координаты мыши по иксу и игрику
    //     Vector3 objPosition = cam.ScreenToWorldPoint(mousePosition);
    //     objPosition.y = 480f;//переменной - объекту присваиваеться переменная с координатами мыши
    //     point.transform.position = objPosition; //и собственно объекту записываються координаты
    //     if(Input.GetMouseButtonDown(0))
    //     {
    //         moveToTarget.SetTargetPosition(
    //             new Vector3(point.transform.position.x, 0, point.transform.position.z)); //отдаём конечную точку направления в наш Move()
    //     }
    // }

    #endregion
    

}