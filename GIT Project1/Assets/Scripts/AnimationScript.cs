using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public static AnimationScript instance;
    public Animator fpsAnim;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void walk()
    {
        fpsAnim.SetBool("isWalk", true);
        fpsAnim.SetBool("isRun", false);
    }

    public void idle()
    {
        fpsAnim.SetBool("isWalk", false);
        fpsAnim.SetBool("isRun", false);
    }

    public void run()
    {
        fpsAnim.SetBool("isWalk", false);
        fpsAnim.SetBool("isRun", true);
    }

    public void jump()
    {
        fpsAnim.SetTrigger("Jump");
    }

    public void reload()
    {
        fpsAnim.SetBool("isRun", false);
        fpsAnim.SetTrigger("Reload");
    }
}
