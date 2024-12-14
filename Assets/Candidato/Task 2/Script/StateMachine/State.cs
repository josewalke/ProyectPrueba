public abstract class State
{
    public abstract void Enter();  // Llamado al entrar en el estado
    public abstract void Update(); // Llamado cada frame
    public abstract void Exit();   // Llamado al salir del estado
}
