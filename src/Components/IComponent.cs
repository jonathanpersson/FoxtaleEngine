using Microsoft.Xna.Framework;
using MgGame.Entities;

namespace MgGame.Components;


public interface IComponent
{
    public IEntity Entity { get; set; }
    public void Initialize();
    public void Update(GameTime gameTime);
}