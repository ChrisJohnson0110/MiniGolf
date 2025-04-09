using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingController : MonoBehaviour
{
    public Rigidbody golfBall;
    public float swingForce = 10f;
    public SwingAligner aligner;
    public SwingPowerController powerController;
    public ClubAnimator clubAnimator;
    public float swingDelay = 0.5f;

    private bool canSwing = true;

    void Update()
    {
        // Only allow swing if ball is basically stopped and not in free cam mode
        if (Input.GetKeyDown(KeyCode.Space) && canSwing && !IsBallMoving() && !CameraController.IsInFreeCam)
        {
            canSwing = false;
            clubAnimator.PlaySwing();
            StartCoroutine(SwingAfterDelay());
            // Optional: wait until ball stops, then reset
            StartCoroutine(WaitForBallToStop());
        }


    }

    bool IsBallMoving()
    {
        return golfBall.velocity.magnitude > 0.05f;
    }

    IEnumerator SwingAfterDelay()
    {
        yield return new WaitForSeconds(swingDelay);

        clubAnimator.HideClub();

        Vector3 direction = aligner.GetShotDirection();
        direction.y = 0; // Flatten Y to prevent ball from popping up
        direction.Normalize();
        float power = powerController.CurrentPower;
        golfBall.AddForce(direction * power , ForceMode.Impulse);
    }

    IEnumerator WaitForBallToStop()
    {
        yield return new WaitUntil(() => golfBall.velocity.magnitude < 0.05f);

        // Reset club position
        clubAnimator.ResetClubPosition();

        clubAnimator.ShowClub();
        canSwing = true;
    }
}