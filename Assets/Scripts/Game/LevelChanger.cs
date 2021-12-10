using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{
    #region Inspector variables

    [SerializeField] Text textField;
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] BoxDestroyer boxDestroyer;
    [SerializeField] ProtectorAgent protectorAgent;

    #endregion

    #region private variables

    private UnityAction action;

    #endregion
    #region public functions

    public void SetAction(UnityAction unityAction)
    {
        action+= unityAction;
    }
    /// <summary>
    /// Когда кол-во DestroyCount от ящиков = 3, лвл ++, и заново
    /// </summary>
    public void ChangeLevel()
    {
        int a = int.Parse(textField.text); 
        a++;
        textField.text = a.ToString();
        for(int i =0; i<3;i++)
        {
            boxDestroyer.boxes[i].SetActive(true);
        }
        action?.Invoke();
        navMeshAgent.speed += 0.5f;
        
    }

    #endregion

    
}
