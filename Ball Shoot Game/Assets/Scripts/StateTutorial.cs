using UnityEngine;
using StateHandler;

public class StateTutorial : State<BotController>
{
    private static StateTutorial _instance;
    bool tutorialShot = false;
    bool enemySighted = false;

    private StateTutorial()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static StateTutorial Instance
    {
        get
        {
            if (_instance == null)
            {
                new StateTutorial();
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
        if (!_owner.startTutorial)
        {
            _owner.StateMachine.ChangeState(StateIdle.Instance);
        }
        else if (!_owner.gotWeapon)
        {
            pickWeapon(_owner);
        }
        else if (!enemySighted) {
            walkToEnemy(_owner);
        }
        else if (!tutorialShot) {
            warningShot(_owner);
            _owner.startTutorial = false;
        }
    }

    private void pickWeapon(BotController _owner)
    {
        Vector3 direction = new Vector3(-1, 0, 0f).normalized;
        _owner.transform.Translate(direction * _owner.player1.speed * Time.deltaTime);
    }

    private void warningShot(BotController _owner)
    {
        _owner.GetComponent<PlayerController>().shootBullets(false);
        tutorialShot = true;
    }

    private void walkToEnemy(BotController _owner) {
        Vector3 player_position = _owner.player1.transform.position;

        float distance = Mathf.Abs(_owner.transform.position.y - player_position.y);
        if (distance < 0.3f)
        {
            enemySighted = true;
        }
        else if (_owner.transform.position.y > player_position.y)
        {
            Vector3 direction = new Vector3(0, -1, 0f).normalized;
            _owner.transform.Translate(direction * _owner.player1.speed * Time.deltaTime);
        }
        else if (_owner.transform.position.y < player_position.y) {
            Vector3 direction = new Vector3(0, 1, 0f).normalized;
            _owner.transform.Translate(direction * _owner.player1.speed * Time.deltaTime);
        }
    }
}
