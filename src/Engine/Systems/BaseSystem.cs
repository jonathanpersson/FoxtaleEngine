using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MgGame.Engine.Components;

namespace MgGame.Engine.Systems;

public abstract class BaseSystem<T> where T : IComponent
{
    protected static List<T> components { get; set; } = new();

    /// <summary>
    /// Add a component to the system
    /// </summary>
    /// <param name="component">Component to add</param>
    public static void AddComponent(T component)
    {
        components.Add(component);
    }

    public static void Initialize()
    {
        foreach (T component in components)
        {
            component.Initialize();
        }
    }

    /// <summary>
    /// Update components in system
    /// </summary>
    /// <param name="gameTime">Current game time</param>
    public static void Update(GameTime gameTime)
    {
        foreach (T component in components)
        {
            component.Update(gameTime);
        }
    }
}
