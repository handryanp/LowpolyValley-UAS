using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetIsWalking(bool isWalking)
    {
        animator.SetBool("isWalking", isWalking);
    }

    public void SetIsRunning(bool isRunning)
    {
        animator.SetBool("isRunning", isRunning);
    }

    // Tambahkan metode lain sesuai kebutuhan untuk mengontrol animasi lainnya.
}
