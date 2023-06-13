using Microsoft.Xna.Framework;
using MgGame.Engine.Entities;

namespace MgGame.Engine.Components;

public interface IComponent
{
    public IEntity Entity { get; set; }
    public void Initialize();
    public void Update(GameTime gameTime);
}