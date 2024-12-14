using UnityEngine;

public class StateMachine
{
    private State currentState;

    public State CurrentState => currentState; // Propiedad pública para acceder al estado actual

    public void SetState(State newState)
    {
        currentState?.Exit();   // Salir del estado actual (si existe)
        currentState = newState; // Cambiar al nuevo estado
        Debug.Log($"Estado cambiado a: {currentState.GetType().Name}"); // Anunciar el cambio de estado
        currentState.Enter();   // Entrar al nuevo estado
    }

    public void Update()
    {
        currentState?.Update(); // Actualizar el estado actual
    }
}
