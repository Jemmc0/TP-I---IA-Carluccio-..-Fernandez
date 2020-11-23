using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState<T> : State<T> //Si no se ele agrega el valor generico T en la clase, al colocar la herencia va a tirar error
{
    PlayerModel _model;

    public IdleState(PlayerModel model)
    {
        _model = model;
    }
    public override void Awake()
    {
        _model.Idle();
    }
}
