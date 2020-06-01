import { Component, OnInit } from '@angular/core';
import {Joke} from "../services/game-service.service";
import {MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-add-joke-dialog',
  templateUrl: './add-joke-dialog.component.html',
  styleUrls: ['./add-joke-dialog.component.css']
})
export class AddJokeDialogComponent implements OnInit {

  public joke: Joke = new Joke();

  public disabled = true;
  public error = '';

  constructor(public dialogRef: MatDialogRef<AddJokeDialogComponent>) {
  }

  ngOnInit() {
    this.joke.author = sessionStorage.getItem('username');
  }

  handleChange() {
    this.disabled = this.joke.content === undefined;
  }

  handleTextChange() {
    this.handleChange();
    if (this.joke.content) {
      this.joke.number = this.joke.content.split('$').length - 1;
    }
  }

  cancel() {
    this.dialogRef.close();
  }
}
