using System;
using System.Collections.Generic;
using alkoholspiele.Models;
using alkoholspiele.Models.DTO;
using alkoholspiele.Repositories.Interfaces;
using alkoholspiele.Services.Interfaces;
using AutoMapper;

namespace alkoholspiele.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository gameRepository;
        private readonly IMapper mapper;

        public GameService(IGameRepository gameRepository, IMapper mapper)
        {
            this.gameRepository = gameRepository;
            this.mapper = mapper;
        }

        public GameDTO CreateGame(UpsertGameDTO dto)
        {
            var game = new Game()
            {
                Author = dto.Author,
                Created = DateTime.Now,
                Name = dto.Name
            };
            
            this.gameRepository.Insert(game);

            game = this.gameRepository.GetById(game.Id);

            return this.mapper.Map<GameDTO>(game);
        }

        public GameDTO GetGameById(Guid gameId)
        {
            var game = this.gameRepository.GetById(gameId);

            return this.mapper.Map<GameDTO>(game);
        }

        public void AddJoke(Guid gameId, UpsertJokeDTO dto)
        {
            var game = this.gameRepository.GetById(gameId);
            
            var joke = new Joke()
            {
                Author = dto.Author,
                Content = dto.Content,
                Created = DateTime.Now,
                Number = dto.Number
            };
            
            game.Jokes ??= new List<Joke>();
            game.Jokes.Add(joke);
            this.gameRepository.Update(game);
        }
    }
}