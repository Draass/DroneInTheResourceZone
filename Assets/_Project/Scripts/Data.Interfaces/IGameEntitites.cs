using System.Collections.Generic;
using _Project.Scripts.Data.Interfaces.Models;

namespace _Project.Scripts.Data.Interfaces
{
    public interface IGameEntitites
    {
        public IReadOnlyList<IResourceModel> ResourceModels { get; }
    }
}