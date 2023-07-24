using Foxtale.Engine.Entities;
using Microsoft.Xna.Framework;

namespace Foxtale.Engine.Components;

public interface IComponent
{
    public IEntity Entity { get; set; }
    public void Initialize();
    public void Update(GameTime gameTime);
    public void Destroy();
}