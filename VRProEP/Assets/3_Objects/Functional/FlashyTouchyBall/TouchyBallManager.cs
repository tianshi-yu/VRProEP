﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchyBallManager : MonoBehaviour
{
    public enum TouchyBallState { Idle, Selected, Correct, Wrong }

    [Header("Colour configuration")]
    [SerializeField]
    private Color idleColour;
    [SerializeField]
    private Color selectedColour;
    [SerializeField]
    private Color correctColour;
    [SerializeField]
    private Color wrongColour;

    private TouchyBallState ballState = TouchyBallState.Idle;
    private Renderer ballRenderer;
    private bool isWaiting = false;
    private Coroutine resetCoroutine;

    public TouchyBallState BallState { get => ballState; }

    /*
    // DEBUG
    public bool select = false;
    private void Update()
    {
        if (select)
        {
            SetSelected();
            select = false;
        }
    }
    // DEBUG
    */

    private void Start()
    {
        ballRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if touched by subject
        //other.tag == "IndexFingerCollider" ||
        if ( other.tag == "MiddleFingerCollider")
        {
            switch(ballState)
            {
                case TouchyBallState.Idle:
                    ballState = TouchyBallState.Wrong;
                    ballRenderer.material.color = wrongColour;
                    break;
                case TouchyBallState.Selected:
                    ballState = TouchyBallState.Correct;
                    ballRenderer.material.color = correctColour;
                    break;
                case TouchyBallState.Correct:
                    // Do nothing
                    break;
                case TouchyBallState.Wrong:
                    // Do nothing
                    break;
            }
            //Debug.Log(ballState);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if hand is gone to return to idle.
        if ((other.tag == "GraspManager" || other.tag == "Hand") && !isWaiting)
        {
            resetCoroutine = StartCoroutine(ReturnToIdle(3.0f));
        }
    }

    /// <summary>
    /// Wait some seconds before returning to idle state.
    /// If it was selected in the middle of the wait, then just stay selected.
    /// </summary>
    /// <param name="waitSeconds">The number of seconds to wait.</param>
    /// <returns>IEnumerator used for the Coroutine.</returns>
    private IEnumerator ReturnToIdle(float waitSeconds)
    {
        isWaiting = true;
        yield return new WaitForSecondsRealtime(waitSeconds);
        ballState = TouchyBallState.Idle;
        ballRenderer.material.color = idleColour;
        isWaiting = false;
    }

    /// <summary>
    /// Set this ball as the selected one.
    /// </summary>
    public void SetSelected()
    {
        if(resetCoroutine != null)
            StopCoroutine(resetCoroutine);

        ballState = TouchyBallState.Selected;
        ballRenderer.material.color = selectedColour;
    }

    /// <summary>
    /// Resets the selection to idle.
    /// </summary>
    public void ClearSelection()
    {
        if (resetCoroutine != null)
            StopCoroutine(resetCoroutine);

        resetCoroutine = StartCoroutine(ReturnToIdle(0.1f));
    }
}
