using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimationParameterController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        EventHandler.movementEvent += SetAnimationParameters;
    }

    private void OnDisable()
    {
        EventHandler.movementEvent -= SetAnimationParameters;
    }

    private void SetAnimationParameters(
        float inputX,
        float inputY,
        MovementState movementState,
        ToolEffect toolEffect,
        ToolAction toolAction,
        Direction toolDirection,
        Direction idleDirection)
    {
        animator.SetFloat(Settings.InputX, inputX);
        animator.SetFloat(Settings.InputY, inputY);

        // Movement state
        animator.SetBool(Settings.IsWalking, movementState == MovementState.Walking);
        animator.SetBool(Settings.IsRunning, movementState == MovementState.Running);
        animator.SetInteger(Settings.ToolEffect, (int)toolEffect);

        // Tool action
        if (movementState == MovementState.UsingTool)
        {
            SetToolAnimation(Settings.IsUsingTool, toolAction == ToolAction.Using ? toolDirection : Direction.None);
            SetToolAnimation(Settings.IsLiftingTool, toolAction == ToolAction.Lifting ? toolDirection : Direction.None);
            SetToolAnimation(Settings.IsPicking, toolAction == ToolAction.Picking ? toolDirection : Direction.None);
            SetToolAnimation(Settings.IsSwingingTool, toolAction == ToolAction.Swinging ? toolDirection : Direction.None);
        }
        else
        {
            SetToolAnimation(Settings.IsUsingTool, Direction.None);
            SetToolAnimation(Settings.IsLiftingTool, Direction.None);
            SetToolAnimation(Settings.IsPicking, Direction.None);
            SetToolAnimation(Settings.IsSwingingTool, Direction.None);
        }

        // Idle direction
        SetIdleAnimation(movementState == MovementState.Idle ? idleDirection : Direction.None);
    }

    private void SetToolAnimation(Settings.DirectionHashes toolHashes, Direction direction)
    {
        animator.SetBool(toolHashes.Right, direction == Direction.Right);
        animator.SetBool(toolHashes.Left, direction == Direction.Left);
        animator.SetBool(toolHashes.Up, direction == Direction.Up);
        animator.SetBool(toolHashes.Down, direction == Direction.Down);
    }

    private void SetIdleAnimation(Direction direction)
    {
        animator.SetBool(Settings.Idle.Up, direction == Direction.Up);
        animator.SetBool(Settings.Idle.Down, direction == Direction.Down);
        animator.SetBool(Settings.Idle.Right, direction == Direction.Right);
        animator.SetBool(Settings.Idle.Left, direction == Direction.Left);
    }


    private void AnimationEventPlayFootstepSound() { }
}
