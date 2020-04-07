﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] private Text textComponent;

    [SerializeField] private State startingState;

    private State state;
    // Start is called before the first frame update
    void Start()
    {
        state = startingState;
        UpdateStoryText();
    }

    // Update is called once per frame
    void Update()
    {
        if (!string.IsNullOrEmpty(Input.inputString)) {
            ManageState();
        }
    }

    private void ManageState() {
        var nextStates = state.GetNextStates();
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            state = nextStates[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            state = nextStates[1];
        }
        UpdateStoryText();
        
        //Future Enhancement for choosing 1 to N states
        /*int NumericValue = -1;
        int.TryParse(Input.inputString, out NumericValue);
        if (NumericValue >= 1 && NumericValue < nextStates.Length + 1)
        {
            state = nextStates[NumericValue - 1];
            UpdateStoryText();
        }*/
    }

    private void UpdateStoryText()
    {
        textComponent.text = state.GetStateStory();
    }
}
