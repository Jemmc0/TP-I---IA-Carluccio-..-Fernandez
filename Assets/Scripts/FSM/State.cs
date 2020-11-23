using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State<T> : IState<T>
{
    Dictionary<T, IState<T>> _dicStates; //En este diccionario se guardaran los estados
    public void AddTransition(T input, IState<T> state) //Al llamar esta funcion y pasarle los parametros(nobre del estado, funcion que contiene el estado) esta la agregara al diccionario
    {
        if (!_dicStates.ContainsKey(input)) //si no esta en diccionario...
        {
            _dicStates.Add(input, state); //Se agrega
        }
    }
    //Sin el virtual, todo aque que herdede esta clase, no podra acceder a sus funciones.
    public virtual void Awake() //No se usa en esta clase, es el lo primero que se ejecuta en casa estado
    { }

    public virtual void Execute() //No se usa en esta clase, esto es lo que se ejecuta frame a frame
    { }
    public virtual void Sleep()//No se usa en esta clase, esto es lo ultimo que se ejecuta en el estado
    { }

    public IState<T> GetState(T input) //Devuelve el estado que se asigno en el Starte del Controller, sino se asigno o se removio, no hara nada
    {
        if (_dicStates.ContainsKey(input))
        {
            return _dicStates[input];
        }
        return null;
    }

    public void RemoveTransition(T input) //Se encarga de sacar estados que ya no usemos, con solo el input bastara
    {
        if (_dicStates.ContainsKey(input)) //Cheoqueo si esta....
        {
            _dicStates.Remove(input); //y lo saco
        }
    }

    
}
