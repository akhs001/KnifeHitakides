using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public interface IObserver { }
    public struct Obs<T>
    {
        public string eventName;
        Action<T> action;
        public IObserver i_obs;

        public void Execute(T val)
        {
            action.Invoke(val);
        }

        public Obs(IObserver o, string name, Action<T> a)
        {
            i_obs = o;
            eventName = name;
            action = a;
        }
    }

    public struct Obs
    {
        public string eventName;
        Action action;
        public IObserver i_obs;

        public void Execute()
        {
            action.Invoke();
        }

        public Obs(IObserver o, string name, Action a)
        {
            i_obs = o;
            eventName = name;
            action = a;
        }
    }
public class EventManager<T> : Singleton<EventManager<T>>
{

        public static List<Obs<T>> observers = new List<Obs<T>>();

        public static void TriggerEvent(string e, T val)
        {
            foreach (Obs<T> obs in observers)
            {
                if (obs.eventName == e)
                    obs.Execute(val);
            }
        }
        public static void StartListening(IObserver o, string eventName, Action<T> action)
        {
            observers.Add(new Obs<T>(o, eventName, action));
        }
        public static void StopListening(IObserver o, string eventName, Action action)
        {
            observers.RemoveAll(i => i.i_obs == o && i.eventName == eventName);
        }
    }

    public  class EventManager : Singleton<EventManager>
    {

        public static List<Obs> observers = new List<Obs>();

        public static void TriggerEvent(string e)
        {
            foreach (Obs obs in observers)
            {
                if (obs.eventName == e)
                    obs.Execute();
            }
        }
        public static void StartListening(IObserver o, string eventName, Action action)
        {
            observers.Add(new Obs(o, eventName, action));
        }
        public static void StopListening(IObserver o, string eventName, Action action)
        {
            observers.RemoveAll(i => i.i_obs == o);
        }
    }

