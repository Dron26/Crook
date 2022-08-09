using UnityEngine;

public class HashAnimationNames : MonoBehaviour
{
    public int WalkHash = Animator.StringToHash("isWalk");
    public int RunHash = Animator.StringToHash("isRun");
    public int CloseHash = Animator.StringToHash("Close");
    public int OpenInHash = Animator.StringToHash("IsOpenIn");
    public int OpenOutHash = Animator.StringToHash("IsOpenOut");
}
