using UnityEngine;
using StateHandler;

public class StateShootBall : State<BotController>
{
    private static StateShootBall _instance;

    Vector3 player_position;
    Vector3 ball_position;

    private StateShootBall()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static StateShootBall Instance
    {
        get
        {
            if (_instance == null)
            {
                new StateShootBall();
            }

            return _instance;
        }
    }

    public override void EnterState(BotController _owner)
    {
        player_position = _owner.player1.transform.position;
        ball_position = _owner.ball.transform.position;
    }

    public override void ExitState(BotController _owner)
    {
    }

    public override void UpdateState(BotController _owner)
    {
        player_position = _owner.player1.transform.position;
        ball_position = _owner.ball.transform.position;

        _owner.playerDistanceX = Mathf.Abs(_owner.transform.position.x - player_position.x);
        _owner.ballDistanceX = Mathf.Abs(_owner.transform.position.x - ball_position.x);

        if (_owner.player1.health > 0 && _owner.GetComponent<PlayerController>().health > 0)
        {
            if (_owner.playerDistanceX > _owner.ballDistanceX) {
                trackAndShootBall(_owner);
            }
            else {
                _owner.StateMachine.ChangeState(StateShoot.Instance);
            }
        }
        else
        {
            _owner.StateMachine.ChangeState(StatePickWeapon.Instance);
        }
    }

    private void trackAndShootBall(BotController _owner)
    {
        float ballDistanceY = Mathf.Abs(_owner.transform.position.y - ball_position.y);
        if (ballDistanceY < 0.3f)
        {
            _owner.GetComponent<PlayerController>().shootBullets(false);
        }
        else if (_owner.transform.position.y > ball_position.y)
        {
            Vector3 direction = new Vector3(0, -1, 0f).normalized;
            _owner.transform.Translate(direction * _owner.player1.speed * Time.deltaTime);

            _owner.GetComponent<PlayerController>().shootBullets(false);
        }
        else if (_owner.transform.position.y < ball_position.y)
        {
            Vector3 direction = new Vector3(0, 1, 0f).normalized;
            _owner.transform.Translate(direction * _owner.player1.speed * Time.deltaTime);

            _owner.GetComponent<PlayerController>().shootBullets(false);
        }

    }

}
