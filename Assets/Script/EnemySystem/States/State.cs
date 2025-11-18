public abstract class State
{
    //Instance of enemy
    //Instance of StateMachine
    public StateMachine stateMachine;
    public Enemy enemy;

    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();

}