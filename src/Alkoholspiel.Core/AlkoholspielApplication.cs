using Alkoholspiel.Core.Contracts;
using Alkoholspiel.Core.Entities;
using Alkoholspiel.Core.Notifications;

namespace Alkoholspiel.Core;

public class AlkoholspielApplication
{
    //private readonly INotificationManager notificationManager;
    private readonly IGameRepository gamesRepository;
    //private readonly IJokeRepository jokesRepository;
    
    public AlkoholspielApplication(/*INotificationManager notificationManager, IJokeRepository jokesRepository,*/ IGameRepository gamesRepository)
    {
        //this.notificationManager = notificationManager;
        //this.jokesRepository = jokesRepository;
        this.gamesRepository = gamesRepository;
    }

    public async Task<IGame> CreateGame(CreateGameRequest dto)
    {
        var game = new Game(name: dto.name, author:dto.author);
        return await this.gamesRepository.Insert(game);
    }

    public Task<IGameWithJokes> GetGameById(Guid gameId)
    {
        throw new NotImplementedException();
    }

    public Task StartGame(Guid gameId)
    {
        throw new NotImplementedException();
    }

    public Task SaveGameInstanceProgress(Guid gameId, Guid instanceId, Guid jokeId)
    {
        throw new NotImplementedException();
    }

    public Task<List<GameInstance>> GetGameInstances(Guid gameId)
    {
        throw new NotImplementedException();
    }
    
    public Task<GameInstance> GetGameInstanceById(Guid instanceId)
    {
        throw new NotImplementedException();
    }

    public Task<Joke> CreateJoke(Guid gameId, string author, string content)
    {
        throw new NotImplementedException();
    }
}