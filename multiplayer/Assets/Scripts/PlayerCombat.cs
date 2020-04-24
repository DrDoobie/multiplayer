using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerCombat : NetworkBehaviour
{
    [Header("Animation")]
    public bool isAnimated;
    public Animator animator;
    public NetworkAnimator networkAnimator;

    void Update()
    {
        if(isLocalPlayer)
        {
            if(isAnimated)
            {
                if(Input.GetButtonDown("Fire1"))
                {
                    //animator.SetTrigger("Punch");
                    networkAnimator.SetTrigger("Punch");
                }
            }
        }
    }
}
