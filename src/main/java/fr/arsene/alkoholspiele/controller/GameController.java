package fr.arsene.alkoholspiele.controller;

import fr.arsene.alkoholspiele.controller.dtos.GameDTO;
import fr.arsene.alkoholspiele.controller.dtos.JokeDTO;
import fr.arsene.alkoholspiele.controller.dtos.mapper.GameMapper;
import fr.arsene.alkoholspiele.controller.dtos.mapper.JokeMapper;
import fr.arsene.alkoholspiele.model.documents.Game;
import fr.arsene.alkoholspiele.model.documents.Joke;
import fr.arsene.alkoholspiele.model.repositories.GameRepository;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
import reactor.core.publisher.Mono;

@RestController("/api/game")
public class GameController {

    private GameRepository gameRepository;
    private GameMapper gameMapper;
    private JokeMapper jokeMapper;

    public GameController(GameRepository gameRepository, GameMapper gameMapper, JokeMapper jokeMapper) {
        this.gameRepository = gameRepository;
        this.gameMapper = gameMapper;
        this.jokeMapper = jokeMapper;
    }


    // Create Game
    @PostMapping("/")
    @ResponseBody
    @ResponseStatus(HttpStatus.CREATED)
    public GameDTO createGame(@RequestBody GameDTO dto){
        Game game = gameMapper.dtoToGame(dto);
        this.gameRepository.save(game);
        return gameMapper.gameToDto(game);
    }

    // Get a Game from id
    @GetMapping("/{gameId}")
    @ResponseBody
    @ResponseStatus(HttpStatus.OK)
    public Mono<GameDTO> getGamebyId(@PathVariable("gameId") String gameId){
        return this.gameRepository.findById(gameId).map(e -> gameMapper.gameToDto(e));
    }

    // Add Joke to a game from its id
    @PostMapping("/{gameId}/jokes")
    public JokeDTO addJoke(@PathVariable("gameId") String gameId, @RequestBody JokeDTO dto){
        Game game = this.gameRepository.findById(gameId).block();
        Joke joke = jokeMapper.dtoToJoke(dto);
        game.getJokes().add(joke);
        this.gameRepository.save(game);
        return jokeMapper.jokeToDto(joke);
    }

}
