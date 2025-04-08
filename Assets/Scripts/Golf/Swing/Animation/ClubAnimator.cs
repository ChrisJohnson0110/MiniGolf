using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubAnimator : MonoBehaviour
{
    public Transform clubTransform;
    public Transform ballTransform;
    public SwingAligner aligner;
    public float clubOffset = -0.5f;
    public Animator animator;

    private bool isVisible = true;

    void Update()
    {
        if (!isVisible) return;

        AlignClubWithShot();
    }

    void AlignClubWithShot()
    {
        Vector3 position = ballTransform.position + aligner.GetShotDirection() * clubOffset;
        clubTransform.position = position;
        clubTransform.rotation = Quaternion.LookRotation(aligner.GetShotDirection());
    }

    public void HideClub()
    {
        isVisible = false;
        clubTransform.gameObject.SetActive(false);
    }

    public void ShowClub()
    {
        isVisible = true;
        clubTransform.gameObject.SetActive(true);
    }

    public void PlaySwing()
    {
        animator.SetTrigger("Swing");
    }

    public void ResetClubPosition()
    {
        AlignClubWithShot(); // reuse existing positioning logic
    }
}