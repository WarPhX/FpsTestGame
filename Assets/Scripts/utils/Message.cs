using UnityEngine;
using System.Collections;
using System;
//using SimpleJson; we don't need this


public class Message
{
    //! definitely implement this, or else. Also, make sure it's defined as the first thing in your new class as the Server Message deserializer depends on this crap
    virtual public string Type { get { throw new Exception("This must be implemented in everything that inherits from Message. ( at the top of the new class ) "); } }

    //! used internally by servermanager Serialized as last value, in practice
    public string token;

    //! your local token is received in the AuthorizedMsg sent by the lobby server. It uniquely identifies a user
    //! all messages have a token that uniquely identify a user
    public void SetToken(string t) { token = t; }

    //! this will be called on derived classes. Order of serialization is top (class instance actual type ) to bottom ( base )
 //   virtual public string Serialize() { return SimpleJson.SimpleJson.SerializeObject(this); }
}

//! used for stuff that does not need serializing
public interface IGameEvent
{
}

public delegate void EventDelegate<T>(T e) where T : IGameEvent;
public delegate void MessageDelegate<T>(T e) where T : Message;

//! used by audio manager...
public class MsgLoadScene : Message, IGameEvent
{
    public override string Type { get { return "load_scene"; } }

    public enum eLoadingPhase
    {
        BEGIN,
        END
    };

    public eLoadingPhase LoadingPhase;

    //public override string Serialize()
    //{
    //    return SimpleJson.SimpleJson.SerializeObject(this);
    //}
}

public class ExampleMsg : Message, IGameEvent
{
    //! this must be first in order for net stuff to work....
    public override string Type { get { return "example_message"; } }
    //! user data
    //int someData = 2;
}



public class AuthorizedMsg : Message, IGameEvent
{
    public override string Type { get { return "authorized"; } }
}

public class ReconnectMsg : Message, IGameEvent
{
    public override string Type { get { return "reconnect"; } }
    public int port;
    public string ip;
}
