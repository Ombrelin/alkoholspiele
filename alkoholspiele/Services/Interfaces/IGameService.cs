using System;
using alkoholspiele.Models.DTO;

namespace alkoholspiele.Services.Interfaces
{
    public interface IGameService
    {
        GameDTO CreateGame(UpsertGameDTO dto);
        GameDTO GetGameById(Guid gameId);
        void AddJoke(Guid gameId, UpsertJokeDTO dto);
    }
}