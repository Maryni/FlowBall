using UnityEngine;
using UnityEngine.Events;

public class TakeMousePosition : MonoBehaviour
{
    #region Inspector variables

    [SerializeField] private LayerMask layer;

    #endregion

    #region private variables

    private Camera cam;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private GameObject point;
    private UnityAction actionWhenPlayerMoveBlueBox;
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

    public void SetBlueBox(GameObject gameObject)
    {
        point = gameObject;
    }

    public void SetActionsOnBallReadyToMove(params UnityAction[] actions)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actionWhenBallReadyToMove += actions[i]; 
        }
        
    }
    public void SetActionsOnMovingBlueBox(params UnityAction[] actions)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actionWhenPlayerMoveBlueBox += actions[i]; 
        }
        
    }
    #endregion
    #region private fuctions

    private void MousePos()
    {
        Vector3 mousePos = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            
            var ray = cam.ScreenPointToRay(mousePos);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit, layer))
            {
                hit.point = new Vector3(hit.point.x,0f,hit.point.z);
                point.transform.position = hit.point;
                actionWhenPlayerMoveBlueBox?.Invoke();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            var ray = cam.ScreenPointToRay(mousePos);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit, layer))
            {
                endPoint = hit.point;
            }
        }
        
        if (endPoint != Vector3.zero)
        {
            actionWhenBallReadyToMove?.Invoke();
            endPoint = Vector3.zero;
        }
    }

    #endregion

}