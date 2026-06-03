using System.Collections;
using UnityEngine;

public class GhostAnimationController : MonoBehaviour
{
    private Animator animator;

    [Header("Timing (วิ)")]
    public float idlePoseTime = 0.17f;
    public float danceTime = 9.00f;
    public float actionTime = 2.25f; 

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(GhostRoutine());
    }

    private IEnumerator GhostRoutine()
    {
        while (true)
        {
            // 1. สุ่ม Dance
            int danceIdx = Random.Range(1, 5); // 0-4
            animator.SetInteger("DanceIndex", danceIdx);
            animator.SetTrigger("TriggerDance"); // <-- ต้องมีตัวนี้
            yield return new WaitForSeconds(danceTime);

            // 2. Idle
            yield return new WaitForSeconds(idlePoseTime);

            // 3. สุ่ม Action
            int action = Random.Range(1, 4);
            switch (action)
            {
                case 0:
                    animator.SetInteger("AttackIndex", 0);
                    animator.SetTrigger("TriggerAction");
                    break;
                case 1:
                    animator.SetInteger("AttackIndex", 1);
                    animator.SetTrigger("TriggerAction");
                    break;
                case 2:
                    animator.SetTrigger("TriggerHurt_01");
                    break;
                case 3:
                    animator.SetTrigger("TriggerHurt_02");
                    break;
            }
            yield return new WaitForSeconds(actionTime);

            // 4. Idle ก่อนรอบถัดไป
            yield return new WaitForSeconds(idlePoseTime);
        }
    }

    public void PlayEndWin() => animator.SetTrigger("TriggerEndWin");
    public void PlayEndLose() => animator.SetTrigger("TriggerEndLose");
}