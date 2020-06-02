import {Component} from '@angular/core';
import {GameServiceService} from '../services/game-service.service';
import {Router} from "@angular/router";
import {MatSnackBar} from "@angular/material/snack-bar";

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
    private router: Router,
    private snackBar: MatSnackBar
  ) {
  }

  createGame() {
    if (!this.checkname() && !this.gameName) {
      this.snackBar.open('Please enter a game name first', null, {duration: 2000});
      return;
    }

    this.storeName();
    this.service.createGame(this.username, this.gameName).subscribe(game => {
      console.log(game);
      this.router.navigate(['/game', game.id]);
    });
  }

  joinGame() {
    if (!this.checkname() && !this.gameId) {
      this.snackBar.open('Please enter a game id first', null, {duration: 2000});
      return;
    }


    this.storeName();
    this.router.navigate(['/game', this.gameId]);
  }

  checkname(): boolean {
    if (!this.username) {
      this.snackBar.open('Please enter your name first', null, {duration: 2000});
      return false;
    }
    return true;
  }

  storeName() {
    sessionStorage.setItem('username', this.username);
  }

}
