﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCanvasManager : MonoBehaviour
{
    public enum State { Default, Controls, Animation, Crafting, Reading, Playing };
    public State currentState;
    public GameObject panelControls;
    public GameObject panelAnimation;
    public GameObject panelHUD;
    public GameObject panelLab;
    public GameObject panelNotebook;

    private CameraController cameraController;

    // Use this for initialization
    void Start ()
    {
        cameraController = FindObjectOfType<CameraController>();
        currentState = State.Default;
        ToNextState();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyUp(KeyCode.Return))
        {
            ToNextState();
        }
        if(Input.GetKeyUp(KeyCode.Backspace))
        {
            ToPreviousState();
        }
    }

    public void ToNextState()
    {
        switch (currentState)
        {
            case State.Default:
                panelControls.SetActive(true);
                panelAnimation.SetActive(false);
                panelHUD.SetActive(false);
                panelLab.SetActive(false);
                panelNotebook.SetActive(false);
                cameraController.isZooming = false;
                currentState = State.Controls;
                break;
            case State.Controls:
                panelControls.SetActive(false);
                panelHUD.SetActive(false);
                panelAnimation.SetActive(true);
                panelLab.SetActive(false);
                panelNotebook.SetActive(false);
                cameraController.isZooming = false;
                currentState = State.Animation;
                break;
            case State.Animation:
                panelControls.SetActive(false);
                panelAnimation.SetActive(false);
                panelHUD.SetActive(false);
                panelLab.SetActive(true);
                panelNotebook.SetActive(false);
                cameraController.isZooming = false;
                currentState = State.Crafting;
                break;
            case State.Crafting:
                panelControls.SetActive(false);
                panelAnimation.SetActive(false);
                panelHUD.SetActive(false);
                panelLab.SetActive(false);
                panelNotebook.SetActive(true);
                cameraController.isZooming = false;
                currentState = State.Reading;
                break;
            case State.Reading:
                panelControls.SetActive(false);
                panelAnimation.SetActive(false);
                panelHUD.SetActive(true);
                panelLab.SetActive(false);
                panelNotebook.SetActive(false);
                cameraController.isZooming = true;
                currentState = State.Playing;
                break;
            default:
                panelControls.SetActive(false);
                panelAnimation.SetActive(false);
                panelHUD.SetActive(true);
                panelLab.SetActive(false);
                cameraController.isZooming = true;
                currentState = State.Playing;
                break;
        }
    }

    public void ToPreviousState()
    {
        switch(currentState)
        {
            case State.Animation:
                panelControls.SetActive(true);
                panelAnimation.SetActive(false);
                panelHUD.SetActive(false);
                panelLab.SetActive(false);
                cameraController.isZooming = false;
                currentState = State.Controls;
                break;
            case State.Crafting:
                panelControls.SetActive(false);
                panelAnimation.SetActive(true);
                panelHUD.SetActive(false);
                panelLab.SetActive(false);
                cameraController.isZooming = false;
                currentState = State.Animation;
                break;
        }
    }
}
