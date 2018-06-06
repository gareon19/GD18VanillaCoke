namespace StateHandler {

    public class StateMachine<BotController> {
        public State<BotController> CurrentState { get; private set; }
        public BotController Owner;

        public StateMachine(BotController _o) {
            Owner = _o;
            CurrentState = null;
        }

        public void ChangeState(State<BotController> _newState) {
            if(CurrentState != null) { 
                CurrentState.ExitState(Owner);
            }
            CurrentState = _newState;
            CurrentState.EnterState(Owner);
        }

        public void Update() {
            if (CurrentState != null) {
                CurrentState.UpdateState(Owner);
            }
        }
    }

    public abstract class State<BotController> {
        public abstract void EnterState(BotController _owner);
        public abstract void ExitState(BotController _owner);
        public abstract void UpdateState(BotController _owner);
    }
}
