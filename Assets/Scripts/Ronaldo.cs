using UnityEngine;

public class Ronaldo : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool canMove;
    private Vector3 targePosition;
    private string lastAnimationTrigger;

    private AudioSource audioSource;
    private Animator animator;

    public const string IDLE_UP = "pIdleUp";
    public const string IDLE_DOWN = "pIdleDown";
    public const string IDLE_RIGHT = "pIdleRight";
    public const string IDLE_LEFT = "pIdleLeft";
    public const string WALK_UP = "pWalkUp";
    public const string WALK_DOWN = "pWalkDown";
    public const string WALK_RIGHT = "pWalkRight";
    public const string WALK_LEFT = "pWalkLeft";

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        SetTarget(new Vector3(-0.35f, transform.position.y, 0), WALK_LEFT);
    }

    private void Update()
    {
        audioSource.volume = GameManager.sfxVolume;

        if (canMove)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            transform.position = Vector3.MoveTowards(transform.position, targePosition, speed * Time.deltaTime);

            if (transform.position == targePosition)
            {
                canMove = false;
                audioSource.Stop();

                switch (lastAnimationTrigger)
                {
                    case WALK_UP:
                        animator.SetTrigger(IDLE_UP);
                        lastAnimationTrigger = IDLE_UP;
                        break;

                    case WALK_DOWN:
                        animator.SetTrigger(IDLE_DOWN);
                        lastAnimationTrigger = IDLE_DOWN;
                        break;

                    case WALK_RIGHT:
                        animator.SetTrigger(IDLE_RIGHT);
                        lastAnimationTrigger = IDLE_RIGHT;
                        break;

                    case WALK_LEFT:
                        animator.SetTrigger(IDLE_LEFT);
                        lastAnimationTrigger = IDLE_LEFT;
                        break;

                    default:
                        animator.SetTrigger(IDLE_DOWN);
                        lastAnimationTrigger = IDLE_DOWN;
                        break;
                }
            }
        }
    }

    public void SetTarget(Vector3 target, string animationTrigger)
    {
        animator.SetTrigger(animationTrigger);
        lastAnimationTrigger = animationTrigger;

        targePosition = target;
        canMove = true;
    }
}
