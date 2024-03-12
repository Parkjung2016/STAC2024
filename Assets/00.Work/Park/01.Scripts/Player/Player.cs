using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : Entity
{
    [Header("Setting values")] public float moveSpeed = 12f;
    public float jumpForce = 12f;
    public float dashDuration = 0.4f;
    public float dashSpeed = 20f;

    private float _defaultMoveSpeed;
    private float _defaultJumpForce;
    private float _defaultDashSpeed;

    [Header("Attack Settings")] public Vector2[] attackMovement; //앞으로 전진하는 정도.
    public float attackSpeed = 1f;

    public bool IsBusy { get; private set; } = false;

    [HideInInspector] public SkillManager skill;

    public PlayerStateMachine StateMachine { get; private set; }
    [SerializeField] private InputReader _inputReader;
    public InputReader PlayerInput => _inputReader;

    public int currentComboCounter { get; set; }
    public bool canStateChangeable = true;
    protected bool _isDead = false;

    protected override void Awake()
    {
        base.Awake();
        StateMachine = new PlayerStateMachine();

        foreach (StateEnum state in Enum.GetValues(typeof(StateEnum)))
        {
            string typeName = state.ToString();
            try
            {
                Type t = Type.GetType($"Player{typeName}State");
                var playerState = Activator.CreateInstance(t, this, StateMachine, typeName) as PlayerState;

                StateMachine.AddState(state, playerState);
            }
            catch (Exception ex)
            {
                Debug.LogError($"{typeName} is loading error, Message : {ex.Message}");
            }
        }
    }

    protected override void Start()
    {
        base.Start();
        skill = SkillManager.Instance; //스킬매니저 캐싱
        StateMachine.Initialize(StateEnum.Idle, this);

        //기본 값 셋팅
        _defaultMoveSpeed = moveSpeed;
        _defaultJumpForce = jumpForce;
        _defaultDashSpeed = dashSpeed;
    }

    private void OnEnable()
    {
        PlayerInput.DashEvent += HandleDashInput;
    }

    private void OnDisable()
    {
        PlayerInput.DashEvent -= HandleDashInput;
    }

    protected override void HandleDie(Vector2 direction)
    {
        //사망처리
        HandleHit(); //체력바 초기화시켜주고
        _isDead = true;
        StateMachine.ChangeState(StateEnum.Dead);
        base.HandleKnockback(direction);
    }

    protected override void HandleKnockback(Vector2 direction)
    {
        if (!_isDead)
            base.HandleKnockback(direction); //베이스 넉백은 실행할지 말지 사망에 따라 결정.
    }

    private void HandleDashInput()
    {
        //벽에 붙어있는 동안은 대시가 안되도록
        if (IsWallDetected())
            return;

        //대시 스킬 사용 성공시.
        if (skill.GetSkill<DashSkill>().AttemptUseSkill())
        {
            StateMachine.ChangeState(StateEnum.Dash);
        }
    }


    public override void Attack()
    {
        AudioManager.Instance.PlaySFX(2, sourceTrm: null, withRandomPitch: true);

        bool hitAttack = DamageCasterCompo.CastDamage(); //공격에 적이 맞았는가?
    }

    protected override void Update()
    {
        base.Update();
        StateMachine.CurrentState.UpdateState();
    }

    public override void SlowEntityBy(float percent)
    {
        if (moveSpeed < _defaultMoveSpeed) return;
        moveSpeed *= 1 - percent;
        jumpForce *= 1 - percent;
        dashSpeed *= 1 - percent;
        AnimatorCompo.speed *= 1 - percent;
    }

    protected override void ReturnDefaultSpeed()
    {
        base.ReturnDefaultSpeed();
        moveSpeed = _defaultMoveSpeed;
        jumpForce = _defaultJumpForce;
        dashSpeed = _defaultDashSpeed;
    }

    public void AnimationTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();


    public async void SetIsBusyWhenDelayTime(int delayTimeMS)
    {
        IsBusy = true;
        await Task.Delay(delayTimeMS);
        IsBusy = false;
    }


    public void FadePlayer(bool fadeOut, float sec)
    {
        float endValue = fadeOut ? 0 : 1f;
        SpriteRendererCompo.DOFade(endValue, sec);
    }

    #region Check Collision

    public IInteract IsInteractObjectDetected()
    {
        RaycastHit2D hit = Physics2D.Raycast(_wallCheck.position, Vector2.right * FacingDirection,
            _interactCheckDistance, _whatIsInteract);
        return hit.transform == null ? null : hit.transform.GetComponent<IInteract>();
    }

    #endregion


    #region Debugging

#if UNITY_EDITOR
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        if (_wallCheck != null)
            Gizmos.DrawLine(_wallCheck.position,
                _wallCheck.position + new Vector3(_interactCheckDistance, 0, 0));
    }
#endif

    #endregion
}