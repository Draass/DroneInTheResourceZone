using System.Collections.Generic;
using _Project.Scripts.Data.Interfaces;
using _Project.Scripts.Data.Interfaces.Models;
using _Project.Scripts.Data.Models;

namespace _Project.Scripts.Data
{
    public class GameEntitites : IGameEntitites
    {
        public IReadOnlyList<IResourceModel> ResourceModels { get; } = new List<IResourceModel>()
        {
            new MineralResourceModel()
        };
    }
}