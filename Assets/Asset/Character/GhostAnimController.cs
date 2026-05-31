using UnityEngine;

public class GhostAnimController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        SetVisible(false);
    }

    public void SetVisible(bool visible)
    {
        gameObject.SetActive(visible);
    }

    public void PlayOpening()
    {
        SetVisible(true);
        animator.SetTrigger("TriggerOpening");
        PlayOpeningVFX(); // เรียก VFX
    }

    private void PlayOpeningVFX()
    {
        // TODO: เปิด particle วงล้อเวท
        // TODO: FloatUp layer จะทำงานอัตโนมัติอยู่แล้ว
    }

    public void PlayRandomDance()
    {
        int index = Random.Range(0, 5);
        animator.SetInteger("DanceIndex", index);
    }

    public void PlayRandomAttack()
    {
        int index = Random.Range(0,2);
        animator.SetInteger("AttackIndex", index);
    }

    public void PlayHurt_01() => animator.SetTrigger("TriggerHurt_01");
    public void PlayHurt_02() => animator.SetTrigger("TriggerHurt_02");

    public void PlayEnding(bool playerWin)
    {
        if (playerWin)
            animator.SetTrigger("TriggerEndWin");
        else
            animator.SetTrigger("TriggerEndLose");
    }
}
