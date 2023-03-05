using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleAnimationDone : MonoBehaviour
{
    public Animator animator;
    public Slider speedSlider;

    private void Update()
    {
        if(animator != null)
        {
            animator.SetFloat("speed", speedSlider.value);
        }
    }

    public void OnFireButtonClicked()
    {
        if (animator != null)
        {
            speedSlider.value = 0f;
            animator.SetFloat("speed", 0f);
            animator.SetTrigger("fire");
        }
    }

    public void OnIsGroundedToggleChange(Toggle toggle)
    {
        if (animator != null)
        {
            animator.SetBool("isGrounded", toggle.isOn);
        }
    }


}
