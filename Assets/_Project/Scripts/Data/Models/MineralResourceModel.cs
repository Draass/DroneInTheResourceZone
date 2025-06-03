using _Project.Scripts.Data.Interfaces.Models;

namespace _Project.Scripts.Data.Models
{
    public record MineralResourceModel : IResourceModel
    {
        public string Id { get; } = Constants.Resources.Mineral;
    }
}