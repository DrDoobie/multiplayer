using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerCombat : NetworkBehaviour
{
    [Header("Animation")]
    public bool isAnimated;
    public Animator animator;

    void Update()
    {
        if(isLocalPlayer)
        {
            if(isAnimated)
            {
                if(Input.GetButtonDown("Fire1"))
                {
                    animator.SetBool("isPunching", true);

                    return;
                }

                animator.SetBool("isPunching", false);
            }
        }
    }
}
