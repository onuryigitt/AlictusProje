using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAnimation : MonoBehaviour
{
    [SerializeField] private Animator PlayerAC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frameX
    void Update()
    {
        
    }
    public void ManageAnimations(Vector3 move)  //karakter animasyon hareket
    {
        if (move.magnitude > 0)
        {
            PlayRunAnimation();

            PlayerAC.transform.forward = move.normalized;

        }
        else 
        {
            PlayIdleAnimation();
        }

    }

    private void PlayRunAnimation()
    {
        PlayerAC.Play("RUN");
    }

    private void PlayIdleAnimation()
    {
        PlayerAC.Play("IDLE");
    }
}
