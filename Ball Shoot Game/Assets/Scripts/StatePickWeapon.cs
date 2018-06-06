using UnityEngine;
using StateHandler;

public class StatePickWeapon : State<BotController>
{
    private static StatePickWeapon _instance;
    bool tutorialShot = false;

    private StatePickWeapon()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static StatePickWeapon Instance
    {
        get
        {
            if (_instance == null)
            {
                new StatePickWeapon();
            }

            return _instance;
        }
    }

    public override void EnterState(BotController _owner)
    {
    }

    public override void ExitState(BotController _owner)
    {
    }

    public override void UpdateState(BotController _owner)
    {
        // switch state logic
        if (!_owner.gotWeapon)
        {
            pickWeapon(_owner);
        }
        else
        {
            _owner.StateMachine.ChangeState(StateShootBall.Instance);
        }
    }

    private void pickWeapon(BotController _owner)
    {
        Vector3 direction = new Vector3(-1, 0, 0f).normalized;
        _owner.transform.Translate(direction * 5 * Time.deltaTime);
    }
}
