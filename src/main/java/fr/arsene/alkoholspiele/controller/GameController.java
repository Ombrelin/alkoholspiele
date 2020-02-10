package fr.arsene.alkoholspiele.controller;

import fr.arsene.alkoholspiele.model.documents.Game;
import fr.arsene.alkoholspiele.model.documents.Joke;
import fr.arsene.alkoholspiele.model.repositories.GameRepository;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
import reactor.core.publisher.Mono;

@RestController("/api/game")
public class GameController {

    private GameRepository gameRepository;

    public GameController(GameRepository gameRepository) {
        this.gameRepository = gameRepository;
    }


    // Create Game
    @PostMapping("/")
    @ResponseBody
    @ResponseStatus(HttpStatus.CREATED)
    public Mono<Game> createGame(@RequestBody Game game) {
        return this.gameRepository.save(game);
    }

    // Get a Game from id
    @GetMapping("/{gameId}")
    @ResponseBody
    @ResponseStatus(HttpStatus.OK)
    public Mono<Game> getGamebyId(@PathVariable("gameId") String gameId) {
        return this.gameRepository.findById(gameId);
    }

    // Add Joke to a game from its id
    @PostMapping("/{gameId}/jokes")
    @ResponseBody
    @ResponseStatus(HttpStatus.OK)
    public Mono<Game> addJoke(@PathVariable("gameId") String gameId, @RequestBody Joke joke) {
        return this.gameRepository.findById(gameId).map(e -> {
            e.getJokes().add(joke);
            return e;
        }).flatMap(e -> this.gameRepository.save(e));
    }

}
