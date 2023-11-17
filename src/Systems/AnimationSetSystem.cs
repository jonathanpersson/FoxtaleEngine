using System.Collections.Generic;
using Foxtale.Components;
using Microsoft.Xna.Framework;

namespace Foxtale.Systems;

public class AnimationSetSystem : BaseSystem<AnimationSet>
{
    /// <summary>
    /// Contains all uninitialzied components of type T
    /// Enqueued components are initialized on next update 
    /// </summary>
    private static Queue<AnimationSet> _uninitialized = new();
    
    /// <summary>
    /// Add a component to the system
    /// </summary>
    /// <param name="component">Component to add</param>
    public new static void AddComponent(AnimationSet component)
    {
        components.Add(component);
        _uninitialized.Enqueue(component);
    }
    
    public static void InitializeComponents()
    {
        while (_uninitialized.TryDequeue(out AnimationSet component))
        {
            component.Initialize();
        }
    }
}