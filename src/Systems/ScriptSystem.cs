using System.Collections.Generic;
using Foxtale.Components;
using Microsoft.Xna.Framework;

namespace Foxtale.Systems;

public class ScriptSystem : BaseSystem<Script>
{
    /// <summary>
    /// Contains all uninitialzied components of type T
    /// Enqueued components are initialized on next update 
    /// </summary>
    private static Queue<Script> _uninitialized = new();
    
    /// <summary>
    /// Add a component to the system
    /// </summary>
    /// <param name="component">Component to add</param>
    public new static void AddComponent(Script component)
    {
        components.Add(component);
        _uninitialized.Enqueue(component);
    }
    
    public static void Update(GameTime gameTime)
    {
        while (_uninitialized.TryDequeue(out Script component))
        {
            component.Initialize();
        }

        foreach (Script component in components)
        {
            component.Update(gameTime);
        }
    }
}
