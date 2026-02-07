using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 public struct BallOutOfBounds : IEvent
{
    public Wall.WallSide SideOfBoard { get; set; }

    public static void RegisterListener(Action<Wall.WallSide> callback)
    {

    }
}

public interface IEvent
{
}

public class EventManager
{
    public delegate void GenericCallback<T>(T obj) where T : IEvent;

    public void RegisterListener<T>(object callback)
    {
        if (callback != null)
        {
        }
    }

    public static void Fire(IEvent evt)
    {

    }
}
