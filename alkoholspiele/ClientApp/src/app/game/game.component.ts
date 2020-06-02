import {Component, OnInit} from '@angular/core';
import {Game, GameServiceService} from '../services/game-service.service';
import {ActivatedRoute, Router} from '@angular/router';
import {Label} from 'ng2-charts';
import {ChartDataSets} from 'chart.js';
import {MatDialog} from '@angular/material/dialog';
import {AddJokeDialogComponent} from '../add-joke-dialog/add-joke-dialog.component';
import {NameDialogComponent} from "../name-dialog/name-dialog.component";

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {

  public game: Game;
  public barChartOptions = {
    scaleShowVerticalLines: false,
    responsive: true
  };

  private contributions: Map<string, number> = new Map<string, number>();

  public barChartLabels = [];
  public barChartData = [{data: [], label: '', backgroundColor: '', hoverBackgroundColor: ''}];

  constructor(
    private service: GameServiceService,
    private route: ActivatedRoute,
    public dialog: MatDialog,
    private router: Router
  ) {
  }

  async ngOnInit() {

    this.checkUsername();

    this.route.params.subscribe(async params => {
      const id = params['id'];

      await this.initGame(id);
    });
  }

  private async initGame(id: string) {
    this.game = await this.service.getGame(id).toPromise();
    this.contributions.clear();
    for (const joke of this.game.jokes) {
      this.contributions.set(joke.author,
        this.contributions.get(joke.author) === undefined ? 1 : this.contributions.get(joke.author) + 1);

    }

    this.barChartLabels = Array.from(this.contributions.keys());
    this.barChartData = [{
      data: Array.from(this.contributions.values()),
      label: 'Contributions',
      backgroundColor: '#42A5F5',
      hoverBackgroundColor: '#1E88E5'
    }];
  }

  addJoke() {

    this.checkUsername();


    const dialogRef = this.dialog.open(AddJokeDialogComponent, {
      width: '400px'
    });

    dialogRef.afterClosed().subscribe(async result => {
      console.log('The dialog was closed');
      console.log(result);
      await this.service.addJoke(this.game.id, result.author, result.content, result.number).toPromise();
      await this.initGame(this.game.id);
    });
  }

  play() {
    this.router.navigate(['/play', this.game.id]);
  }

  checkUsername() {
    const username = sessionStorage.getItem('username');
    if (!username || username === 'undefined') {
      console.log('ask username');
      const dialogRef = this.dialog.open(NameDialogComponent, {
        width: '400px'
      });
      dialogRef.afterClosed().subscribe(result => {
        sessionStorage.setItem('username', result);
          this.checkUsername();
      });
    }
  }
}
