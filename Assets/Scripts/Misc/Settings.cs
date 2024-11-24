using UnityEngine;

public static class Settings
{
    // Player Movement
    public const float RunningSpeed = 5.333f;
    public const float WalkingSpeed = 2.666f;

    // Input parameters
    public static readonly int InputX = Animator.StringToHash("xInput");
    public static readonly int InputY = Animator.StringToHash("yInput");

    // Movement states
    public static readonly int IsWalking = Animator.StringToHash("isWalking");
    public static readonly int IsRunning = Animator.StringToHash("isRunning");
    public static readonly int ToolEffect = Animator.StringToHash("toolEffect");

    // Tool usage states
    public static readonly DirectionHashes IsUsingTool = new DirectionHashes("isUsingTool");
    public static readonly DirectionHashes IsLiftingTool = new DirectionHashes("isLiftingTool");
    public static readonly DirectionHashes IsPicking = new DirectionHashes("isPicking");
    public static readonly DirectionHashes IsSwingingTool = new DirectionHashes("isSwingingTool");

    // Idle directions
    public static readonly DirectionHashes Idle = new DirectionHashes("idle");

    // Item Fading
    public static readonly float fadeInDuration = 0.2f;
    public static readonly float fadeOutDuration = 0.35f;
    public static readonly float fadeAlpha = 0.45f;

    // Helper class for directional hashes
    public class DirectionHashes
    {
        public readonly int Up;
        public readonly int Down;
        public readonly int Right;
        public readonly int Left;

        public DirectionHashes(string baseName)
        {
            Up = Animator.StringToHash($"{baseName}Up");
            Down = Animator.StringToHash($"{baseName}Down");
            Right = Animator.StringToHash($"{baseName}Right");
            Left = Animator.StringToHash($"{baseName}Left");
        }
    }
}
