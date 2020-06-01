import {Component, Inject, OnInit} from '@angular/core';
import {Game, GameServiceService, Joke} from "../services/game-service.service";
import {ActivatedRoute} from "@angular/router";
import {DOCUMENT} from "@angular/common";

@Component({
  selector: 'app-play',
  templateUrl: './play.component.html',
  styleUrls: ['./play.component.css']
})
export class PlayComponent implements OnInit {

  private static ID = 'id';

  public game: Game;
  public gameId;
  public joke: string;
  public started = false;
  public players: Array<string> = new Array<string>();
  public addedPlayer: string;
  public finished = false;

  public remainingJokes: Array<Joke>;
  private index: number;
  private roundPlayers: Array<string>;

  constructor(private route: ActivatedRoute, private service: GameServiceService, @Inject(DOCUMENT) public document: Document) {
  }

  ngOnInit() {
    this.gameId = this.route.snapshot.params[PlayComponent.ID];

    if (this.gameId) {
      this.service.getGame(this.gameId).subscribe(result => {
        this.game = result;
        this.remainingJokes = [].concat(this.game.jokes);
        console.log(this.remainingJokes);
      });
    }
  }

  addPlayer(): void {
    this.players.push(this.addedPlayer);
    this.addedPlayer = '';
  }

  removePlayer(player: string): void {
    this.players.splice(this.players.indexOf(player), 1);
  }

  start(): void {
    this.started = true;
    this.next(true);
  }

  next(started: boolean): void {
    const currentJoke = this.getRandomJoke(started);
    if (currentJoke === undefined) {
      this.finished = true;
    } else {
      this.joke = currentJoke.content;

      this.roundPlayers = [].concat(this.players);

      for (let i = 0; i < currentJoke.number; ++i) {
        const player = this.getRandomPlayer();
        this.roundPlayers.splice(this.roundPlayers.indexOf(player), 1);
        this.joke = this.joke.replace('$', player);
      }

    }

  }

  randomIntFromInterval(min, max): number { // min and max included
    return Math.floor(Math.random() * (max - min + 1) + min);
  }

  getRandomPlayer(): string {
    const index = this.randomIntFromInterval(0, this.roundPlayers.length - 1);
    return this.roundPlayers[index];
  }

  getRandomJoke(started: boolean): Joke {
    if (!started) {
      this.remainingJokes.splice(this.index, 1);
    }
    this.index = this.randomIntFromInterval(0, this.remainingJokes.length - 1);
    return this.remainingJokes[this.index];
  }

}
