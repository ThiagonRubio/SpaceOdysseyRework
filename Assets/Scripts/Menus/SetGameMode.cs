using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameMode : MonoBehaviour
{
    public void SetGameModeAsStageMode()
    {
        GameManager.Instance.GamemodeIsStageMode = true;
    }

    public void SetGameModeAsEndlessMode()
    {
        GameManager.Instance.GamemodeIsStageMode = false;
    }
}
