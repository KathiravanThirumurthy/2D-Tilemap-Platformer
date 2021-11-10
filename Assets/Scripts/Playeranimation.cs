using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playeranimation : MonoBehaviour
{
    private Animator anim;
    //spriteRender for flip
   // private SpriteRenderer _playerSprite;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
      //  _playerSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void runPlayer(float move)
    {
        // anim setfloat to run 
        anim.SetFloat("run", Mathf.Abs(move));
    }
    /*public void flipPlayer(float horizontal)
    {
        if (horizontal > 0)
        {

            _playerSprite.flipX = false;
        }
        else if (horizontal < 0)
        {

            _playerSprite.flipX = true;
        }
    }*/
}
