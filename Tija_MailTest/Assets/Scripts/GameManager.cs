using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CustomInputField inputField = default;
    
    private bool hasStarted = false;

    private void Update()
    {
        if (hasStarted)
            return;
        //if (Input.GetKeyDown(KeyCode.Space))
        
            hasStarted = true;
            inputField.AddWord(WordDatabase.GetRandomWord());
            inputField.Activate();
            inputField.OnCompletion += HandleWordDone;
        
    }
    private void HandleWordDone()
    {
        Debug.Log("word done !");
        inputField.AddWord(WordDatabase.GetRandomWord());
    }

    private void OnDisable()
    {
        inputField.OnCompletion -= HandleWordDone;
    }
}
