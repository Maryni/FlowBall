using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{
    #region Inspector variables

    [SerializeField] private Text textField;

    #endregion

    #region private variables

    private UnityAction action;

    #endregion
    
    #region public functions

    public void SetActions(params UnityAction[] actions)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            action+= actions[i]; 
        }
        
    }
    
    /// <summary>
    /// Когда кол-во DestroyCount от ящиков = 3, лвл ++, и заново
    /// </summary>
    public void ChangeLevel()
    {
        int a = int.Parse(textField.text); 
        a++;
        textField.text = a.ToString();
        action?.Invoke();
    }

    #endregion

}
