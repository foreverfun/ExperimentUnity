using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCoroutineAsyncAwaitTrainingManager : MonoBehaviour
{
    private bool updateLevelFlag;
    private System.DateTime startTimeUpdate;
    private System.TimeSpan differenceTimeUpdate;

    private bool coroutineLevelFlag;
    private System.DateTime startTimeCoroutine;
    private System.TimeSpan differenceTimeCoroutine;

    void Start()
    {
        updateLevelFlag = false;
        coroutineLevelFlag = false;
        StartCoroutine(TestCoroutine());
    }

    void Update()
    {
        if (updateLevelFlag)
        {
            differenceTimeUpdate = System.DateTime.Now - startTimeUpdate;
            Debug.Log("Update - Milliseconds: " + differenceTimeUpdate.TotalMilliseconds);
            updateLevelFlag = false;
        }
    }

    public void PressUpdateFlagButton()
    {
        startTimeUpdate = System.DateTime.Now;
        Debug.Log("Update Flag pressed: " + startTimeUpdate);
        for (int i = 0; i < 1000000; i++)
        {

        }
        updateLevelFlag = true;
    }

    public void PressCoroutineFlagButton()
    {
        startTimeCoroutine = System.DateTime.Now;
        Debug.Log("Coroutine Flag pressed: " + startTimeCoroutine);
        for (int i = 0; i < 1000000; i++)
        {

        }
        coroutineLevelFlag = true;
    }

    IEnumerator TestCoroutine()
    {
        yield return new WaitUntil(() => coroutineLevelFlag == true );
        differenceTimeCoroutine = System.DateTime.Now - startTimeCoroutine;
        Debug.Log("Coroutine - Milliseconds: " + differenceTimeCoroutine.TotalMilliseconds);
    }

}
