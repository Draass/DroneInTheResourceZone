using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Logic.Interfaces.Common
{
    public interface IAsyncInitialize
    {
        AsyncLazy InitializeTask { get; }
    }
}