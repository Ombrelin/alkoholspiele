import {Component} from '@angular/core';
import {GameServiceService} from '../services/game-service.service';
import {Router} from "@angular/router";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  public username: string;
  public gameId: string;
  public gameName: string;

  constructor(
    private service: GameServiceService,
    private router: Router
  ) {
  }

  createGame() {
    this.storeName();
    this.service.createGame(this.username, this.gameName).subscribe(game => {
      console.log(game);
      this.router.navigate(['/game', game.id]);
    });
  }

  joinGame() {
    this.storeName();
    this.router.navigate(['/game', this.gameId]);
  }

  storeName() {
    sessionStorage.setItem('username', this.username);
  }

}
