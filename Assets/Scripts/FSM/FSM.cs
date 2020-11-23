using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM<T>
{
    IState<T> _currentState; //aqui se guarda el estado actual

    public FSM(IState<T> init) //con este constructor seteo el estado inicial
    {
        SetInit(init); //llamo a la funcion pasando como parametro el inicial
    }
    public void SetInit(IState<T> initState) 
    {
        _currentState = initState;
        _currentState.Awake(); //al setear el inicial llamamos a su Awake
    }

    public void OnUpdate()
    {
        _currentState.Execute(); //lo ejecutamos frame a frame
    }

    public void Transition(T input) //hacemos la transicion de estados, le pasamos como parametro la key del estado
    {
        IState<T> newState = _currentState.GetState(input); //la guardamos
        if (newState == null) return; //preguntamos si es null, y si no no retornamos nada
        _currentState.Sleep(); //si hay algo, finiquitamos al estado saliente
        _currentState = newState; //seteamos al nuevo estado
        _currentState.Awake(); //despertamos al nuevo estado  
    }
}
