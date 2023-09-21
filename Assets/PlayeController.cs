using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class PlayeController : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset idele;
    public string currentState;
    public void SetAnimation(AnimationReferenceAsset animation, bool loop, float timescale)
    {
        skeletonAnimation.state.SetAnimation(0,animation,loop).TimeScale = timescale;
    }
    public void SetCharacter(string state)
    {
        if (state.Equals("idle"))
        {
            SetAnimation(idele, true, 1f);
        }
    }
    void Start()
    {
        currentState = "idle";
        SetCharacter(currentState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
