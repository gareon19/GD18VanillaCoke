using UnityEngine;
using StateHandler;

public class StateIdle : State<BotController>
{
    private static StateIdle _instance;

    private StateIdle() {
        if (_instance != null) {
            return;
        }

        _instance = this;
    }

    public static StateIdle Instance {
        get {
            if (_instance == null) {
                new StateIdle();
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
        if (_owner.startTutorial)
        {
            _owner.StateMachine.ChangeState(StateTutorial.Instance);
        }
        else if (_owner.startBot) {
            _owner.StateMachine.ChangeState(StatePickWeapon.Instance);
        }
    }
}
